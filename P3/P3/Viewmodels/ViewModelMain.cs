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
        private ViewModelSearchScreen _vmSearch = new ViewModelSearchScreen();
        private ViewModelPropertyScreen _vmProperty = new ViewModelPropertyScreen();
        private ViewModelResultScreen _vmResultScreen = new ViewModelResultScreen();
        private ViewModelGraphScreen _vmGraphScreen = new ViewModelGraphScreen();

        #region inpccurrentviewmodel
        private INotifyPropertyChanged _currentViewModel;
        public INotifyPropertyChanged CurrentViewModel
        {
          get { return _currentViewModel; }
          set
          {
            _currentViewModel = value;
            RaisePropertyChanged();
          }
        }

        public IEnumerable<INotifyPropertyChanged> ViewModelsToSwitch
        {
          get
          {
            return new INotifyPropertyChanged[]
                               {
                                   (INotifyPropertyChanged)_vmSearch,
                                   (INotifyPropertyChanged)_vmProperty,
                                   (INotifyPropertyChanged)_vmResultScreen,
                                   (INotifyPropertyChanged)_vmGraphScreen
                               };
          }
        }
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
