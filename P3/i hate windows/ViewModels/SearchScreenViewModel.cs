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
using System.ComponentModel.Composition;

namespace P3.ViewModels
{
    [Export(typeof(SearchScreenViewModel))]
    class SearchScreenViewModel : Conductor<object>.Collection.OneActive
    {
        #region Fields

        private BindableCollection<SearchSettingModel> _savedSettingsCollection;
        private string Path;
        private Screen _resultScreen;
        private string _searchInput;
        //bind the individual setting buttons on the view to the properties of the below model. That will keep them always in sync, so when search button is clicked, you can just use this property. SearchSettings that is.
        private SearchSettingModel _searchSettings;
        private readonly IWindowManager _windowManager;

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

        [ImportingConstructor]
        public SearchScreenViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            Initialize();
        }

        #endregion

        #region Functions
        //Sets default values, and gets old searches.
        private void Initialize()
        {
            //Initialize different values here, to what their default should be on the UI
            PriceSliderLowerValue = 0;
            PriceSliderHigherValue = 800000;
            SizeSliderLowerValue = 10;
            SizeSliderHigherValue = 50;
            AreaSliderLowerValue = 100;
            AreaSliderHigherValue = 200;
            DowntimeLowerValue = 0;
            DowntimeHigherValue = 12;


            
            Path = GetPath();
            //Når GetSearchSettings er lavet, så uncomment det her, og det burde virke. Der er et sted mere hvor der skal uncommentes.
            //Remind to make functionality so that no more than 10 saved settings are stored at a time.
            //SavedSettingsCollection = GetSearchSettings();
        }

        //This function is supposed to look in a subfolder of the root folder (using the getpath function), find a .csv with the 10 most recent searches, 
        //and read those into the program, to be stored in PreviousSearches, which in turn will populate the SavedSettingsCollection when it is needed. 
        //The SearchSettings object is bound to the ui with different databindings, and will always contain either the default values of the different parameters, 
        //Or the values currently choosen by the user.
        private BindableCollection<SearchSettingModel> GetSearchSettings()
        {
            //Så det du skal gøre heri, er at lave en funktion der kan læse .csv filen i mappe PreviousSearches, og så gemme det den finder i PreviousSearches.
            //Hvis du er i tvivl om hvordan man gør, så google det, eller kig i nogen af de gamle eksamensopgaver vi har lavet. Vi har haft et projekt både i c og csharp hvor der var 
            //delopgaver der var det her på en prik :)
            BindableCollection<SearchSettingModel> PreviousSearches = new BindableCollection<SearchSettingModel>();
            //vi skal scanne data mappen i /p3/data for config filen, og så adde en til den collection lige oven over for hver vi finder.
            using (var sr = new StreamReader(File.OpenRead(Path) + "", Encoding.Default))
            {

            }

            return PreviousSearches;
        }

        //This is supposed to save the current search settings to the SavedSettingsCollection
        private void SaveSearchSettings()
        {
            //SavedSettingsCollection.Add(SearchSettings);
        }
        //Gets the file path of the current directory. Might need to modify this with appendices if you want subfolders or sumthin.
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
            BindableCollection<Listing> ResultsReturned;
            //Call and run query functions here
            //SearchSettings propertien indeholder de valgte settings.



            ResultsReturned = new BindableCollection<Listing>();
            ResultScreen = new ResultScreenViewModel(ResultsReturned, _windowManager);
            SaveSearchSettings();
        }
        #endregion

        #region SearchWindowProperties
        //if you want to access or set a value somewhere else do it here, like in this region and the one below. NotifyOfPropertyChange takes care of updating the view with the new values when something is set.
        private double _priceSliderLowerValue;
        private double _priceSliderHigherValue;
        private double _areaSliderLowerValue;
        private double _areaSliderHigherValue;
        private double _sizeSliderLowerValue;
        private double _sizeSliderHigherValue;
        private double _DowntimeLowerValue;
        private double _DowntimeHigherValue;
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

        internal SearchSettingModel SearchSettings
        {
            get
            {
                return _searchSettings;
            }

            set
            {
                _searchSettings = value;
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
            }
        }
        #endregion
    }
}
