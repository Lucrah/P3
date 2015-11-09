using System;
using Caliburn.Micro;

namespace P3.Models
{
  public class Listing : PropertyChangedBase
  {
    #region Ctors
        public Listing(string streetName, int houseNumber, int areaCode, string city)
        {
            StreetName = streetName;
            AreaCode = areaCode;
            Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city;
            AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode) + "+" + city;
            ListingId = Guid.NewGuid();
            IsSelected = false;
        }
        public Listing(string streetName, int houseNumber, int areaCode, string city, int priceOfHouse, int sizeOfHouse, int yearBuilt)
        {
            StreetName = streetName;
            AreaCode = areaCode;
            Address = streetName + " " + Convert.ToString(houseNumber) + ", " + Convert.ToString(areaCode) + " " + city;
            AddressForUrl = streetName + "+" + Convert.ToString(houseNumber) + ",+" + Convert.ToString(areaCode) + "+" + city; //used for GeoCode lookups.
            Price = priceOfHouse;
            Size = sizeOfHouse;
            YearBuilt = yearBuilt;
            ListingId = Guid.NewGuid();
            IsSelected = true;
        }
        #endregion
    public enum PropertyTypeEnum
    {
      Villa = 0,
      Fritidsejendom = 1,
      Liebhaveejendom = 2,
      Andelsbolig = 3,
      Rækkehus = 4,
      NedlagtLandbrug = 5                  
    };
    #region property
    private PropertyTypeEnum _propertyType;
    private int _price;
    private bool _forSale;
    private int _size;
    private int _lieTime;
    private int _yearBuilt;
    private Guid _listingId;



    private int _areaCode;
    private string _streetName;
    private string _address;
    private string _addressForUrl;

    private double _lat;
    private double _lng;

   private bool _IsSelected;



    public Guid ListingId
    {
      get { return _listingId; }
      set { _listingId = value; NotifyOfPropertyChange(); }
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
    public PropertyTypeEnum PropertyType
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
