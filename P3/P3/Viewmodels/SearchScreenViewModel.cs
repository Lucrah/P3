using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace P3.ViewModels
{
    class SearchScreenViewModel : Screen
    {

        #region SearchWindowProperties

        private double _priceSliderValue;
        private double _areaSliderValue;

        #endregion
        #region SearchWindowPublicProperties
        public double PriceSliderValue
        {
            get { return _priceSliderValue; }
            set
            {
                _priceSliderValue = value;
                NotifyOfPropertyChange(() => PriceSliderValue);
            }
        }

        public double AreaSliderValue
        {
            get { return _areaSliderValue; }
            set
            {
                _areaSliderValue = value;
                NotifyOfPropertyChange(() => AreaSliderValue);
            }
        }

        #endregion
    }
}
