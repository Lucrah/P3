using System;
using System.Xml;
using P3.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using Caliburn.Micro;

namespace P3.Helpers
{
    class Funktionality
    {
        //should this not be coupled directly onto listing.cs to keep it as close to data as possible
        //Or maybe even put it in BaseINPCModel, so that any listing, as long as it has an adress it can get coords 4 u

        private static string connectionString = "server=localhost;user id=root;password=1234;database=p3database";

        #region Cords and haversine.. haversine is obsolete... done with queries instead
        public static void getCoordinates(Listing listing)  //need the new getcoordinates from ConsoleApplication1..
        {
            System.Threading.Thread.Sleep(1000);
            double[] geoCode = new double[2] { 0.0, 0.0 };

            string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + listing.AddressForUrl + "&sensor=false";

            var result = new System.Net.WebClient().DownloadString(address);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            XmlNodeList parentNode = doc.GetElementsByTagName("location");
            foreach (XmlNode childrenNode in parentNode)
            {
                listing.Lat = Convert.ToDouble(childrenNode.SelectSingleNode("lat").InnerText);
                listing.Lng = Convert.ToDouble(childrenNode.SelectSingleNode("lng").InnerText);
            }
        }


        public static double convertToDistance(Listing a, Listing b)
        {
            //Haversine formula for calculating distance between lat/long points
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

        public BindableCollection<Listing> StaticSearch()
        {
            BindableCollection<Listing> Results = new BindableCollection<Listing>();
            List<Listing> listForSale = new List<Listing>();
            List<Listing> listSold = new List<Listing>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                listForSale = connection.Query<Listing>("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfoforsale.Price AS price, salesinfoforsale.PriceSqr AS priceSqr, salesinfoforsale.Demurrage AS demurrage FROM address, listings, salesinfoforsale WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfoforsale.IDSalesInfoForSale LIMIT 25").AsList();
                listSold = connection.Query<Listing>("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfosold.SalesType AS salesType, salesinfosold.Price AS price, salesinfosold.PriceSqr AS priceSqr, salesinfosold.SalesDate AS salesDate FROM address, listings, salesinfosold WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfosold.IDSalesInfoSold LIMIT 25").AsList();

            }
            foreach (var ForSale in listForSale)
            {
                Results.Add(ForSale);
            }
            foreach (var Sold in listSold)
            {
                Results.Add(Sold);
            }
            return Results;
        }

        public static string SqlStringBuilder(SearchSettingModel input)
        {
            string sql = System.String.Format("SELECT * FROM p3database WHERE ");

            string[] split = input.SearchInput.Split(' ');
            Listing SearchListing = new Listing(split[0], split[1], int.Parse(split[2]));
            getCoordinates(SearchListing);

            if (input.SearchInput != null)
            {
                sql += System.String.Format("SELECT *, 111.045* DEGREES(ACOS(COS(RADIANS(latpoint)) * COS(RADIANS(Lat)) * COS(RADIANS(longpoint) - RADIANS(Lng)) + SIN(RADIANS(latpoint)) * SIN(RADIANS(Lat))))*1000 AS distance_in_m FROM address JOIN ( SELECT {0} AS latpoint,  {1} AS longpoint) AS p ON 1=1", SearchListing.Lat, SearchListing.Lng);
            }

            if (input.Andelsbolig == true || input.Villa == true || input.Rækkehus == true || input.LiebhaverEjendom == true || input.FritidsEjendom == true || input.NedlagtLandbrug == true)
            {
                string sqlOr = System.String.Format("");
                List<bool> ejendomme = new List<bool>();
                List<bool> TrueEjendomme = new List<bool>();
                ejendomme.Add(input.Andelsbolig);
                ejendomme.Add(input.Villa);
                ejendomme.Add(input.Rækkehus);
                ejendomme.Add(input.LiebhaverEjendom);
                ejendomme.Add(input.FritidsEjendom);
                ejendomme.Add(input.NedlagtLandbrug);
                foreach (var item in ejendomme)
                {
                    if (item == true)
                    {
                        TrueEjendomme.Add(item);
                    }
                }
                if (TrueEjendomme.Count > 1)
                {
                    int count = 1;
                    foreach (var item in TrueEjendomme)
                    {
                        if (count == TrueEjendomme.Count)
                        {
                            sqlOr += System.String.Format("{0} AND ", item);
                        }
                        else
                        {
                            sqlOr += string.Format("{0} OR ", item);
                            count++;
                        }

                    }
                    sql += sqlOr;
                }
                else
                {
                    sql += System.String.Format("{0} AND ", TrueEjendomme.ToString());
                }
                
            }

            if (input.PriceSliderLowerValue > 0.0 && input.PriceSliderHigherValue > 0.0)
	        {
		        sql += System.String.Format("Price >= {0} AND Price <= {1} AND ", input.PriceSliderLowerValue, input.PriceSliderHigherValue);
	        }
            if (input.Sold == true)
            {
                sql += System.String.Format("SalesDate <> NULL AND ");
            }
            if (input.Sold == false)
            {
                sql += System.String.Format("SalesDate = NULL AND ");
            }
            if (input.SizeSliderLowerValue > 0.0 && input.SizeSliderHigherValue > 0.0)
            {
                sql += System.String.Format("Size >= {0} AND Size <= {1} AND ", input.SizeSliderLowerValue, input.SizeSliderHigherValue);
            }
            if (input.DowntimeLowerValue > 0.0 && input.DowntimeHigherValue > 0.0)
            {
                sql += System.String.Format("Size >= {0} AND Size <= {1} AND ", input.DowntimeLowerValue, input.DowntimeHigherValue);
            }
            if (input.AreaSliderLowerValue > 0.0 && input.AreaSliderHigherValue > 0.0)
            {
                sql += System.String.Format("having distance_in_m BETWEEN {0} AND {1} AND ", input.AreaSliderLowerValue, input.AreaSliderHigherValue);
            }
            if (input.SameRoad == true)
            {
                sql += System.String.Format("StreetName = {0} AND ", split[0]);
            }
            if (input.SameZipCode == true)
            {
                sql += System.String.Format("AreaCode = {0} AND ", int.Parse(split[2]));
            }

            sql += System.String.Format("NumberOfRooms BETWEEN {0} AND {1} AND YearBuild BETWEEN {2} AND {3}",
                input.MinRoomCount, input.MaxRoomCount, input.MinYearBuilt, input.MaxYearBuilt);
            return sql;
        }
    }
}
