using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using P3.Models;
using P3.Helpers;
using P3.Views;

namespace P3.Viewmodels
{ 
    class ViewModelMain : ViewModelBase , INotifyPropertyChanged
    {

      //Aggregation of the viewmodels
        private ViewModelSearchScreen VMSearch = new ViewModelSearchScreen();
        private ViewModelPropertyScreen VMProperty = new ViewModelPropertyScreen();
        private ViewModelResultScreen VMResultScreen = new ViewModelResultScreen();
        private ViewModelGraphScreen VMGraphScreen = new ViewModelGraphScreen();
        #region inpccurrentviewmodel
        #endregion
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

        private RelayCommand _ToggleFullscreenCommand;
        public ICommand ToggleFullScreenCommand
        {
            get
            {
                if (_ToggleFullscreenCommand == null)
                    _ToggleFullscreenCommand = new RelayCommand(param => this.togglefullscreencommand());
                return _ToggleFullscreenCommand;
            }
        }
        #endregion

        #region Actual UI logic
        private void togglefullscreencommand()
        {
                ToggleFullScreen = false;
                ToggleFullScreen = true;
        }
        private void GotoDummyWindow()
        {
            var win = new DummyView();
            win.Show();
            CloseTrigger = true;
        }
        #endregion
    }
}
