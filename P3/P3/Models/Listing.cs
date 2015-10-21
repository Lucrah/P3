using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3.Models;

namespace P3
{
  class Listing : BaseINPCModel
  {
    public Listing(string streetName, int houseNumber, int areaCode, string city)
    {
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city; 
      AddressForURL = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode) + "+" + city;
      ListingID = Guid.NewGuid();
    }
    public Listing(string streetName, int houseNumber, int areaCode, string city,  int priceOfHouse, int sizeOfHouse, int yearBuilt)
    {
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city; 
      AddressForURL = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode) + "+" + city; //used for GeoCode lookups.
      Price = priceOfHouse;
      Size = sizeOfHouse;
      YearBuilt = yearBuilt; 
      ListingID = Guid.NewGuid();
    }

    enum propertyType
    {
      Villa = 0,
      Fritidsbolig = 1,
      Lejlighed = 2,
      Rækkehus = 3,
      Landejendom = 4,
      Andelsbolig = 5                
    };

    #region property
    private Guid _listingID;
    public Guid ListingID
    {
      get { return _listingID; }
      set { _listingID = value; }
    }

    
    

    private double _lat;
    public double Lat
    {
      get { return _lat; }
      set { _lat = value; RaisePropertyChanged(); }
    }
    private double _lng;
    public double Lng
    {
      get { return _lng; }
      set { _lng = value; RaisePropertyChanged(); }
    }
    private int _areaCode;

    public int AreaCode
    {
      get { return _areaCode; }
      set { _areaCode = value; RaisePropertyChanged();}
    }

    
    private string _streetName;

    public string StreetName
    {
      get { return _streetName; }
      set { _streetName = value; RaisePropertyChanged();}
    }

    private string _address;

    public string Address
    {
      get { return _address; }
      private set { _address = value; RaisePropertyChanged();}
    }

    private string _addressForURL;

    public string AddressForURL
    {
      get { return _addressForURL; }
      private set { _addressForURL = value; RaisePropertyChanged(); }
    }
    
    private int _price;

    public int Price
    {
      get { return _price; }
      private set { _price = value; RaisePropertyChanged(); }
    }
    
    private int _size;

    public int Size
    {
      get { return _size; }
      private set { _size = value; RaisePropertyChanged(); }
    }

    private int _yearBuilt;

    public int YearBuilt
    {
      get { return _yearBuilt; }
      set { _yearBuilt = value; RaisePropertyChanged(); }
    }

#endregion 


    public void GetGeoCode(double[] a)
    {
      Lat = a[0];
      Lng = a[1];
    }

  }
}
