using System;
using Caliburn.Micro;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace P3.Models
{
    class SearchSettingModel : PropertyChangedBase, IDataErrorInfo
    {
        public SearchSettingModel()
        {
        }

        #region Fields / GetSet
        //NOTE: When trying to bind to these in the views, remember to bind to the public part.

        //SliderValues
        private double _priceSliderLowerValue = 0;
        private double _priceSliderHigherValue = 800000;        
        private double _areaSliderLowerValue = 100;//Radius around the address on which the search will be based, not the size of the property or the house itself.
        private double _areaSliderHigherValue = 200;
        private double _downtimeLowerValue = 0;
        private double _downtimeHigherValue = 500;
        private double _sizeSliderLowerValue = 10;
        private double _sizeSliderHigherValue = 50;

        //CheckboxValues
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
        private bool _lejlighed;
        private bool _sommerhus;
        private bool _andet;

        //Bottom values in SearchView
        private int _minPrKvm = 0;
        private int _maxPrKvm = 1000;
        private int _minYearBuilt = 1950;
        private int _maxYearBuilt = DateTime.Now.Year;
        private int _minRoomCount = 0;
        private int _maxRoomCount = 100;
        private int _minGroundSize = 0;
        private int _maxGroundSize = 100;

        private string _searchInput;
        #endregion

        #region Public

        public int MinYearBuilt
        {
            get { return _minYearBuilt; }
            set
            {
                _minYearBuilt = value;
                NotifyOfPropertyChange(() => MinYearBuilt);
            }
        }
        public int MaxYearBuilt
        {
            get { return _maxYearBuilt; }
            set
            {
                _maxYearBuilt = value;
                NotifyOfPropertyChange(() => MaxYearBuilt);
            }
        }

        public int MinRoomCount
        {
            get { return _minRoomCount; }
            set
            {
                _minRoomCount = value;
                NotifyOfPropertyChange(() => MinRoomCount);
            }
        }
        public int MaxRoomCount
        {
            get { return _maxRoomCount; }
            set
            {
                _maxRoomCount = value;
                NotifyOfPropertyChange(() => MaxRoomCount);
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
                if (value > 0 && value > MinPrKvm)
                {
                    _maxPrKvm = value;
                    NotifyOfPropertyChange(() => MaxPrKvm);
                }

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
        public bool Andelsbolig
        {
            get
            {
                return _andelsBolig;
            }

            set
            {
                _andelsBolig = value;
                NotifyOfPropertyChange(() => Andelsbolig);
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
        public bool Lejlighed
        {
            get { return _lejlighed; }
            set
            {
                _lejlighed = value;
                NotifyOfPropertyChange(() => Lejlighed);
            }
        }
        public bool Sommerhus
        {
            get
            {
                return _sommerhus;
            }

            set
            {
                _sommerhus = value;
                NotifyOfPropertyChange(() => Sommerhus);
            }
        }
        public bool Andet
        {
            get
            {
                return _andet;
            }

            set
            {
                _andet = value;
                NotifyOfPropertyChange(() => Andet);
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
                return _downtimeLowerValue;
            }

            set
            {
                _downtimeLowerValue = value;
                NotifyOfPropertyChange(() => DowntimeLowerValue);
            }
        }
        public double DowntimeHigherValue
        {
            get
            {
                return _downtimeHigherValue;
            }

            set
            {
                _downtimeHigherValue = value;
                NotifyOfPropertyChange(() => DowntimeHigherValue);
            }
        }

        public string SearchInput
        {
            get
            {
                return _searchInput;
            }

            set
            {
                _searchInput = value;
                NotifyOfPropertyChange(() => SearchInput);
            }
        }
        #endregion

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                string ToolTipErrorInfo = null;
                switch (columnName)
                {
                    case "SearchInput":
                        if (string.IsNullOrEmpty(SearchInput) ||  SearchInput.Split().Length > 3)
                        {
                            ToolTipErrorInfo = "Indtast søgning: adresse, husnr, postnr";
                            
                        }
                        break;
                    case "PriceSliderLowerValue":
                        if (PriceSliderLowerValue < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (PriceSliderLowerValue > PriceSliderHigherValue)
                        {
                            ToolTipErrorInfo = "Input skal være under " + PriceSliderHigherValue;
                            break;
                        }
                        break;
                    case "PriceSliderHigherValue":
                        if (PriceSliderHigherValue < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (PriceSliderHigherValue < PriceSliderLowerValue)
                        {
                            ToolTipErrorInfo = "Input skal være over " + PriceSliderLowerValue;
                            break;
                        }
                        break;
                    case "AreaSliderLowerValue":
                        if (AreaSliderLowerValue < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (AreaSliderLowerValue > AreaSliderHigherValue)
                        {
                            ToolTipErrorInfo = "Input skal være under " + AreaSliderHigherValue;
                            break;
                        }
                        break;
                    case "AreaSliderHigherValue":
                        if (AreaSliderHigherValue < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (AreaSliderHigherValue < AreaSliderLowerValue)
                        {
                            ToolTipErrorInfo = "Input skal være over " + AreaSliderLowerValue;
                            break;
                        }
                        break;
                    case "DowntimeLowerValue":
                        if (DowntimeLowerValue < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (DowntimeLowerValue > DowntimeHigherValue)
                        {
                            ToolTipErrorInfo = "Input skal være under " + DowntimeHigherValue;
                            break;
                        }
                        break;
                    case "DowntimeHigherValue":
                        if (DowntimeHigherValue < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (DowntimeHigherValue < DowntimeLowerValue)
                        {
                            ToolTipErrorInfo = "Input skal være over " + DowntimeLowerValue;
                            break;
                        }
                        break;
                    case "MinPrKvm":
                        if (MinPrKvm < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MinPrKvm > MaxPrKvm)
                        {
                            ToolTipErrorInfo = "Input skal være under " + MaxPrKvm;
                            break;
                        }
                        break;
                    case "MaxPrKvm":
                        if (MinPrKvm < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MaxPrKvm < MinPrKvm)
                        {
                            ToolTipErrorInfo = "Input skal være over " + MinPrKvm;
                            break;
                        }
                        break;
                    case "MinYearBuilt":
                        if (MinYearBuilt < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MinYearBuilt > MaxYearBuilt)
                        {
                            ToolTipErrorInfo = "Input skal være under " + MaxYearBuilt;
                            break;
                        }
                        break;
                    case "MaxYearBuilt":
                        if (MaxYearBuilt < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MaxYearBuilt < MinYearBuilt)
                        {
                            ToolTipErrorInfo = "Input skal være over " + MinYearBuilt;
                            break;
                        }
                        break;
                    case "MinRoomCount":
                        if (MinRoomCount < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MinRoomCount > MaxRoomCount)
                        {
                            ToolTipErrorInfo = "Input skal være under " + MaxRoomCount;
                            break;
                        }
                        break;
                    case "MaxRoomCount":
                        if (MaxRoomCount < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MaxRoomCount < MinRoomCount)
                        {
                            ToolTipErrorInfo = "Input skal være over " + MinRoomCount;
                            break;
                        }
                        break;
                    case "MinGroundSize":
                        if (MinGroundSize < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MinGroundSize > MaxGroundSize)
                        {
                            ToolTipErrorInfo = "Input skal være under " + MaxGroundSize;
                            break;
                        }
                        break;
                    case "MaxGroundSize":
                        if (MaxGroundSize < 0)
                        {
                            ToolTipErrorInfo = "Input skal være over nul.";
                            break;
                        }
                        if (MaxGroundSize < MinGroundSize)
                        {
                            ToolTipErrorInfo = "Input skal være over " + MinGroundSize;
                            break;
                        }
                        break;
                    default:
                        //DO NOT MAKE DEFAULT CASE, IT BREAKS THE WRING INPUT TOOLTIP FOR SOME REASON
                        break;
                }
                return ToolTipErrorInfo;
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        public static bool IsValidStreetAddress(string address)
        {
            const string exp = @"\d{1,3}.?\d{0,3}\s[a-zA-Z]{2,30}\s[a-zA-Z]{2,15}";
            var regex = new Regex(exp);
            return regex.IsMatch(address);
        }

    }
}
