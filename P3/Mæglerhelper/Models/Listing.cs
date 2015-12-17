using System;
using System.Diagnostics;
using Caliburn.Micro;
using System.ComponentModel;
using System.Windows.Documents;

namespace P3.Models
{
  public class Listing : PropertyChangedBase
  {
    #region Ctors
    public Listing(int id, string streetName, string houseNumber, int areaCode, string propertyType, int size, int numberOfRooms, int yearBuilt, int price, int priceSqr, DateTime forSaleDate)
    {
      ID = id;
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber);
      AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode);
      HouseNumber = houseNumber;
      PropertyType = propertyType;
      NumberOfRooms = numberOfRooms;
      YearBuilt = yearBuilt;
      Size = size;
      PriceSqr = priceSqr;
      Price = price;
      if (priceSqr == 0)
      {
        if (size != 0 && price != 0)
        {
          PriceSqr = price / size;
        }
      }
      Demurrage = (DateTime.Today - forSaleDate).Days;
      ForSaleDate = forSaleDate;
      Town = ZipCodeChecker(AreaCode);
    }
    public Listing(int id, string streetName, string houseNumber, int areaCode, string propertyType, int size, int numberOfRooms, int yearBuilt, string salesType, int price, int priceSqr, DateTime salesDate)
    {
      ID = id;
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber);
      AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode);
      HouseNumber = houseNumber;
      PropertyType = propertyType;
      Size = size;
      NumberOfRooms = numberOfRooms;
      YearBuilt = yearBuilt;
      SalesType = salesType;
      Price = price;
      PriceSqr = priceSqr;
      if (priceSqr == 0)
      {
        if (size != 0 && price != 0)
        {
          PriceSqr = price / size;
        }
      }
      SalesDate = salesDate;
      Town = ZipCodeChecker(AreaCode);
    }
    public Listing(int id, string streetName, string houseNumber, int areaCode, string propertyType, int size, int numberOfRooms, int yearBuilt, string salesType, int price, int priceSqr, DateTime salesDate, double distance_in_m)
    {
      ID = id;
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber);
      AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + "+" + Convert.ToString(areaCode) + "+Denmark";
      HouseNumber = houseNumber;
      PropertyType = propertyType;
      Size = size;
      NumberOfRooms = numberOfRooms;
      YearBuilt = yearBuilt;
      SalesType = salesType;
      Price = price;
      PriceSqr = priceSqr;
      if (priceSqr == 0)
      {
        if (size != 0 && price != 0)
        {
          PriceSqr = price / size;
        }
      }
      SalesDate = salesDate;
      Town = ZipCodeChecker(AreaCode);
    }
    public Listing(int id, string streetName, string houseNumber, int areaCode, string propertyType, int size, int numberOfRooms, int yearBuilt, int price, int priceSqr, DateTime forSaleDate, double distance_in_m)
    {
      ID = id;
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber);
      AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + "+" + Convert.ToString(areaCode) + "+Denmark";
      HouseNumber = houseNumber;
      PropertyType = propertyType;
      Size = size;
      NumberOfRooms = numberOfRooms;
      YearBuilt = yearBuilt;
      Price = price;
      PriceSqr = priceSqr;
      if (priceSqr == 0)
      {
        if (size != 0 && price != 0)
        {
          PriceSqr = price / size;
        }
      }
      Demurrage = (DateTime.Today - forSaleDate).Days;
      ForSaleDate = forSaleDate;
      Town = ZipCodeChecker(AreaCode);
    }
    public Listing(string streetName, string houseNumber, int areaCode)
    {
      StreetName = streetName;
      HouseNumber = houseNumber;
      AreaCode = areaCode;
      AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + "+" + Convert.ToString(areaCode) + "+Denmark";
    }

    private string _propertyType;
    private string _houseNumber;
    private int _price;
    private int _priceSqr;
    private bool _forSale;
    private bool _sold;
    private string _forSaleSold = "Ukendt";
    private int _size;
    private int _propertySize;
    private int _yearBuilt;
    private int _id;
    private int _numberOfRooms;
    private int _areaCode;
    private string _streetName;
    private string _address;
    private string _addressForUrl;
    private int _demurrage;
    private string _salesType;
    private DateTime _salesDate;
    private string _town;
    private DateTime _forSaleDate;

    private double _lat;
    private double _lng;

    private bool _IsSelected;

    private FlowDocument _comments;


    public int ID
    {
      get { return _id; }
      set { _id = value; NotifyOfPropertyChange(); }
    }

    public string HouseNumber
    {
      get { return _houseNumber; }
      set { _houseNumber = value; NotifyOfPropertyChange(); }
    }
    public double Lat
    {
      get { return _lat; }
      set { _lat = value; NotifyOfPropertyChange(); }
    }
    public double Lng
    {
      get { return _lng; }
      set { _lng = value; NotifyOfPropertyChange(); }
    }
    public int AreaCode
    {
      get { return _areaCode; }
      set
      {
        _areaCode = value;
        Town = ZipCodeChecker(AreaCode);
        NotifyOfPropertyChange(() => AreaCode);
      }
    }
    public string StreetName
    {
      get { return _streetName; }
      set { _streetName = value; NotifyOfPropertyChange(); }
    }
    public string Address
    {
      get { return _address; }
      set { _address = value; NotifyOfPropertyChange(); }
    }
    public string AddressForUrl
    {
      get { return _addressForUrl; }
      private set { _addressForUrl = value; NotifyOfPropertyChange(); }
    }
    public int Price
    {
      get { return _price; }
      private set { _price = value; NotifyOfPropertyChange(); }
    }
    public int PriceSqr
    {
      get { return _priceSqr; }
      set { _priceSqr = value; NotifyOfPropertyChange(); }
    }
    public int Size
    {
      get { return _size; }
      private set { _size = value; NotifyOfPropertyChange(); }
    }
    public int YearBuilt
    {
      get { return _yearBuilt; }
      set { _yearBuilt = value; NotifyOfPropertyChange(); }
    }
    public int NumberOfRooms
    {
      get { return _numberOfRooms; }
      set { _numberOfRooms = value; NotifyOfPropertyChange(); }
    }
    public int Demurrage
    {
      get { return _demurrage; }
      set { _demurrage = value; NotifyOfPropertyChange(); }
    }
    public string SalesType
    {
      get { return _salesType; }
      set { _salesType = value; NotifyOfPropertyChange(); }
    }
    public DateTime SalesDate
    {
      get { return _salesDate; }
      set { _salesDate = value; NotifyOfPropertyChange(); }
    }
    public string PropertyType
    {
      get
      {
        return _propertyType;
      }

      set
      {
        _propertyType = value;
        NotifyOfPropertyChange(() => PropertyType);
      }
    }

    public DateTime ForSaleDate
    {
      get { return _forSaleDate; }
      set { _forSaleDate = value; }
    }

    public bool ForSale
    {
      get
      {
        return _forSale;
      }

      set
      {
        if (value)
        {
          ForSaleSold = "Til Salg";
        }

        _forSale = value;
        NotifyOfPropertyChange(() => ForSale);
      }
    }


    public bool IsSelected
    {
      get
      {
        return _IsSelected;
      }

      set
      {
        _IsSelected = value;
        NotifyOfPropertyChange(() => IsSelected);
      }
    }

    public string Town
    {
      get
      {
        return _town;
      }

      set
      {
        _town = value;
        NotifyOfPropertyChange(() => Town);
      }
    }

    public int PropertySize
    {
      get
      {
        return _propertySize;
      }

      set
      {
        _propertySize = value;
        NotifyOfPropertyChange(() => PropertySize);
      }
    }

    public bool Sold
    {
      get
      {
        return _sold;
      }

      set
      {
        if (value)
        {
          ForSaleSold = "Solgt";
        }
        _sold = value;
        NotifyOfPropertyChange(() => Sold);
      }
    }

    public string ForSaleSold
    {
      get
      {
        return _forSaleSold;
      }

      set
      {
        _forSaleSold = value;
        NotifyOfPropertyChange(() => ForSaleSold);
      }
    }

    public FlowDocument Comments
    {
      get
      {
        return _comments;
      }

      set
      {
        _comments = value;
        NotifyOfPropertyChange(() => Comments);
      }
    }

    #endregion
    #region Overrides And other stuff
    public override string ToString()
    {
      return Address + ", " + AreaCode + ", " + Price + ", " + Size + ", " + YearBuilt;
    }
    #endregion

    public string ToPrintableString()
    {
      return Address + ", " + AreaCode + ", " + Size + ", " + Price + ", " + Demurrage + ", " + ForSaleSold + ", " +
             YearBuilt;
    }
    public string ZipCodeChecker(int zipCode)
    {
      string district = "";
      string[,] zipCodeMatrix = new string[19, 2]
      {
        {"Aalborg", "9000"}, {"Aalborg (Postboks)", "9100"}, {"Aalborg SV", "9200"}, {"Aalborg SØ", "9210"},
        {"Aalborg Øst", "9220"}, {"Svenstrup J", "9230"}, {"Nibe", "9240"}, {"Gistrup", "9260"},
        {"Klarup", "9270"}, {"Storvorde", "9280"}, {"Kongerslev", "9293"}, {"Vodskov", "9310"},
        {"Gandrup", "9362"}, {"Hals", "9370"}, {"Vestbjerg", "9380"}, {"Sulsted", "9381"}, {"Tylstrup", "9382"},
        {"Nørresundby", "9400"}, {"Vadum", "9430"}
      };
      for (int i = 0; i < 18; ++i)
      {
        if (zipCode.ToString() == zipCodeMatrix[i, 1])
        {
          district = zipCodeMatrix[i, 0];
          return district;
        }
      }
      district = "Ukendt";
      return district;
    }
  }


}
