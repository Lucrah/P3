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
using P3.Helpers;
using i_hate_windows.Helpers;

namespace P3.ViewModels
{
    [Export(typeof(SearchScreenViewModel))]
    class SearchScreenViewModel : Conductor<object>.Collection.OneActive
    {
        #region Fields that are not searchsettings
        Funktionality func = new Funktionality();

        private BindableCollection<SearchSettingModel> _savedSettingsCollection;
        private string Path;
        private Screen _resultScreen;
        private SearchSettingModel _searchSettings;
        private IEventAggregator _eventAggregator;
        private object graphResults;

        //mef stuff
        private readonly IWindowManager _windowManager;

        #endregion
        #region ctor/s

        [ImportingConstructor]
        public SearchScreenViewModel(IWindowManager windowManager, IEventAggregator eventaggregator)
        {
            _eventAggregator = eventaggregator;
            _windowManager = windowManager;
            Initialize();
            
        }

        #endregion

        #region Functions
        //Sets default values, and gets old searches.
        private void Initialize()
        {
            SearchSettings = new SearchSettingModel();
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

            ResultsReturned = func.StaticSearch();
            
            ResultScreen = new ResultScreenViewModel(ResultsReturned, _windowManager, _eventAggregator);
            SaveSearchSettings();
            PDFConverter pdfConverter = new PDFConverter(ResultsReturned, graphResults, DateTime.Now.ToString(), "resultandgraph");
            
            pdfConverter = null;
        }
        #endregion
        public SearchSettingModel SearchSettings
        {
            get
            {
                return _searchSettings;
            }

            private set
            {
                _searchSettings = value;
                NotifyOfPropertyChange(()=>SearchSettings);
            }
        }
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
    }
}
