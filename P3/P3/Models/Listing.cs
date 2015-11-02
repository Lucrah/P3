using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace P3
{
  public class Listing : PropertyChangedBase
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

    public enum PropertyType
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
        set { _listingID = value; NotifyOfPropertyChange(); }
    }

    
    

    private double _lat;
    public double Lat
    {
      get { return _lat; }
        set { _lat = value; NotifyOfPropertyChange(); }
    }
    private double _lng;
    public double Lng
    {
      get { return _lng; }
        set { _lng = value; NotifyOfPropertyChange(); }
    }
    private int _areaCode;

    public int AreaCode
    {
      get { return _areaCode; }
        set { _areaCode = value; NotifyOfPropertyChange(); }
    }

    
    private string _streetName;

    public string StreetName
    {
      get { return _streetName; }
        set { _streetName = value; NotifyOfPropertyChange(); }
    }

    private string _address;

    public string Address
    {
      get { return _address; }
        private set { _address = value; NotifyOfPropertyChange(); }
    }

    private string _addressForURL;

    public string AddressForURL
    {
      get { return _addressForURL; }
        private set { _addressForURL = value; NotifyOfPropertyChange(); }
    }
    
    private int _price;

    public int Price
    {
      get { return _price; }
        private set { _price = value; NotifyOfPropertyChange(); }
    }
    
    private int _size;

    public int Size
    {
      get { return _size; }
        private set { _size = value; NotifyOfPropertyChange(); }
    }

    private int _yearBuilt;

    public int YearBuilt
    {
      get { return _yearBuilt; }
        set { _yearBuilt = value; NotifyOfPropertyChange(); }
    }

#endregion 


    public void GetGeoCode(double[] a)
    {
      Lat = a[0];
      Lng = a[1];
    }

  }
}
