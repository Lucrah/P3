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

        public void PrintChoosen()
        {
            //implement pls
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

    }
}
