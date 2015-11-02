using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace P3.ViewModels
{
    class ResultScreenViewModel : Screen
    {
        #region ctor

        public ResultScreenViewModel()
        {
            SearchResults.Add(new Listing("Vesterbro", 4, 9000, "Aalborg", 5000000, 50, 1999));
        }
        #endregion
        #region Fields

        private BindableCollection<Listing> _searchResults;

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
        #endregion

    }
}
