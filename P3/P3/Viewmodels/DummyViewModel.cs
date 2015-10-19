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
    class DummyViewModel : ViewModelBase
    {
        private int _Age;
        public int Age
        {
            get { return _Age; }
            set { _Age = value; RaisePropertyChanged(); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged();
                }
            }
        }
        private AccessLevel _userAccessLevel;
        public AccessLevel UserAccessLevel
        {
            get { return _userAccessLevel; }
            set
            {
                if (_userAccessLevel != value)
                {
                    _userAccessLevel = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DummyViewModel()
        {
            Age = 20;
            Name = "gert";
            UserAccessLevel = 0;
        }
    }
}
