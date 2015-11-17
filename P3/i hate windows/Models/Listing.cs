using System;
using Caliburn.Micro;

namespace P3.Models
{
  public class Listing : PropertyChangedBase
  {
    #region Ctors
        public Listing(int id, string streetName, string houseNumber, int areaCode, string propertyType, int size, int numberOfRooms, int yearBuilt, int price, int priceSqr, int demurrage)
        {
            ID = id;
            StreetName = streetName;
            AreaCode = areaCode;
            Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode);
            AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode);
            HouseNumber = houseNumber;
            PropertyType = propertyType;
            Size = size;
            NumberOfRooms = numberOfRooms;
            YearBuilt = yearBuilt;
            Price = price;
            PriceSqr = priceSqr;
            Demurrage = demurrage;
        }
        public Listing(int id, string streetName, string houseNumber, int areaCode, string propertyType, int size, int numberOfRooms, int yearBuilt, string salesType, int price, int priceSqr, DateTime salesDate)
        {
            ID = id;
            StreetName = streetName;
            AreaCode = areaCode;
            Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode);
            AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode);
            HouseNumber = houseNumber;
            PropertyType = propertyType;
            Size = size;
            NumberOfRooms = numberOfRooms;
            YearBuilt = yearBuilt;
            SalesType = salesType;
            Price = price;
            PriceSqr = priceSqr;
            SalesDate = salesDate;
        }

    private string _propertyType;
    private string _houseNumber;
    private int _price;
    private int _priceSqr;
    private bool _forSale;
    private int _size;
    private int _lieTime;
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

    private double _lat;
    private double _lng;

   private bool _IsSelected;



    public int ID
    {
      get { return _id; }
      set { _id = value; NotifyOfPropertyChange(); }
    }

    public string HouseNumber
    {
      get {return _houseNumber; }
      set {_houseNumber = value; NotifyOfPropertyChange(); }
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
      set { _areaCode = value; NotifyOfPropertyChange(); }
    }
    public string StreetName
    {
      get { return _streetName; }
      set { _streetName = value; NotifyOfPropertyChange(); }
    }
    public string Address
    {
      get { return _address; }
      private set { _address = value; NotifyOfPropertyChange(); }
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
    public int LieTime
    {
        get
        {
            return _lieTime;
        }

        set
        {
            _lieTime = value;
            NotifyOfPropertyChange(() => LieTime);
        }
    }
    public bool ForSale
    {
        get
        {
            return _forSale;
        }

        set
        {
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
        #endregion
        #region Overrides
        public override string ToString()
    {
        return Address + ", " + AreaCode + ", " + Price + ", " + Size + ", " + YearBuilt;
    }
    #endregion
    }
}
