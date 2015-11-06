using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;

namespace P3.ViewModels
{
    class ResultScreenViewModel : Screen
    {
        #region ctor

        public ResultScreenViewModel()
        {
            _searchResults = new BindableCollection<Listing>();
            SearchResults.Add(new Listing("Vesterbro", 53, 9000, "Aalborg", 5000, 50, 1999));
            SearchResults.Add(new Listing("Blegkilde Alle", 30, 9000, "Aalborg", 7000, 50, 1999));
        }
        #endregion
        #region Fields

        private BindableCollection<Listing> _searchResults;
        private Listing _selectedSearchResult;

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
