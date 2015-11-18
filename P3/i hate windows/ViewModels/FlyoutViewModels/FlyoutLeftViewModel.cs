using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro;
using Caliburn.Micro;
using i_hate_windows.Helpers;
using P3.Models;

namespace i_hate_windows.ViewModels.FlyoutViewModels
{
    class FlyoutLeftViewModel : Screen
    {
        private IEventAggregator _eventaggregator;
        private Listing _selectedItem;
        public FlyoutLeftViewModel(IEventAggregator iEventAggregator)
        {
            _eventaggregator = iEventAggregator;
        }

        public Listing SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
            }
        }

        public void Handle(OpenFlyoutMessage message)
        {
            SelectedItem = message.SelectedListing;
        }
    }
}
