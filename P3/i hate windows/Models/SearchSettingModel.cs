using System;
using Caliburn.Micro;

namespace P3.Models
{
    class SearchSettingModel : PropertyChangedBase
    {
        public SearchSettingModel()
        {
            //Initial values for the searchSettings here. Moved from searchscreenviemodel to here bcs clarity and, bcs assemble all options 1 place.
            PriceSliderLowerValue = 0;
            PriceSliderHigherValue = 800000;
            SizeSliderLowerValue = 10;
            SizeSliderHigherValue = 50;
            AreaSliderLowerValue = 100;
            AreaSliderHigherValue = 200;
            DowntimeLowerValue = 0;
            DowntimeHigherValue = 12;
            Villa = true;
        }
        #region Fields

        //slider values
        private double _priceSliderLowerValue;
        private double _priceSliderHigherValue;

        private double _areaSliderLowerValue;
        
        private double _areaSliderHigherValue;
        private double _DowntimeLowerValue;
        private double _DowntimeHigherValue;
        private double _sizeSliderLowerValue;
        private double _sizeSliderHigherValue;

        private int _pricePrSqm;
        private int _yearBuilt;
        private int _roomCount;
        private int _propertySize;

        private bool _sold;
        private bool _forSale;
        private bool _sameRoad;
        private bool _sameZipCode;
        private bool _sameCity;

        private bool _villa;
        private bool _fritidsEjendom;
        private bool _liebhaverEjendom;
        private bool _andelsBolig;
        private bool _rækkehus;
        private bool _nedlagtLandbrug;

        private int _minPrKvm;
        private int _maxPrKvm;
        private int _minGroundSize;
        private int _maxGroundSize;
        #endregion

        #region Public
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
                NotifyOfPropertyChange(() => MinPrKvm);
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
                NotifyOfPropertyChange(() => MaxPrKvm);
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
                NotifyOfPropertyChange(() => MinGroundSize);
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
                NotifyOfPropertyChange(() => MaxGroundSize);
            }
        }

        public bool Villa
        {
            get
            {
                return _villa;
            }

            set
            {
                _villa = value;
                NotifyOfPropertyChange(() => Villa);
            }
        }

        public bool FritidsEjendom
        {
            get
            {
                return _fritidsEjendom;
            }

            set
            {
                _fritidsEjendom = value;
                NotifyOfPropertyChange(() => FritidsEjendom);
            }
        }

        public bool LiebhaverEjendom
        {
            get
            {
                return _liebhaverEjendom;
            }

            set
            {
                _liebhaverEjendom = value;
                NotifyOfPropertyChange(() => LiebhaverEjendom);
            }
        }

        public bool AndelsBolig
        {
            get
            {
                return _andelsBolig;
            }

            set
            {
                _andelsBolig = value;
                NotifyOfPropertyChange(() => AndelsBolig);
            }
        }

        public bool Rækkehus
        {
            get
            {
                return _rækkehus;
            }

            set
            {
                _rækkehus = value;
                NotifyOfPropertyChange(() => Rækkehus);
            }
        }

        public bool NedlagtLandbrug
        {
            get
            {
                return _nedlagtLandbrug;
            }

            set
            {
                _nedlagtLandbrug = value;
                NotifyOfPropertyChange(() => NedlagtLandbrug);
            }
        }

        public double PriceSliderLowerValue
        {
            get
            {
                return _priceSliderLowerValue;
            }

            set
            {
                _priceSliderLowerValue = value;
                NotifyOfPropertyChange(() => PriceSliderLowerValue);
            }
        }

        public double PriceSliderHigherValue
        {
            get
            {
                return _priceSliderHigherValue;
            }

            set
            {
                _priceSliderHigherValue = value;
                NotifyOfPropertyChange(() => PriceSliderHigherValue);
            }
        }

        public double AreaSliderLowerValue
        {
            get
            {
                return _areaSliderLowerValue;
            }

            set
            {
                _areaSliderLowerValue = value;
                NotifyOfPropertyChange(() => AreaSliderLowerValue);
            }
        }

        public double AreaSliderHigherValue
        {
            get
            {
                return _areaSliderHigherValue;
            }

            set
            {
                _areaSliderHigherValue = value;
                NotifyOfPropertyChange(() => AreaSliderHigherValue);
            }
        }

        public double SizeSliderLowerValue
        {
            get
            {
                return _sizeSliderLowerValue;
            }

            set
            {
                _sizeSliderLowerValue = value;
                NotifyOfPropertyChange(() => SizeSliderLowerValue);
            }
        }

        public double SizeSliderHigherValue
        {
            get
            {
                return _sizeSliderHigherValue;
            }

            set
            {
                _sizeSliderHigherValue = value;
                NotifyOfPropertyChange(() => SizeSliderHigherValue);
            }
        }

        public double DowntimeLowerValue
        {
            get
            {
                return _DowntimeLowerValue;
            }

            set
            {
                _DowntimeLowerValue = value;
                NotifyOfPropertyChange(() => DowntimeLowerValue);
            }
        }

        public double DowntimeHigherValue
        {
            get
            {
                return _DowntimeHigherValue;
            }

            set
            {
                _DowntimeHigherValue = value;
                NotifyOfPropertyChange(() => DowntimeHigherValue);
            }
        }

        #endregion


    }
}
