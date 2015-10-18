using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using P3.Models;
using P3.Helpers;

namespace P3.Viewmodels
{
    class DummyViewModel : ViewModelBase
    {
        public DummyModel Person { get; set; }


        public RelayCommand ExitCommand { get; set; }


        public DummyViewModel()
        {
            Person = new DummyModel();
            ExitCommand = new RelayCommand(ExitProgram);
        }

        private void ExitProgram(object Parameter)
        {
            Window windowToClose = Parameter as Window;
            windowToClose.Close();
        }

    }
}
