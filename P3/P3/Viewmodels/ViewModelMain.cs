using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Interactivity;
using P3.Models;
using P3.Helpers;
using P3.Views;

namespace P3.Viewmodels
{ 
    class ViewModelMain : ViewModelBase , INotifyPropertyChanged
    {

        public ViewModelMain()
        {
            CurrentViewModel = new ViewModelSearchScreen();
        }
        private ViewModelBase _ViewModel;

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

        private RelayCommand _Initialization;
        public ICommand InitializationCommand
        {
            get
            {
                if (_Initialization == null)
                {
                    _Initialization = new RelayCommand(param => this.Initialization());
                }
                return _Initialization;
            }
        }

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
        #region Command Implementations / Actual UI Logic
        private void Togglefullscreen()
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
        private void Initialization()
        {
            //Maybe auto run of scripts to read from db here? Maybe it could be coupled up to our dropboxes. Maybe prompt user for database location. Maybe not, to emulate real life data shit.
            //Rasmus, call your shit in here.
        }
        #endregion
        #region WindowShiftingICommand
        private RelayCommand _DisplaySearchViewCommand;
        public ICommand DisplaySearchViewCommand
        {
            get
            {
                if (_DisplaySearchViewCommand == null)
                    _DisplaySearchViewCommand = new RelayCommand(param => CurrentViewModel = new ViewModelSearchScreen());
                return _DisplaySearchViewCommand;
            }
        }

        private RelayCommand _DisplayGraphViewCommand;
        public ICommand DisplayGraphViewCommand
        {
            get
            {
                if (_DisplayGraphViewCommand == null)
                    _DisplayGraphViewCommand = new RelayCommand(param => CurrentViewModel = new ViewModelGraphScreen());
                return _DisplayGraphViewCommand;
            }
        }
        private RelayCommand _DisplayPropertyViewCommand;
        public ICommand DisplayPropertyViewCommand
        {
            get
            {
                if (_DisplayPropertyViewCommand == null)
                    _DisplayPropertyViewCommand = new RelayCommand(param => CurrentViewModel = new ViewModelPropertyScreen());
                return _DisplayPropertyViewCommand;
            }
        }
        private RelayCommand _DisplayResultViewCommand;
        public ICommand DisplayResultViewCommand
        {
            get
            {
                if (_DisplayResultViewCommand == null)
                    _DisplayResultViewCommand = new RelayCommand(param => CurrentViewModel = new ViewModelResultScreen());
                return _DisplayResultViewCommand;
            }
        }
        #endregion



    }
}
