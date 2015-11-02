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
