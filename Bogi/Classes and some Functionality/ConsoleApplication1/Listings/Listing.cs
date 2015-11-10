using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  class Listing 
  {
    private static int id = 1;
    
    public Listing(string streetName, string houseNumber,int numberOfRooms, int areaCode,  int priceOfHouse, int sizeOfHouse, int yearBuilt, int sqrPrice, string propertyType)
    {
      ID = id;
      StreetName = streetName;
      HouseNumber = houseNumber;
      AreaCode = areaCode;
      Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode); 
      AddressForURL = streetName + "+" + Convert.ToString(houseNumber) + "+" + Convert.ToString(areaCode)+ "+" + "Denmark"; //used for GeoCode lookups.
      Price = priceOfHouse;
      Size = sizeOfHouse;
      YearBuilt = yearBuilt;
      Rooms = numberOfRooms;
      Sqrprice = sqrPrice;
      PropertyType = propertyType;
      id++;
    }
    #region property
    private string _propertyType;

    public string PropertyType
    {
      get { return _propertyType; }
      set { _propertyType = value; }
    }


    

    private int _rooms;

    public int Rooms
    {
        get { return _rooms; }
        set { _rooms = value; }
    }

    private int _sqrPrice;

    public int Sqrprice
    {
        get { return _sqrPrice; }
        set { _sqrPrice = value; }
    }

    private string _houseNumber;

    public string HouseNumber
    {
        get { return _houseNumber; }
        set { _houseNumber = value; }
    }

    private int _areaCode;

    public int AreaCode
    {
      get { return _areaCode; }
      set { _areaCode = value; }
    }
        private int _iD;

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
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
