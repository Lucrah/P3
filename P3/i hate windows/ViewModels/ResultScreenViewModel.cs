using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;
using System.ComponentModel.Composition;
using i_hate_windows.Helpers;

namespace P3.ViewModels
{
    [Export(typeof(ResultScreenViewModel))]
    class ResultScreenViewModel : Screen
    {
        #region ctor
        [ImportingConstructor]
        public ResultScreenViewModel(BindableCollection<Listing> ReturnedSearchResults, IWindowManager windowManager, IEventAggregator eventaggregator)
        {
            _windowManager = windowManager;
            SearchResults = ReturnedSearchResults;
            if (SearchResults != null)
            {
                SelectedSearchResult = SearchResults[0];
            }
            _eventAggregator = eventaggregator;


        }
        #endregion
        #region Fields
        //Store returned SearchResults in this, Clear it before every new search
        private BindableCollection<Listing> _searchResults;
        //Represents the selected SearchResult. Bound in the listview, do not rename or anything like that. 
        private Listing _selectedSearchResult;
        //mef stuff, allows us to open new windows of this particular type easily
        private readonly IWindowManager _windowManager;
        //EventAggregator, publish events to this to communicate between views.
        private IEventAggregator _eventAggregator;

        #endregion

        public void ShowPropertyInfoNewWindow()
        {
            _windowManager.ShowWindow(new PropertyInfoViewModel(SelectedSearchResult, _windowManager));
        }

        public void ShowPropertyInfoFlyout()
        {
            _eventAggregator.PublishOnUIThread(new OpenFlyoutMessage(true, SelectedSearchResult));
        }

        public void PrintChosen()
        {
            
        }

        #region Public fields

        //Has to be bindableCollection, del af caliburn
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
        //Jeg er rimelig sikker på at det her kan gøres bedre....med en form for selection based på input parameter hvor
        //den så skifter item.(input) ud med noget andet. Men jeg kunne ikke lige pt huske hvordan.
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
