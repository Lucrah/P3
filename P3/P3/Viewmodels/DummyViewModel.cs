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
        public ObservableCollection<DummyModel> People { get; set; }

        object _selectedPerson;
        public object SelectedPerson
        {
            get { return _selectedPerson; }
            set {
                    if (_selectedPerson != value)
                    {
                        _selectedPerson = value;
                        RaisePropertyChanged();
                    }
                }
        }

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
            People = new ObservableCollection<DummyModel>
            {
                new DummyModel {Age = 20, Name = "Gert", UserAccessLevel = (AccessLevel)0},
                new DummyModel {Age = 20, Name = "Bent", UserAccessLevel = (AccessLevel)1},
                new DummyModel {Age = 20, Name = "Lars", UserAccessLevel = (AccessLevel)2},
                new DummyModel {Age = 20, Name = "Kurt", UserAccessLevel = (AccessLevel)3},
            };
        }
    }
}
