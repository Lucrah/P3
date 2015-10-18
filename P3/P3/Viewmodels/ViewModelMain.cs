using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using P3.Models;
using P3.Helpers;
using P3.Views;

namespace P3.Viewmodels
{
    class ViewModelMain : ViewModelBase
    {
        public RelayCommand GotoDummyWindowCommand{get; set;}
        public ViewModelMain()
        {
            GotoDummyWindowCommand = new RelayCommand(GotoDummyWindow, GotoDummyWindow_CanExecute);
        }

        bool GotoDummyWindow_CanExecute(object parameter)
        {
            return true;
        }
        private void GotoDummyWindow(object Parameter)
        {
            var win = new DummyView();
            win.Show();
            CloseWindow();
        }
    }
}
