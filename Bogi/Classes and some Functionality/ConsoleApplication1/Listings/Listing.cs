using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class Listing // lav om så listing er generel og hus/lejlighed/erhvervsejendom nedarver.(flyt antal værelser/badeværelser osv ind i nedarvende klasser)
  {
    public Listing(string streetName, int houseNumber, int areaCode, string city)
    {
      address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city; 
      addressforURL = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode) + "+" + city;
    }
    public Listing(string streetName, int houseNumber, int areaCode, string city,  int priceOfHouse, int sizeOfHouse, int yearBuilt)
    {
      address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city; //can be made to keep each part of the address in it's own prop.
      addressforURL = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode) + "+" + city; //used for GeoCode lookups.
      price = priceOfHouse;
      size = sizeOfHouse;
      yearbuilt = yearBuilt;
    }
    #region property
    private string Address;

    public string address
    {
      get { return Address; }
      private set { Address = value; }
    }

    private string AddressForURL;

    public string addressforURL
    {
      get { return AddressForURL; }
      private set { AddressForURL = value; }
    }
    
    private int Price;

    public int price
    {
      get { return Price; }
      private set { Price = value; }
    }
    
    private int Size;

    public int size
    {
      get { return Size; }
      private set { Size = value; }
    }

    private int YearBuilt;

    public int yearbuilt
    {
      get { return YearBuilt; }
      set { YearBuilt = value; }
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
