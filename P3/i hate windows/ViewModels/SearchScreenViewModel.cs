using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;
using P3.ViewModels;
using MySql.Data.MySqlClient;

namespace P3.ViewModels
{
    class SearchScreenViewModel : Conductor<object>.Collection.OneActive
    {
        #region Fields

        private BindableCollection<SearchSettingModel> _savedSettingsCollection;
        private string Path;
        private Screen _resultScreen;

        #endregion
        #region Public 

        public Screen ResultScreen
        {
            get { return _resultScreen; }
            set
            {
                _resultScreen = value;
                NotifyOfPropertyChange(() => ResultScreen);
            }
        }
        public BindableCollection<SearchSettingModel> SavedSettingsCollection
        {
            get { return _savedSettingsCollection; }
            set
            {
                _savedSettingsCollection = value;
                NotifyOfPropertyChange(() => SavedSettingsCollection);
            }

        }

        

        #endregion

        #region ctor/s

        public SearchScreenViewModel()
        {
            Initialize();
        }

        #endregion

        #region Functions
        private void Initialize()
        {
            //Initialize different values here, to what their default should be on the UI
            PriceSliderLowerValue = 500000;
            PriceSliderHigherValue = 800000;
            SizeSliderLowerValue = 10;
            SizeSliderHigherValue = 50;
            AreaSliderLowerValue = 100;
            AreaSliderHigherValue = 200;


            
            Path = GetPath();
            //SavedSettingsCollection = GetSearchSettings();
        }
        private BindableCollection<SearchSettingModel> GetSearchSettings()
        {
            BindableCollection<SearchSettingModel> PreviousSearches = new BindableCollection<SearchSettingModel>();
            //vi skal scanne data mappen i /p3/data for config filen, og så adde en til den collection lige oven over for hver vi finder.
            using (var sr = new StreamReader(File.OpenRead(Path) + "", Encoding.Default))
            {

            }

            return PreviousSearches;
        }
        private string GetPath()
        {
            string rel_path = Directory.GetCurrentDirectory();
            string dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            dir_info = new DirectoryInfo(rel_path).Name;
            rel_path = rel_path.Replace(dir_info, "");
            var path = rel_path.Remove(rel_path.Length - 1) + @"Data\";
            return path;
        }

        public void GetResults()
        {
            ResultScreen = new ResultScreenViewModel();
        }

        private void QueryDB()
        {

        }
        #endregion

        #region SearchWindowProperties

        private double _priceSliderLowerValue;
        private double _priceSliderHigherValue;
        private double _areaSliderLowerValue;
        private double _areaSliderHigherValue;
        private double _sizeSliderLowerValue;
        private double _sizeSliderHigherValue;
        #endregion
        #region SearchWindowPublicProperties
        public double PriceSliderLowerValue
        {
            get { return _priceSliderLowerValue; }
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
            get { return _areaSliderLowerValue; }
            set
            {
                _areaSliderLowerValue = value;
                NotifyOfPropertyChange(() => AreaSliderLowerValue);
            }
        }

        public double AreaSliderHigherValue
        {
            get { return _areaSliderHigherValue; }
            set
            {
                _areaSliderHigherValue = value; 
                NotifyOfPropertyChange(() => AreaSliderHigherValue);
            }
        }

        public double SizeSliderLowerValue
        {
            get { return _sizeSliderLowerValue; }
            set
            {
                _sizeSliderLowerValue = value;
                NotifyOfPropertyChange(()=> SizeSliderLowerValue);
            }
        }

        public double SizeSliderHigherValue
        {
            get { return _sizeSliderHigherValue; }
            set
            {
                _sizeSliderHigherValue = value;
                NotifyOfPropertyChange(() => SizeSliderHigherValue);
            }
        }
        #endregion
    }
}
