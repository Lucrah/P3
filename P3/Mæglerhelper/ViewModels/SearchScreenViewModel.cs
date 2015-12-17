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
using P3.Helpers;
using P3.ViewModels;
using System.ComponentModel;

namespace P3.ViewModels
{
  [Export(typeof(SearchScreenViewModel))]
  class SearchScreenViewModel : Conductor<object>.Collection.OneActive, IHandle<BoolPropMsg>
  {
    #region Fields that are not searchsettings

    private BindableCollection<string> _savedSettingsCollection;
    private BindableCollection<Listing> ResultsReturned;
    private Funktionality fncy;
    private string Path;
    private Screen _resultScreen;
    private SearchSettingModel _searchSettings;
    private IEventAggregator _eventAggregator;
    private object graphResults;
    private bool _isPrintOpen = false;
    private bool _isSearching = false;
    private bool _canAnalyseOrPrint = false;
    private string _selectedSetting;
    private readonly IWindowManager _windowManager;

    #endregion
    #region ctor/s

    [ImportingConstructor]
    public SearchScreenViewModel(IWindowManager windowManager, IEventAggregator eventaggregator)
    {
      _eventAggregator = eventaggregator;
      _eventAggregator.Subscribe(this);
      _windowManager = windowManager;
      SavedSettingsCollection = ScanDirectory();
      Initialize();

    }

    #endregion

    #region Functions
    //Sets default values, and gets old searches.
    private void Initialize()
    {
      SearchSettings = new SearchSettingModel();
      Path = GetPath();
      
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
      
      BackgroundWorker bWorker = new BackgroundWorker();
      bWorker.DoWork += bWorker_doWork;
      bWorker.RunWorkerAsync();
    }

    private void bWorker_doWork(object sender, DoWorkEventArgs e)
    {
      IsSearching = true;
     
      fncy = new Funktionality(_windowManager);
      ResultsReturned = new BindableCollection<Listing>();

      ResultsReturned = fncy.SuperSearch(SearchSettings);

      //initiates the resultscreen, with the proper parts.
      ResultScreen = new ResultScreenViewModel(ResultsReturned, SearchSettings, _windowManager, _eventAggregator);
      //This saves the search history each time a search is made. It is then listed for convenience in the combobox in the view.
      SearchHistoryCreater();
      IsSearching = false;
    }

    public void Print()
    {
      if (!IsPrintOpen)
      {
        if (true)
        {
          _windowManager.ShowWindow(new PrintWindowViewModel(ResultsReturned, SearchSettings, graphResults, _eventAggregator));
          IsPrintOpen = true;
        }
      }
    }

    public void Analysis()
    {
      fncy = new Funktionality(_windowManager);
      BindableCollection<Listing> results = new BindableCollection<Listing>(fncy.getSelectedListings(ResultsReturned));
      double estprice = fncy.getEstPrice(results);
      _windowManager.ShowWindow(new GraphScreenViewModel(results, _windowManager, _searchSettings.SearchInput, estprice));
    }
    public void Handle(BoolPropMsg message)
    {
      if (message.Prop == "IsPrintOpen")
      {
        IsPrintOpen = message.Val;
      }
    }
    #endregion

    public bool CanAnalyseOrPrint
    {
      get
      {
        if (ResultsReturned != null)
        {
          _canAnalyseOrPrint = true;
        }
        else
        {
          _canAnalyseOrPrint = false;
        }
        return _canAnalyseOrPrint;
      }
      set { _canAnalyseOrPrint = value; NotifyOfPropertyChange(() => CanAnalyseOrPrint); }
    }
    public SearchSettingModel SearchSettings
    {
      get
      {
        return _searchSettings;
      }

      private set
      {
        _searchSettings = value;
        NotifyOfPropertyChange(() => SearchSettings);
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
    public BindableCollection<string> SavedSettingsCollection
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

    public bool IsSearching
    {
      get
      {
        return !_isSearching;
      }

      set
      {
        _isSearching = value;
        NotifyOfPropertyChange(() => IsSearching);
      }
    }

    public string SelectedSetting
    {
      get
      {
        return _selectedSetting;
      }

      set
      {
        _selectedSetting = value;
        NotifyOfPropertyChange(() => SelectedSetting);
      }
    }

    public void LoadSettings()
    {
      LoadFromFile(SelectedSetting);
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

        writer.WriteLine(Convert.ToString(SearchSettings.Villa));
        writer.WriteLine(Convert.ToString(SearchSettings.LiebhaverEjendom));
        writer.WriteLine(Convert.ToString(SearchSettings.FritidsEjendom));
        writer.WriteLine(Convert.ToString(SearchSettings.Andelsbolig));
        writer.WriteLine(Convert.ToString(SearchSettings.Rækkehus));
        writer.WriteLine(Convert.ToString(SearchSettings.NedlagtLandbrug));
        writer.WriteLine(Convert.ToString(SearchSettings.Lejlighed));
        writer.WriteLine(Convert.ToString(SearchSettings.Sommerhus));
        writer.WriteLine(Convert.ToString(SearchSettings.Andet));

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

    public void LoadFromFile(string historyFileName)
    {
      string historyFile = GetPath() + @"/History/" + historyFileName + ".csv";
      using (StreamReader reader = File.OpenText(historyFile))
      {
        SearchSettings.SearchInput = reader.ReadLine() ?? "";
        
        SearchSettings.Villa = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.LiebhaverEjendom = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.FritidsEjendom = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.Andelsbolig = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.Rækkehus = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.NedlagtLandbrug = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.Lejlighed = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.Sommerhus = Convert.ToBoolean(reader.ReadLine() ?? "");
        SearchSettings.Andet = Convert.ToBoolean(reader.ReadLine() ?? "");

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
