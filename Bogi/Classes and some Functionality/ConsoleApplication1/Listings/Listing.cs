using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class Listing 
  {
    public Listing(string streetName, int houseNumber, int areaCode, string city)
    {
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city; 
      AddressForURL = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode) + "+" + city;
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
    }
    #region property
    private int _areaCode;

    public int AreaCode
    {
      get { return _areaCode; }
      set { _areaCode = value; }
    }

    
    private string _streetName;

    public string StreetName
    {
      get { return _streetName; }
      set { _streetName = value; }
    }

    private string _address;

    public string Address
    {
      get { return _address; }
      private set { _address = value; }
    }

    private string _addressForURL;

    public string AddressForURL
    {
      get { return _addressForURL; }
      private set { _addressForURL = value; }
    }
    
    private int _price;

    public int Price
    {
      get { return _price; }
      private set { _price = value; }
    }
    
    private int _size;

    public int Size
    {
      get { return _size; }
      private set { _size = value; }
    }

    private int _yearBuilt;

    public int YearBuilt
    {
      get { return _yearBuilt; }
      set { _yearBuilt = value; }
    }

    public Coordinates coordinates = new Coordinates();
#endregion 


    public void GetGeoCode(double[] a)
    {
      coordinates.lat = a[0];
      coordinates.lng = a[1];
    }

  }
}
