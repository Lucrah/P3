using Caliburn.Micro;
using iTextSharp.text;
using iTextSharp;
using P3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dapper;
using Org.BouncyCastle.Security;
using P3.ViewModels;
using List = System.Windows.Documents.List;
using iTextSharp.text.pdf;

namespace i_hate_windows.Helpers
{
  class PDFConverter
  {
        //In charge of setting up a page, and filling the first couple of pages with the list of returned results, and the next couple of pages with graphs/calculations for the mægler ./ask rasmus
        //Basically, converting 2 objects, a) a list of returned results and b) an object consisting of the graphs output by the program, into pdf format.

        private string PDFPath;
        private string appendToPDF;
        private BindableCollection<Listing> _searchResults;
        private SearchSettingModel _searchInput;
        private object _graphResults;

        //Ctor, change this to take in rasmus's elements when they are done too

        public PDFConverter(BindableCollection<Listing> searchResults, SearchSettingModel searchInput, object graphResults, string whatToAppend)
      {
          _searchResults = searchResults;
            _searchInput = searchInput;
          _graphResults = graphResults;
          PDFPath = GetPath();
          appendToPDF = whatToAppend;
          ResultAndGraphPDF();
      }

      //lets start by creating a path string to the pdf folder
      public string GetPath()
      {
          string result;
          result = Directory.GetCurrentDirectory() + "\\PDF";
          return result;
      }

      //if we ever want other types of pdf, make new functions. Or maybe reuse some of the bottom ones.
      private void ResultAndGraphPDF()
      {
            Document doc = new Document();
            doc.SetPageSize(PageSize.A4);
            try
            {
                //INITIALIZATION
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(PDFPath + "/SøgeResultater.pdf", FileMode.Create));
                doc.Open();
                //calling the main functions to handle adding content
                BannerAdd(doc, writer);
                SearchInfo(doc);
                doc.NewPage();
                //no need to pass in that
                ResultTable(_searchResults, doc);
                doc.NewPage();
                //Call function to show rasmus thing here

            }
            catch (Exception ex)
          {

              Debug.WriteLine(CreateLogMessage(ex.ToString(), "PDF ERROR"));
          }
          finally
          {
              doc.Close();
          }
      }

        private string SoldOrForsaleString()
        {
            string resultString;
            if (_searchInput.Sold)
            {
                resultString = "Søger efter: Solgte";
            }
            else if (_searchInput.ForSale)
            {
                resultString = "Søger efter: Boliger til salg";
            }
            else if (_searchInput.Sold && _searchInput.ForSale)
            {
                resultString = "Søger efter: Både solgte boliger og boliger til salg";
            }
            else
            {
                resultString = "Salgsdata ikke fundet\n";
            }

            return resultString;
        }
        private string Sameroadzipcity()
        {
            string resultString;
            if (_searchInput.SameRoad)
            {
                resultString = "Søger på samme vej\n";
            }
            if (_searchInput.SameZipCode)
            {
                resultString = "Søger i samme postnummer\n";
            }
            if (_searchInput.SameCity)
            {
                resultString = "Søger i samme by\n";
            }
            else
            {
                resultString = "Søgetype ikke fundet\n";
            }
            return resultString;
        }
        private string CreateLogMessage(string format, params object[] args)
        {
            return string.Format("[{0}] {1}",
            DateTime.Now.ToString("o"),
            string.Format(format, args));
        }
        private string PropertyTypeString()
        {
            string propertyString = "";

            if (_searchInput.Villa)
                propertyString += "Villa, ";
            if (_searchInput.FritidsEjendom)
                propertyString += "Fritidsejendom, ";
            if (_searchInput.LiebhaverEjendom)
                propertyString += "Liebhaverejendom, ";
            if (_searchInput.Andelsbolig)
                propertyString += "Andelsbolig, ";
            if (_searchInput.Rækkehus)
                propertyString += "Rækkehus, ";
            if (_searchInput.NedlagtLandbrug)
                propertyString += "Nedlagt landbrug, ";
            if (propertyString.Length < 2)
            {
                propertyString += "Boligtype-søgeinfo ikke fundet, ";
            }

            propertyString = propertyString.Remove(propertyString.Length - 2);
            return propertyString;
        }

        //These three functions handle creating all the things in the pdf. Put down here to make it easier to read the other parts of this class.
        private void ResultTable(BindableCollection<Listing> propertyList, Document doc)
        {
            iTextSharp.text.Font PropertyFont = new iTextSharp.text.Font();
            iTextSharp.text.Font headerfont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD);
            propertyList = (BindableCollection<Listing>)propertyList.OrderBy(x => x.Address).ToObservableCollection();

            //Creating a table, and adding items dynamically
            PdfPTable resultTable = new PdfPTable(8);
            resultTable.TotalWidth = PageSize.A4.Width;
            resultTable.LockedWidth = true;
            PdfPCell header = new PdfPCell(new Phrase("Søgeresultatliste\n", headerfont));
            header.Colspan = 8;
            header.PaddingBottom = 10f;
            resultTable.AddCell(header);
            resultTable.SetWidths(new float[] { 20f, 40f, 20f, 20f, 20f, 20f, 20f, 20f, });

            resultTable.AddCell("Boligtype");
            resultTable.AddCell("Adresse");
            resultTable.AddCell("By/Postnr");
            resultTable.AddCell("Pris");
            resultTable.AddCell("Størrelse");
            resultTable.AddCell("Liggetid");
            resultTable.AddCell("Til salg/Solgt");
            resultTable.AddCell("Byggeår");

            foreach (var item in propertyList)
            {
                if (item.IsSelected)
                {
                    resultTable.AddCell(item.PropertyType);
                    PdfPCell adresscell = new PdfPCell(new Phrase(item.Address));
                    resultTable.AddCell(adresscell);
                    resultTable.AddCell(item.Town + "(" + item.AreaCode + ")");
                    resultTable.AddCell(item.Price.ToString());
                    resultTable.AddCell(item.Size.ToString());
                    resultTable.AddCell(item.Demurrage.ToString());
                    resultTable.AddCell(item.ForSaleSold);
                    resultTable.AddCell(item.YearBuilt.ToString());
                }
            }
            if (resultTable != null)
            {
                doc.Add(resultTable);
            }
        }
        private void SearchInfo(Document doc)
        {
            //creating a font to use for the subheader. When you set a font like this it will change font of phrases either after or if used in ctor, for the specific phrase.
            iTextSharp.text.Font subheaderfont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18f, iTextSharp.text.Font.BOLD);

            doc.Add(new Phrase(
                "\n\n\nSøgeparametre: \n\n"
                , subheaderfont));
            doc.Add(new Phrase(
                "Adresse: " + _searchInput.SearchInput + "\n"
                + "Prisinterval: " + _searchInput.PriceSliderLowerValue + "-" + _searchInput.PriceSliderHigherValue + " Kr.\n"
                + "Størrelsesinterval: " + _searchInput.SizeSliderLowerValue + "-" + _searchInput.SizeSliderHigherValue + " kvm\n"
                + "Liggetidsinterval: " + _searchInput.DowntimeLowerValue + "-" + _searchInput.DowntimeHigherValue + " Måneder\n"
                + "Områdesøgnings-rækkevidde: " + _searchInput.AreaSliderLowerValue + "-" + _searchInput.AreaSliderHigherValue + " m\n"
                + "Byggeårsinterval: " + _searchInput.MinYearBuilt + "-" + _searchInput.MaxYearBuilt + "\n"
                + "Rum-antal: " + _searchInput.MinRoomCount + "-" + _searchInput.MaxRoomCount + " rum\n"
                + "Pris pr kvm: " + _searchInput.MinPrKvm + "-" + _searchInput.MaxPrKvm + " kr/kvm\n"
                + "Grundens størrelse: " + _searchInput.MinGroundSize + "-" + _searchInput.MaxGroundSize + " kvm\n"
                + "Boligtyper: " + PropertyTypeString() + "\n"
                + SoldOrForsaleString()
                + Sameroadzipcity()
                ));
        }
        private void BannerAdd(Document doc, PdfWriter writer)
        {
            PdfContentByte cb = writer.DirectContent;
            cb.SaveState();
            iTextSharp.text.Image banner = iTextSharp.text.Image.GetInstance(Directory.GetCurrentDirectory() + "/banner.png");
            banner.SetAbsolutePosition(0f, 750f);
            banner.ScaleToFit(doc.PageSize.Width, 50f);
            cb.AddImage(banner);
            cb.RestoreState();
        }
    }
}
 