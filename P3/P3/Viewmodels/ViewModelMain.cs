using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using P3.Models;
using P3.Helpers;
using P3.Views;

namespace P3.Viewmodels
{
    class ViewModelMain : ViewModelBase
    {
        #region ICommand and Relay
        private RelayCommand _GotoDummyWindowCommand;

        public ICommand GotoDummyWindowCommand
        {
            get
            {
                if (_GotoDummyWindowCommand == null)
                {
                    _GotoDummyWindowCommand = new RelayCommand(param => this.GotoDummyWindow());
                }
                return _GotoDummyWindowCommand;
            }
        }

        #endregion
        private void GotoDummyWindow()
        {
            var win = new DummyView();
            win.Show();
            CloseTrigger = true;
        }
    }
}
