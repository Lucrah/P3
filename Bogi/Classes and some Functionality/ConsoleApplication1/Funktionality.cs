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
    static public string savefile;
    #region
    public static void getCoordinates(Listing listing)
    {
      System.Threading.Thread.Sleep(250);
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
            Math.Cos(DegreesToRadians(a.Lat)) *       //Haversine formula
            Math.Cos(DegreesToRadians(b.Lat)) *
            Math.Cos(DegreesToRadians(a.Lng - b.Lng)));
                                                                            
      return Convert.ToDouble((RadiansToDegrees(Math.Acos(theDistance)))) * 69.09 * 1.6093; // the distance unit is 69.09 wich returns distance in miles.. there are 1.6 kilometers in a mile. so return is in km.
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

        static public void ImportPath()
        {
            
            string rel_path = Directory.GetCurrentDirectory();
            string dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            savefile = rel_path.Remove(rel_path.Length - 1) + @"Data\";
        }

        static public void importSold(Dictionary<string, Listing> dict)
        {
            var reader = new StreamReader(File.OpenRead(savefile + "bogi1.csv"), Encoding.UTF8);
              while (!reader.EndOfStream)
              {
                var line = reader.ReadLine();
          
        string[] values = line.Split(',');

        int room;
                if (values[0] == "-")
                {
                  room = 0;
                }
                else
                {
                  room = Convert.ToInt32(values[0]);
                }
                string salesType = values[1];
                int sizeHouse;
                if (values[2] == "-")
                {
                  sizeHouse = 0;
                }
                else
                {
                  sizeHouse = Convert.ToInt32(values[2]);
                }
                string uncleanSqrPrice;
                if (values[3] == "-")
                {
                  uncleanSqrPrice = "0";
                }
                else
                {
                  uncleanSqrPrice = values[3];
                }
                int cleansqrprice = Convert.ToInt32(uncleanSqrPrice.Replace(".", ""));
                int yearBuilt;
                if (values[4] == "-")
                {
                  yearBuilt = 0;
                }
                else
                {
                  yearBuilt = Convert.ToInt32(values[4]);
                }
                string uncleanPrice = values[5];
                if (values[5] == "-")
                {
                  uncleanPrice = "0";
                }
                else
                {
                  uncleanPrice = values[5];
                }   
                int cleanPrice = Convert.ToInt32(uncleanPrice.Replace(".", ""));
                string salesDate = values[6];
                string adresse = values[7];
                string streetName = String.Empty;
                string houseNumber = String.Empty;
                Match regexMatch = Regex.Match(adresse, "\\d");
                if (regexMatch.Success)
                {
                    int digitStartIndex = regexMatch.Index;
                    streetName = adresse.Substring(0, digitStartIndex - 1);
                    string uncleanHouseNumber = adresse.Substring(digitStartIndex);
                    string[] uncleanHousenumber = uncleanHouseNumber.Split(' ');
                    houseNumber = uncleanHousenumber[0];
                }
                string propertyType = values[8];
                int areaCode = Convert.ToInt32(values[9]);

        Listing listing = new Listing(streetName, houseNumber, room, areaCode, cleanPrice, sizeHouse, yearBuilt, salesDate, cleansqrprice, salesType, propertyType);
        dict.Add(Convert.ToString(listing.ID), listing);
            }
        }
        public static void SaveUpdate(Listing property)
        {

          using (StreamWriter tw = new StreamWriter(savefile + "ImportedProperties_Bogi1.csv", true))
          {
            tw.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12}", property.ID, property.PropertyType, property.StreetName, property.HouseNumber, property.AreaCode, 
              property.YearBuilt, property.Rooms,property.Price, property.Sqrprice, property.SalesDate, property.SalesType, property.Lat, property.Lng);
          }

        }
    }
}
