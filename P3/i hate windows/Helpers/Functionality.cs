using System;
using System.Xml;
using P3.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Globalization;
using P3.ViewModels;
using System.ComponentModel.Composition;
using i_hate_windows.ViewModels;

namespace P3.Helpers
{
    [Export(typeof(Funktionality))]
  class Funktionality
  {
        private IWindowManager _windowManager;

        [ImportingConstructor]
        public Funktionality(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            //_windowManager.ShowDialog(new bogipopupViewModel("this is a popup"));
        }


    //should this not be coupled directly onto listing.cs to keep it as close to data as possible
    //Or maybe even put it in BaseINPCModel, so that any listing, as long as it has an adress it can get coords 4 u

    private static string connectionString = "server=localhost;user id=root;password=1234;database=p3database";

    #region Cords
    public void getCoordinates(Listing listing)
    {
      System.Threading.Thread.Sleep(250);

      string address = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + listing.AddressForUrl + "&sensor=false";

      var result = new System.Net.WebClient().DownloadString(address);
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(result);
      string status = doc.DocumentElement.SelectSingleNode("/GeocodeResponse/status").InnerText;
      XmlNodeList parentNode = doc.GetElementsByTagName("location");

      if (status == "OK")
      {
        foreach (XmlNode childrenNode in parentNode)
        {
          System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
          customCulture.NumberFormat.NumberDecimalSeparator = ".";
          System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
          listing.Lat = Convert.ToDouble(childrenNode.SelectSingleNode("lat").InnerText);
          listing.Lng = Convert.ToDouble(childrenNode.SelectSingleNode("lng").InnerText);
        }
      }
      else if (status == "ZERO_RESULTS")
      {
        //kast exception der fortæller at addressen ikke findes og/eller er stavet forkert.
        _windowManager.ShowDialog(new bogipopupViewModel("Adressen kunne ikke findes."));
      }
      else if (status == "OVER_QUERY_LIMIT")
      {
        _windowManager.ShowDialog(new bogipopupViewModel("Kvoten af lookups er opbrugt."));
        //Kast exception der fortæller at de har opbrugt kvote af lookups.

      }
      //string lol = String.Format("{0}     -     {1} \n {2}", listing.Lat, listing.Lng, listing.AddressForUrl);
      //_windowManager.ShowDialog(new bogipopupViewModel(lol));
    }

    public BindableCollection<Listing> StaticSearch()
    {
      BindableCollection<Listing> Results = new BindableCollection<Listing>();
      List<Listing> listForSale = new List<Listing>();
      List<Listing> listSold = new List<Listing>();
      using (MySqlConnection connection = new MySqlConnection(connectionString))
      {
        listForSale = connection.Query<Listing>("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfoforsale.Price AS price, salesinfoforsale.PriceSqr AS priceSqr, salesinfoforsale.ForSaleDate AS forSaleDate FROM address, listings, salesinfoforsale WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfoforsale.IDSalesInfoForSale").AsList();
        listSold = connection.Query<Listing>("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfosold.SalesType AS salesType, salesinfosold.Price AS price, salesinfosold.PriceSqr AS priceSqr, salesinfosold.SalesDate AS salesDate FROM address, listings, salesinfosold WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfosold.IDSalesInfoSold").AsList();

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

    public BindableCollection<Listing> SuperSearch(SearchSettingModel input)
    {
      BindableCollection<Listing> Results = new BindableCollection<Listing>();
      List<Listing> listForSale = new List<Listing>();
      List<Listing> listSold = new List<Listing>();
      using (MySqlConnection connection = new MySqlConnection(connectionString))
      {
        if (input.ForSale && !input.Sold)
        {
          listForSale = connection.Query<Listing>(SqlStringBuilderForSale(input)).AsList();
        }
        else if (!input.ForSale && input.Sold)
        {
          listSold = connection.Query<Listing>(SqlStringBuilderSold(input)).AsList();
        }
        else
        {
          listSold = connection.Query<Listing>(SqlStringBuilderSold(input)).AsList();
          listForSale = connection.Query<Listing>(SqlStringBuilderForSale(input)).AsList();
        }
        

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

    private string SqlStringBuilderForSale(SearchSettingModel input)
    {
      string sql = System.String.Format("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfoforsale.Price AS price, salesinfoforsale.PriceSqr AS priceSqr, salesinfoforsale.ForSaleDate AS forSaleDate FROM address, listings, salesinfoforsale WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfoforsale.IDSalesInfoForSale AND ");

      string[] split = { "Unknown" };
      Listing SearchListing;
      if (input.SearchInput != null)
      {
        split = input.SearchInput.Split(' ');
        SearchListing = new Listing(split[0].Trim(','), split[1], int.Parse(split[2]));
        getCoordinates(SearchListing);

        if (input.AreaSliderLowerValue >= 0.0 && input.AreaSliderHigherValue > 0.0 && !input.SameRoad && !input.SameZipCode)
        {
          sql = System.String.Format("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfoforsale.Price AS price, salesinfoforsale.PriceSqr AS priceSqr, salesinfoforsale.ForSaleDate AS forSaleDate, 111.045 * DEGREES(ACOS(COS(RADIANS({0})) * COS(RADIANS(Lat)) * COS(RADIANS({1}) - RADIANS(Lng)) + SIN(RADIANS({0})) * SIN(RADIANS(Lat)))) * 1000 AS distance_in_m FROM address, listings, salesinfoforsale JOIN( SELECT  {0}  AS latpoint, {1} AS longpoint ) AS p ON 1 = 1 WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfoforsale.IDSalesInfoForSale AND ", SearchListing.Lat, SearchListing.Lng);
        }
      }

      string sqlOr = "(";
      string AndOr = string.Empty;
      string proptype = "listings.PropertyType = ";
      List<bool> PropTypes = new List<bool> { input.Andelsbolig, input.Sommerhus, input.Lejlighed, input.Ejerlejlighed, input.Rækkehus, input.Villa, input.Andet };
      List<bool> PropTypeChecked = new List<bool>();
      foreach (var item in PropTypes)
      {
        if (item)
        {
          PropTypeChecked.Add(item);
        }
      }
      int count = PropTypeChecked.Count;

      if (input.Andelsbolig)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Andelsbolig\" " + AndOr;
        count--;
      }

      if (input.Villa)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Villa\" " + AndOr;
        count--;
      }

      if (input.Sommerhus)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Sommerhus\" " + AndOr;
        count--;
      }

      if (input.Lejlighed)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Lejlighed\" " + AndOr;
        count--;
      }

      if (input.Ejerlejlighed)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Ejerlejlighed\" " + AndOr;
        count--;
      }

      if (input.Rækkehus)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Rækkehus\" " + AndOr;
        count--;
      }

      if (input.Andet)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Andet\" " + AndOr;
        count--;
      }

      sqlOr += ") AND ";

      if (PropTypeChecked.Count != 0)
      {
        sql += sqlOr;
      }

      if (input.PriceSliderHigherValue > 0.0)
      {
        sql += System.String.Format("salesinfoforsale.Price >= {0} AND salesinfoforsale.Price <= {1} AND ", input.PriceSliderLowerValue, input.PriceSliderHigherValue);
      }

      if (input.SizeSliderHigherValue > 0.0)
      {
        sql += System.String.Format("listings.Size >= {0} AND listings.Size <= {1} AND ", input.SizeSliderLowerValue, input.SizeSliderHigherValue);
      }

      if (input.DowntimeHigherValue > 0.0 && input.ForSale)
      {
        sql += System.String.Format("DATEDIFF(current_date(), salesinfoforsale.ForSaleDate) >= {0} AND DATEDIFF(current_date(), salesinfoforsale.ForSaleDate) <= {1} AND ", input.DowntimeLowerValue, input.DowntimeHigherValue);
      }

      if (input.SameRoad)
      {
        sql += System.String.Format("address.StreetName = \"{0}\" AND ", split[0].Trim(','));
      }

      if (input.SameZipCode)
      {
        sql += System.String.Format("address.AreaCode = {0} AND ", int.Parse(split[2]));
      }

      sql += System.String.Format("listings.NumberOfRooms >= {0} AND listings.NumberOfRooms <= {1} ",
          input.MinRoomCount, input.MaxRoomCount);

      if (input.AreaSliderLowerValue >= 0.0 && input.AreaSliderHigherValue > 0.0 && !input.SameRoad && !input.SameZipCode)
      {
        sql += System.String.Format("HAVING distance_in_m <= {0} ", input.AreaSliderHigherValue);
      }

      sql += "LIMIT 25";
    
      //throw new Exception(sql);
      return sql;
    }

    private string SqlStringBuilderSold(SearchSettingModel input)
    {
      string sql = System.String.Format("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfosold.SalesType AS salesType, salesinfosold.Price AS price, salesinfosold.PriceSqr AS priceSqr, salesinfosold.SalesDate AS salesDate FROM address, listings, salesinfosold WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfosold.IDSalesInfoSold AND ");

      string[] split = { "Unknown" };
      Listing SearchListing;
      if (input.SearchInput != null)
      {
        split = input.SearchInput.Split(' ');
        SearchListing = new Listing(split[0].Trim(','), split[1], int.Parse(split[2]));
        getCoordinates(SearchListing);

        if (input.AreaSliderLowerValue >= 0.0 && input.AreaSliderHigherValue > 0.0 && input.SameRoad == false && input.SameZipCode == false)
        {
          sql = System.String.Format("SELECT address.IDAddress AS id, address.StreetName AS streetName, address.HouseNumber AS houseNumber, address.AreaCode AS areaCode, listings.PropertyType AS propertyType, listings.Size AS size, listings.NumberOfRooms AS numberOfRooms, listings.YearBuild AS yearBuilt, salesinfosold.SalesType AS salesType, salesinfosold.Price AS price, salesinfosold.PriceSqr AS priceSqr, salesinfosold.SalesDate AS salesDate, 111.045 * DEGREES(ACOS(COS(RADIANS({0})) * COS(RADIANS(Lat)) * COS(RADIANS({1}) - RADIANS(Lng)) + SIN(RADIANS({0})) * SIN(RADIANS(Lat)))) * 1000 AS distance_in_m FROM address, listings, salesinfosold JOIN( SELECT  {0}  AS latpoint, {1} AS longpoint ) AS p ON 1 = 1 WHERE address.IDAddress = listings.IDListings AND address.IDAddress = salesinfosold.IDSalesInfoSold AND ", SearchListing.Lat, SearchListing.Lng);
        }
      }

      string sqlOr = "(";
      string AndOr = string.Empty;
      string proptype = "listings.PropertyType = ";
      List<bool> PropTypes = new List<bool> { input.Andelsbolig, input.Sommerhus, input.Lejlighed, input.Ejerlejlighed, input.Rækkehus, input.Villa, input.Andet };
      List<bool> PropTypeChecked = new List<bool>();
      foreach (var item in PropTypes)
      {
        if (item)
        {
          PropTypeChecked.Add(item);
        }
      }
      int count = PropTypeChecked.Count;

      if (input.Andelsbolig)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Andelsbolig\" " + AndOr;
        count--;
      }

      if (input.Villa)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Villa\" " + AndOr;
        count--;
      }

      if (input.Sommerhus)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Sommerhus\" " + AndOr;
        count--;
      }

      if (input.Lejlighed)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Lejlighed\" " + AndOr;
        count--;
      }

      if (input.Ejerlejlighed)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Ejerlejlighed\" " + AndOr;
        count--;
      }

      if (input.Rækkehus)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Rækkehus\" " + AndOr;
        count--;
      }

      if (input.Andet)
      {
        AndOr = getAndOr(count);
        sqlOr += proptype + "\"Andet\" " + AndOr;
        count--;
      }

      sqlOr += ") AND ";

      if (PropTypeChecked.Count != 0)
      {
        sql += sqlOr;
      }

      if (input.PriceSliderHigherValue > 0.0)
      {
        sql += System.String.Format("salesinfosold.Price >= {0} AND salesinfosold.Price <= {1} AND ", input.PriceSliderLowerValue, input.PriceSliderHigherValue);
      }

      if (input.SizeSliderHigherValue > 0.0)
      {
        sql += System.String.Format("listings.Size >= {0} AND listings.Size <= {1} AND ", input.SizeSliderLowerValue, input.SizeSliderHigherValue);
      }

      //if (input.DowntimeHigherValue > 0.0 && input.Sold)
      //{
      //  sql += System.String.Format("salesinfosold.SalesDate >= {0} AND salesinfosold.SalesDate <= {1} AND "); // input til salesdate plox!!!!
      //}

      if (input.SameRoad)
      {
        sql += System.String.Format("address.StreetName = \"{0}\" AND ", split[0].Trim(','));
      }

      if (input.SameZipCode)
      {
        sql += System.String.Format("address.AreaCode = {0} AND ", int.Parse(split[2]));
      }

      sql += System.String.Format("listings.NumberOfRooms >= {0} AND listings.NumberOfRooms <= {1} ",
          input.MinRoomCount, input.MaxRoomCount);

      if (input.AreaSliderLowerValue >= 0.0 && input.AreaSliderHigherValue > 0.0 && input.SameRoad == false && input.SameZipCode == false)
      {
        sql += System.String.Format("HAVING distance_in_m <= {0} ", input.AreaSliderHigherValue);
      }

      sql += "LIMIT 25";

      //throw new Exception(sql);
      return sql;
    }

    string getAndOr(int count)
    {
      if (count > 1)
      {
        return  "OR ";
      }
      else
      {
        return  string.Empty;
      }
    }

    public BindableCollection<Listing> getSelectedListings(BindableCollection<Listing> SearchResults)
    {
      BindableCollection<Listing> Results = new BindableCollection<Listing>();
      foreach (var Property in SearchResults)
      {
        if (Property.IsSelected)
        {
          Results.Add(Property);
        }
      }
      return Results;
    }

    double getEstPrice(BindableCollection<Listing> listings)
    {
      double totalPriceSqr = 0;
      foreach (var Property in listings)
      {
        totalPriceSqr += Property.PriceSqr;
      }
      return (totalPriceSqr / listings.Count);
    }
        #endregion
    }
}
