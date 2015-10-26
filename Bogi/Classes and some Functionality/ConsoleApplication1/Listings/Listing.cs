using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class Listing 
  {
    public Listing(string streetName, string houseNumber, int areaCode)
    {
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode); 
      AddressForURL = streetName + "+" + Convert.ToString(houseNumber) + "+" + Convert.ToString(areaCode);
    }
    public Listing(string streetName, string houseNumber, int areaCode,  int priceOfHouse, int sizeOfHouse, int yearBuilt, DateTime salesDate)
    {
      StreetName = streetName;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode); 
      AddressForURL = streetName + "+" + Convert.ToString(houseNumber) + "+" + Convert.ToString(areaCode); //used for GeoCode lookups.
      Price = priceOfHouse;
      Size = sizeOfHouse;
      YearBuilt = yearBuilt;
      salesDate = SalesDate;
    }
    #region property
    private DateTime _salesDate;

    public DateTime SalesDate
    {
      get { return _salesDate; }
      set { _salesDate = value; }
    }


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

    private double _lat;

    public double Lat
    {
      get { return _lat; }
      set { _lat = value; }
    }

    private double _lng;

    public double Lng
    {
      get { return _lng; }
      set { _lng = value; }
    }

    #endregion


    public void GetGeoCode(double[] a)
    {
      Lat = a[0];
      Lng = a[1];
    }

  }
}
