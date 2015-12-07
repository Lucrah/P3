using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;

using MySql.Data.MySqlClient;
using System.ComponentModel.Composition;
using P3.Helpers;
using i_hate_windows.Helpers;
using i_hate_windows.ViewModels;

namespace P3.ViewModels
{
    [Export(typeof(SearchScreenViewModel))]
    class SearchScreenViewModel : Conductor<object>.Collection.OneActive, IHandle<BoolPropMsg>
    {
        #region Fields that are not searchsettings

        private BindableCollection<SearchSettingModel> _savedSettingsCollection;
        private BindableCollection<Listing> ResultsReturned;
        private string Path;
        private Screen _resultScreen;
        private SearchSettingModel _searchSettings;
        private IEventAggregator _eventAggregator;
        private object graphResults;
        private bool _isPrintOpen = false;

        //mef stuff
        private readonly IWindowManager _windowManager;

        #endregion
        #region ctor/s

        [ImportingConstructor]
        public SearchScreenViewModel(IWindowManager windowManager, IEventAggregator eventaggregator)
        {
            _eventAggregator = eventaggregator;
            _eventAggregator.Subscribe(this);
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
            Funktionality func = new Funktionality(_windowManager);
            //Call and run query functions here
            //SearchSettings propertien indeholder de valgte settings.
            ResultsReturned = new BindableCollection<Listing>();

            //this one is just a static search, no user input.
            //ResultsReturned = func.StaticSearch();

            //this one should take into account all user input
            //UN-comment once their stringbuilder is ready, until then, only staticsearch

            ResultsReturned = func.SuperSearch(SearchSettings);
            
            ResultScreen = new ResultScreenViewModel(ResultsReturned, SearchSettings, _windowManager, _eventAggregator);

            //Jeppes funktioner, responsible for saving the searchsettings to a .csv so you can view recent searches.
            SearchHistoryCreater();
        }

        public void Print()
        {
            if (!IsPrintOpen)
            {
                _windowManager.ShowWindow(new PrintWindowViewModel(ResultsReturned, SearchSettings, graphResults, _eventAggregator));
                //technically this should be a publishonuithread?
                IsPrintOpen = true;
            }
        }

        public void Handle(BoolPropMsg message)
        {
            if(message.Prop == "IsPrintOpen")
            {
                IsPrintOpen = message.Val;
            }
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
                NotifyOfPropertyChange(( )=> SearchSettings);
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

        public bool IsPrintOpen
        {
            get
            {
                return _isPrintOpen;
            }

            set
            {
                _isPrintOpen = value;
                NotifyOfPropertyChange(() => IsPrintOpen);
            }
        }

    public void SearchHistoryCreater()
    {
      string history = GetPath() + @"/History";


      if (!Directory.Exists(history))
      {
        Directory.CreateDirectory(history);
      }

      bool freeSpace = true;
      for (int i = 1; i <= 10; i++)
      {
        string historyFile = GetPath() + @"/History/" + i + @".csv";

        if (!File.Exists(historyFile))
        {
          WriteToFile(historyFile);
          freeSpace = true;
          break;
        }
        freeSpace = false;
      }

      if (!freeSpace)
      {
        File.Delete(GetPath() + @"/History/1.csv");
        string dir = GetPath() + @"/History/";
        for (int i = 1; i < 10; i++)
        {
          string oldFile = dir + (i + 1) + @".csv";
          string newFile = dir + i + @".csv";
          File.Move(oldFile, newFile);
        }

        SearchHistoryCreater();
      }
    }

    public void WriteToFile(string historyFile)
    {
      
      using (StreamWriter writer = File.CreateText(historyFile))
      {
        writer.WriteLine(SearchSettings.SearchInput ?? "");

        //Hustype laves når det er lavet om :))

        writer.WriteLine(Convert.ToString(SearchSettings.PriceSliderLowerValue) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.PriceSliderHigherValue) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.SizeSliderLowerValue) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.SizeSliderHigherValue) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.DowntimeLowerValue) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.DowntimeHigherValue) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.AreaSliderLowerValue) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.AreaSliderHigherValue) ?? "");

        writer.WriteLine(Convert.ToString(SearchSettings.MinPrKvm) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.MaxPrKvm) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.MinGroundSize) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.MaxGroundSize) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.MinYearBuilt) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.MaxYearBuilt) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.MinRoomCount) ?? "");
        writer.WriteLine(Convert.ToString(SearchSettings.MaxRoomCount) ?? "");

        writer.WriteLine(Convert.ToString(SearchSettings.Sold));
        writer.WriteLine(Convert.ToString(SearchSettings.ForSale));
        writer.WriteLine(Convert.ToString(SearchSettings.SameRoad));
        writer.WriteLine(Convert.ToString(SearchSettings.SameZipCode));
      }
    }

    public BindableCollection<string> ScanDirectory()
    {
      string history = GetPath() + @"/History";
      BindableCollection<string> filesFound = new BindableCollection<string>(Directory.GetFiles(history));

      for (int i = 0; i < filesFound.Count; i++)
      {
        filesFound[i] = filesFound[i].Replace(Directory.GetCurrentDirectory(), "");
        filesFound[i] = new DirectoryInfo(filesFound[i]).Name;
        filesFound[i] = filesFound[i].Replace(".csv", "");
      }

      return filesFound;
    }

    public void LoadFromFile()
    {
      string history = GetPath() + @"/History";
      using (StreamReader reader = File.OpenText(history))
      {
        SearchSettings.SearchInput = reader.ReadLine() ?? "";

        //Hustype laves når det lort er done

        SearchSettings.PriceSliderLowerValue = Convert.ToDouble(reader.ReadLine() ?? "");
        SearchSettings.PriceSliderHigherValue = Convert.ToDouble(reader.ReadLine() ?? "");
        SearchSettings.SizeSliderLowerValue = Convert.ToDouble(reader.ReadLine() ?? "");
        SearchSettings.SizeSliderHigherValue = Convert.ToDouble(reader.ReadLine() ?? "");
        SearchSettings.DowntimeLowerValue = Convert.ToDouble(reader.ReadLine() ?? "");
        SearchSettings.DowntimeHigherValue = Convert.ToDouble(reader.ReadLine() ?? "");
        SearchSettings.AreaSliderLowerValue = Convert.ToDouble(reader.ReadLine() ?? "");
        SearchSettings.AreaSliderHigherValue = Convert.ToDouble(reader.ReadLine() ?? "");


        SearchSettings.MinPrKvm = Convert.ToInt32(reader.ReadLine() ?? "");
        SearchSettings.MaxPrKvm = Convert.ToInt32(reader.ReadLine() ?? "");
        SearchSettings.MinGroundSize = Convert.ToInt32(reader.ReadLine() ?? "");
        SearchSettings.MaxGroundSize = Convert.ToInt32(reader.ReadLine() ?? "");
        SearchSettings.MinYearBuilt = Convert.ToInt32(reader.ReadLine() ?? "");
        SearchSettings.MaxYearBuilt = Convert.ToInt32(reader.ReadLine() ?? "");
        SearchSettings.MinRoomCount = Convert.ToInt32(reader.ReadLine() ?? "");
        SearchSettings.MaxRoomCount = Convert.ToInt32(reader.ReadLine() ?? "");

        SearchSettings.Sold = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.ForSale = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.SameRoad = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.SameZipCode = Convert.ToBoolean(reader.ReadLine() ?? "");


      }
    }
  }
}
