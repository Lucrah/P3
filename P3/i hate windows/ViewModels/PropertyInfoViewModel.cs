using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using P3.Models;

namespace P3.ViewModels
{
    class PropertyInfoViewModel : Screen
    {
        public PropertyInfoViewModel(Listing ls)
        {
            _propertyToShow = ls;
        }
        private Listing _propertyToShow;

        public Listing PropertyToShow
        {
            get
            {
                return _propertyToShow;
            }

            set
            {
                _propertyToShow = value;
                NotifyOfPropertyChange(() => PropertyToShow);
            }
        }
    }
}
