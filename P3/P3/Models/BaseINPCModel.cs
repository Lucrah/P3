using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace P3.Models
{
    class BaseINPCModel : INotifyPropertyChanged
    {
        #region INPC
        //This part needs to be implemented in all models, and viewmodels. Viewmodels inherit it from viewmodelbase though.
        internal void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
