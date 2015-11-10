using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using Dapper;
using MySql;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace ConsoleApplication1
{
  class Funktionality
  {
    private static string connectionString = "server=localhost;user id=root;password=1234;database=p3database";
    static public string savefile;
    #region
    public static void getCoordinates(Listing listing)
    {
      System.Threading.Thread.Sleep(250);
      decimal[] geoCode = new decimal[2] { 0, 0 };

      string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + listing.AddressForURL + "&sensor=false";

      var result = new System.Net.WebClient().DownloadString(address);
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(result);
      XmlNodeList parentNode = doc.GetElementsByTagName("location");
      foreach (XmlNode childrenNode in parentNode)
      {
        geoCode[0] = Convert.ToDecimal(childrenNode.SelectSingleNode("lat").InnerText, new CultureInfo("en-US"));
        geoCode[1] = Convert.ToDecimal(childrenNode.SelectSingleNode("lng").InnerText, new CultureInfo("en-US"));
      }
      listing.GetGeoCode(geoCode);
    }


    public static double convertToDistance(Listing a, Listing b)
    {
      double theDistance = (Math.Sin(DegreesToRadians(Convert.ToDouble(a.Lat))) *
            Math.Sin(DegreesToRadians(Convert.ToDouble(b.Lat))) +
            Math.Cos(DegreesToRadians(Convert.ToDouble(a.Lat))) *       //Haversine formula
            Math.Cos(DegreesToRadians(Convert.ToDouble(b.Lat))) *
            Math.Cos(DegreesToRadians(Convert.ToDouble(a.Lng - b.Lng))));
                                                                            
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


    static public void importForSale(Dictionary<int, ListingForSale> dict)
    {
      //_input,_num,_widgetName,_source,_resultNumber,_pageUrl,adresse,postnr,by,pris,kvm_pris,type,liggetid_nu,
      //liggetid_total,kvm_bbr,kvm_bbr_vaegtet,vaerelser,links,links / _source,links / _title,links / _text
      var reader = new StreamReader(File.OpenRead(savefile + "nyboligsiden.csv"), Encoding.UTF8);
      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        string[] values = line.Split(',');

        string adresse = values[6];
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

        int areaCode = Convert.ToInt32(values[7]);
        int priceOfHouse = Convert.ToInt32(values[9].Replace(".",""));
        int sqrPrice;
        if (values[14] == "-")
        {
          sqrPrice = 0;
        }
        else
        {
          sqrPrice = Convert.ToInt32(values[10].Replace(".", ""));
        }
        string propertyType = values[11];
        int demurrage = Convert.ToInt32(values[12].Replace(".", ""));
        int sizeOfHouse;
        if (values[14] == "-")
        {
          sizeOfHouse = 0;
        }
        else
        {
          sizeOfHouse = Convert.ToInt32(values[14]);
        }
        int numberOfRooms;
        if (values[16] == "-")
        {
          numberOfRooms = 0;
        }
        else
        {
          numberOfRooms = Convert.ToInt32(values[16]);
        }

        ListingForSale listing = new ListingForSale(streetName, houseNumber, numberOfRooms, areaCode, priceOfHouse, sizeOfHouse, 
          sqrPrice, propertyType, demurrage);
        dict.Add(listing.ID, listing);
      }
    }
        static public void importSold(Dictionary<int, ListingSold> dict)
        {
            var reader = new StreamReader(File.OpenRead(savefile + "HackSolgte.csv"), Encoding.UTF8);
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

        ListingSold listing = new ListingSold(streetName, houseNumber, room, areaCode, cleanPrice, sizeHouse, yearBuilt, salesDate, cleansqrprice, salesType, propertyType);
        dict.Add(listing.ID, listing);
            }
        }
        public static void SaveUpdateSold(ListingSold property)
        {

          using (StreamWriter tw = new StreamWriter(savefile + "DBListings.csv", true))
          {
            tw.WriteLine("{0};{1};{2};{3};{4}", property.ID, property.PropertyType, property.Size, property.Rooms, property.YearBuilt);
          }

          using (StreamWriter tw = new StreamWriter(savefile + "DBAddress.csv", true))
          {
           tw.WriteLine("{0};{1};{2};{3};{4};{5}", property.ID, property.StreetName, property.HouseNumber, property.AreaCode,
               property.Lat, property.Lng);
          }
          using (StreamWriter tw = new StreamWriter(savefile + "DBSalesInfoSold.csv", true))
          {
            tw.WriteLine("{0};{1};{2};{3};{4}", property.ID, property.SalesType, property.Price, property.Sqrprice, property.SalesDate);
          }
        }
        public static void SaveUpdateForSale(ListingForSale property)
        {

          using (StreamWriter tw = new StreamWriter(savefile + "DBListings.csv", true))
          {
            tw.WriteLine("{0};{1};{2};{3};{4}", property.ID, property.PropertyType, property.Size, property.Rooms, property.YearBuilt);
          }

          using (StreamWriter tw = new StreamWriter(savefile + "DBAddress.csv", true))
          {
            tw.WriteLine("{0};{1};{2};{3};{4};{5}", property.ID, property.StreetName, property.HouseNumber, property.AreaCode,
                property.Lat, property.Lng);
          }
          using (StreamWriter tw = new StreamWriter(savefile + "DBSalesInfoForSale.csv", true))
          {
              tw.WriteLine("{0};{1};{2};{3}", property.ID,  property.Price, property.Sqrprice, property.Demurrage);
          }
        }

    public static void InitializeLatLng()
    {
      Console.WriteLine("Initializing....");
      string sql;
      double count = 0;
      List<Listing> list = new List<Listing>();
      using (MySqlConnection connection = new MySqlConnection(connectionString))
      {
        list = connection.Query<Listing>("SELECT IDAddress AS id, StreetName AS streetName, HouseNumber AS houseNumber, AreaCode AS areaCode, Lat AS lat, Lng AS lng FROM address WHERE Lat = 0.0 AND Lng = 0.0 ORDER BY Lat ASC LIMIT 2500").ToList();
        Console.WriteLine("We Connected....");
        foreach (var item in list)
        {
        
          Console.WriteLine((count / list.Count).ToString("P"));
          count++;
          getCoordinates(item);
          Console.WriteLine(item.ID + "    " + item.Lat + "    " + item.Lng);
          if (item.Lat == 0)
          {
            break;
          }
          sql = string.Format("UPDATE address SET Lat = {0}, Lng = {1} Where IDAddress = {2}", item.Lat, item.Lng, item.ID);

          MySqlCommand command = new MySqlCommand(sql, connection);
          command.Connection.Open();
          command.ExecuteNonQuery();
          command.Connection.Close();


          Console.Clear();
        }
      }
      
    }
  }
}
