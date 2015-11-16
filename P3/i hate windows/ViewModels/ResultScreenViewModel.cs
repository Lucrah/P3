using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;
using System.ComponentModel.Composition;

namespace P3.ViewModels
{
    [Export(typeof(ResultScreenViewModel))]
    class ResultScreenViewModel : Screen
    {
        #region ctor
        [ImportingConstructor]
        public ResultScreenViewModel(BindableCollection<Listing> ReturnedSearchResults, IWindowManager windowManager)
        {
            _windowManager = windowManager;
            ReturnedSearchResults = _searchResults;
            if (SearchResults != null)
            {
                SelectedSearchResult = SearchResults[0];
            }

        }
        #endregion
        #region Fields
        //Store returned SearchResults in this, Clear it before every new search
        private BindableCollection<Listing> _searchResults;
        //Represents the selected SearchResult. Bound in the listview, do not rename or anything like that. 
        private Listing _selectedSearchResult;

        //mef stuff, allows us to open new windows of this particular type easily
        private readonly IWindowManager _windowManager;

        #endregion

        public void ShowPropertyInfoNewWindow(Listing Property)
        {
            _windowManager.ShowWindow(new PropertyInfoViewModel(Property, _windowManager));
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

        public void ShowPropertyInfo(Listing SelectedItem)
        {
            //Activate some kind of new window? or maybe make a flyout
            //Maybe make this class a conductor and do it like that?
        }

        #endregion

    }
}
