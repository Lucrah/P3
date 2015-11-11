using System;
using Caliburn.Micro;

namespace P3.Models
{
    class SearchSettingModel : PropertyChangedBase
    {
        #region Fields
        //skal rettes til med flere types i listing.cs
        private Listing.PropertyTypeEnum _propertyType;
        private int _price;
        private int _radius;
        private DateTime _downTime;
        //typer af størrelse? Lav converter options somewhere maybe contextmenu
        private int _houseSize;
        private int _pricePrSqm;
        private int _yearBuilt;
        private int _roomCount;
        private int _propertySize;

        private bool _sold;
        private bool _forSale;
        private bool _sameRoad;
        private bool _sameZipCode;
        private bool _sameCity;

        private int _minPrKvm;
        private int _maxPrKvm;
        private int _minGroundSize;
        private int _maxGroundSize;
        #endregion

        #region Public

        public Listing.PropertyTypeEnum PropertyType
        {
            get { return _propertyType; }
            set
            {
                _propertyType = value;
                NotifyOfPropertyChange(() => PropertyType);
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                NotifyOfPropertyChange(() => Radius);
            }
        }
        public DateTime DownTime
        {
            get { return _downTime; }
            set
            {
                _downTime = value;
                NotifyOfPropertyChange(() => DownTime);
            }
        }
        public int HouseSize
        {
            get { return _houseSize; }
            set
            {
                _houseSize = value;
                NotifyOfPropertyChange(() => HouseSize);
            }
        }
        public int PricePrSqm
        {
            get { return _pricePrSqm; }
            set
            {
                _pricePrSqm = value;
                NotifyOfPropertyChange(() => PricePrSqm);
            }
        }
        public int YearBuilt
        {
            get { return _yearBuilt; }
            set
            {
                _yearBuilt = value;
                NotifyOfPropertyChange(() => YearBuilt);
            }
        }
        public int RoomCount
        {
            get { return _roomCount; }
            set
            {
                _roomCount = value;
                NotifyOfPropertyChange(() => RoomCount);
            }
        }
        public int PropertySize
        {
            get { return _propertySize; }
            set
            {
                _propertySize = value;
                NotifyOfPropertyChange(() => PropertySize);
            }
        }
        public bool Sold
        {
            get { return _sold; }
            set
            {
                _sold = value;
                NotifyOfPropertyChange(() => Sold);
            }
        }
        public bool ForSale
        {
            get { return _forSale; }
            set
            {
                _forSale = value;
                NotifyOfPropertyChange(() => ForSale);
            }
        }
        public bool SameRoad
        {
            get { return _sameRoad; }
            set
            {
                _sameRoad = value;
                NotifyOfPropertyChange(() => SameRoad);
            }
        }
        public bool SameZipCode
        {
            get { return _sameZipCode; }
            set
            {
                _sameZipCode = value;
                NotifyOfPropertyChange(() => SameZipCode);
            }
        }
        public bool SameCity
        {
            get { return _sameCity; }
            set
            {
                _sameCity = value;
                NotifyOfPropertyChange(() => SameCity);
            }
        }

        public int MinPrKvm
        {
            get
            {
                return _minPrKvm;
            }

            set
            {
                _minPrKvm = value;
            }
        }

        public int MaxPrKvm
        {
            get
            {
                return _maxPrKvm;
            }

            set
            {
                _maxPrKvm = value;
            }
        }

        public int MinGroundSize
        {
            get
            {
                return _minGroundSize;
            }

            set
            {
                _minGroundSize = value;
            }
        }

        public int MaxGroundSize
        {
            get
            {
                return _maxGroundSize;
            }

            set
            {
                _maxGroundSize = value;
            }
        }

        #endregion


    }
}
