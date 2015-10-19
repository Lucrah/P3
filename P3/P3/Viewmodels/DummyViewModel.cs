using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using P3.Models;
using P3.Helpers;

namespace P3.Viewmodels
{
    class DummyViewModel : ViewModelBase, ICloseableVM
    {
        public event EventHandler CloseWindowEvent;
        #region ICommand and Relay
        private RelayCommand _CloseWindowCommand;
        public ICommand CloseWindowCommand
        {
            get { if (_CloseWindowCommand == null) { _CloseWindowCommand = new RelayCommand(param => exit()); } return _CloseWindowCommand; }
        }

        #endregion
        void exit()
        {
            if (CloseWindowEvent != null)
                CloseWindowEvent(this, null);
        }
    }
}
