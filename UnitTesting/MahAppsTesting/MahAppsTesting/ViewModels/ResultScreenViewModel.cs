using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MahAppsTesting.ViewModels
{
    class ResultScreenViewModel : Screen
    {
        #region ctor

        public ResultScreenViewModel()
        {
            _searchResults = new BindableCollection<Listing>();
            SearchResults.Add(new Listing("Vesterbro", 4, 9000, "Aalborg", 5000000, 50, 1999));
        }
        #endregion
        #region Fields

        private BindableCollection<Listing> _searchResults;
        private Listing _selectedListing;

        #endregion

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

        public Listing SelectedListing
        {
            get { return _selectedListing; }
            set
            {
                _selectedListing = value;
                NotifyOfPropertyChange(() => SelectedListing);
            }
        }

        #endregion

    }
}
