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
        string _Age;
        public string Age
        {
            get { return _Age; }
            set { _Age = value; RaisePropertyChanged(); }
        }
    }
}
