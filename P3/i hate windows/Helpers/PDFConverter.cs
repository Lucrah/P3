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

namespace i_hate_windows.Helpers
{
  class PDFConverter
  {
      //In charge of setting up a page, and filling the first couple of pages with the list of returned results, and the next couple of pages with graphs/calculations for the mægler ./ask rasmus
      //Basically, converting 2 objects, a) a list of returned results and b) an object consisting of the graphs output by the program, into pdf format.

      private string PDFPath;
      private string appendToPDF;
      private BindableCollection<Listing> _searchResults;
      private object _graphResults;


      //Ctor, change this to take in rasmus's elements when they are done too

      public PDFConverter(BindableCollection<Listing> searchResults, object graphResults, string whatToAppend, string typeOfPDF)
      {
          _searchResults = searchResults;
          _graphResults = graphResults;
          PDFPath = GetPath();
          appendToPDF = whatToAppend;
          //maybe call setup pdf function here, then the other ones to add specific content?
        switch (typeOfPDF)
        {
          case "resultandgraph":
            ResultAndGraphPDF();
            break;
          case "resultOnly":
            break;
          case "graphOnly":
            break;
          default:
            //shit.
            break;
        }
      }

      //lets start by creating a path string to the pdf folder
      public string GetPath()
      {
          string result;
          result = Directory.GetCurrentDirectory() + "\\PDF";
          return result;
      }

      //if we ever want other types of pdf, make new functions. pls.
      private void ResultAndGraphPDF()
      {
          Document doc = new Document();
          try
          {
              iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(PDFPath + "/SøgeResultater - " + appendToPDF + ".pdf", FileMode.Create));
              doc.Open();
              Paragraph heading = new Paragraph("Page Heading", new Font(Font.FontFamily.HELVETICA, 28f, Font.BOLD));
              heading.SpacingAfter = 18f;
              doc.Add(heading);
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

      private string CreateLogMessage(string format, params object[] args)
      {
          return string.Format("[{0}] {1}",
          DateTime.Now.ToString("o"),
          string.Format(format, args));
      }

    private void AddPropsToDoc(BindableCollection<Listing> propertyList, Document doc)
    {
      propertyList = (BindableCollection<Listing>) propertyList.OrderBy(x => x.Address).ToObservableCollection();
      foreach (var item in propertyList)
      {
        if (item.IsSelected)
        {
          doc.Add(new Phrase(item.ToString() + Environment.NewLine));            
        }
      }
    }

    private string PropertyTypeString(SearchSettingModel ssm)
    {
      string propertyString = "";

      if (ssm.Villa)
        propertyString += "Villa, ";
      if (ssm.FritidsEjendom)
        propertyString += "Fritidsejendom, ";
      if (ssm.LiebhaverEjendom)
        propertyString += "Liebhaverejendom, ";
      if (ssm.Andelsbolig)
        propertyString += "Andelsbolig, ";
      if (ssm.Rækkehus)
        propertyString += "Rækkehus, ";
      if (ssm.NedlagtLandbrug)
        propertyString += "Nedlagt landbrug, ";

      propertyString = propertyString.Remove(propertyString.Length - 2);
      return propertyString;
    }
  }
}
 