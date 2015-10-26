using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace ConsoleApplication1
{
  class Funktionality
  {
        string savefile;
    #region
    public static void getCoordinates(Listing listing)
    {
      System.Threading.Thread.Sleep(1000);
      double[] geoCode = new double[2] { 0, 0 };

      string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + listing.AddressForURL + "&sensor=false";

      var result = new System.Net.WebClient().DownloadString(address);
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(result);
      XmlNodeList parentNode = doc.GetElementsByTagName("location");
      foreach (XmlNode childrenNode in parentNode)
      {
        geoCode[0] = double.Parse(childrenNode.SelectSingleNode("lat").InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
        geoCode[1] = double.Parse(childrenNode.SelectSingleNode("lng").InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
      }
      listing.GetGeoCode(geoCode);
    }


    public static double convertToDistance(Listing a, Listing b)
    {
      double theDistance = (Math.Sin(DegreesToRadians(a.Lat)) *
            Math.Sin(DegreesToRadians(b.Lat)) +
            Math.Cos(DegreesToRadians(a.Lat)) *
            Math.Cos(DegreesToRadians(b.Lat)) *
            Math.Cos(DegreesToRadians(a.Lng - b.Lng)));

      return Convert.ToDouble((RadiansToDegrees(Math.Acos(theDistance)))) * 69.09 * 1.6093;
    }

    static public double RadiansToDegrees(double angle)
    {
      return angle * (180.0 / Math.PI);
    }

    static public double DegreesToRadians(double angle)
    {
      return Math.PI * angle / 180.0;
    }
        #endregion

        private void ImportPath()
        {
            
            string rel_path = Directory.GetCurrentDirectory();
            string dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            savefile = rel_path.Remove(rel_path.Length - 1) + @"Data\";
        }

        private void importSold()
        {
            var reader = new StreamReader(File.OpenRead(savefile + "Solgte.csv"), Encoding.Default);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');

                int room = Convert.ToInt32(values[0]);
                string salesType = values[1];
                int sizeHouse = Convert.ToInt32(values[2]);
                string uncleanSqrPrice = values[3];
                int cleansqrprice = Convert.ToInt32(uncleanSqrPrice.Replace(".", ""));
                int yearBuilt = Convert.ToInt32(values[4]);
                string uncleanPrice = values[5];
                int cleanPrice = Convert.ToInt32(uncleanPrice.Replace(".", ""));
                string adresse = values[6];
                string streetName = String.Empty;
                string houseNumber = String.Empty;
                Match regexMatch = Regex.Match(adresse, "\\d");
                if (regexMatch.Success)
                {
                    int digitStartIndex = regexMatch.Index;
                    streetName = adresse.Substring(0, digitStartIndex);
                    houseNumber = adresse.Substring(digitStartIndex);
                }
                string propertyType = values[7];
                int areaCode = Convert.ToInt32(values[8]);
            }
        }
    }
}
