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

        private double _priceSliderValue;
        private double _areaSliderValue;
        private double _sizeSliderValue;
        #endregion
        #region SearchWindowPublicProperties
        public double PriceSliderValue
        {
            get { return _priceSliderValue; }
            set
            {
                _priceSliderValue = value;
                NotifyOfPropertyChange(() => PriceSliderValue);
            }
        }

        public double SizeSliderValue
        {
            get { return _sizeSliderValue; }
            set
            {
                _sizeSliderValue = value;
                NotifyOfPropertyChange(() => SizeSliderValue);
            }
        }

        public double AreaSliderValue
        {
            get { return _areaSliderValue; }
            set
            {
                _areaSliderValue = value;
                NotifyOfPropertyChange(() => AreaSliderValue);
            }
        }

        #endregion
    }
}
