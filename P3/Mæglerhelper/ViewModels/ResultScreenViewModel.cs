using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;
using System.ComponentModel.Composition;
using P3.Helpers;

namespace P3.ViewModels
{
  [Export(typeof(ResultScreenViewModel))]
  class ResultScreenViewModel : Screen
  {
    #region ctor
    [ImportingConstructor]
    public ResultScreenViewModel(BindableCollection<Listing> ReturnedSearchResults, SearchSettingModel searchSettings, IWindowManager windowManager, IEventAggregator eventaggregator)
    {
      _windowManager = windowManager;
      SearchResults = ReturnedSearchResults;
      if (SearchResults != null && SearchResults.Count < 0)
      {
        SelectedSearchResult = SearchResults[0];
      }
      _eventAggregator = eventaggregator;
      _searchSettings = searchSettings;


    }
    #endregion
    #region Fields
    
    private BindableCollection<Listing> _searchResults;    
    private Listing _selectedSearchResult;   
    private readonly IWindowManager _windowManager;
    private IEventAggregator _eventAggregator;
    //The searchsettings, used for creating the pdf
    private SearchSettingModel _searchSettings;

    #endregion

    public void ShowPropertyInfoNewWindow()
    {
      _windowManager.ShowWindow(new PropertyInfoViewModel(SelectedSearchResult, _windowManager));
    }

    public void ShowPropertyInfoFlyout()
    {
      _eventAggregator.PublishOnUIThread(new IsFlyoutOpenMsg(true, SelectedSearchResult));
    }

    public void PrintChosen()
    {
      object graphresults = new object();
      PDFConverter pdfconv = new PDFConverter(SearchResults, _searchSettings, graphresults, DateTime.Now.ToString());
    }


    #region Public fields

    public BindableCollection<Listing> SearchResults
    {
      get { return _searchResults; }
      set
      {
        _searchResults = value;
        NotifyOfPropertyChange(() => SearchResults);
      }
    }

    public Listing SelectedSearchResult
    {
      get { return _selectedSearchResult; }
      set
      {
        _selectedSearchResult = value;
        NotifyOfPropertyChange(() => SelectedSearchResult);
      }
    }
    #endregion

    #region SortingMethods

    public void SortByAdress()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.Address).ToObservableCollection();
    }

    public void SortByHouseType()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.PropertyType).ToObservableCollection();
    }

    public void SortBySize()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.Size).ToObservableCollection();
    }

    public void SortByPrice()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.Price).ToObservableCollection();
    }

    public void SortByYearBuilt()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.YearBuilt).ToObservableCollection();
    }
    public void SortByDemurrage()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.Demurrage).ToObservableCollection();
    }
    public void SortByTown()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.Town).ToObservableCollection();
    }
    public void SortByForSale()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderBy(col => col.ForSale).ToObservableCollection();
    }
    public void SortByChosen()
    {
      SearchResults = (BindableCollection<Listing>)SearchResults.OrderByDescending(col => col.IsSelected).ToObservableCollection();
    }
    #endregion
  }
}
