using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;

using Caliburn.Micro;

namespace P3.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        public void ShowGraphScreen()
        {
            ActivateItem(new GraphScreenViewModel());
        }
        public void ShowPropertyInfo()
        {
            ActivateItem(new PropertyInfoViewModel());
        }
        public void ShowResultScreen()
        {
            ActivateItem(new ResultScreenViewModel());
        }
        public void ShowSearchScreen()
        {
            ActivateItem(new SearchScreenViewModel());
        }
        public void ToggleFullScreen(Window window)
        {
            
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowStyle = WindowStyle.SingleBorderWindow;
                window.WindowState = WindowState.Normal;
            }
            else
            {
                window.WindowStyle = WindowStyle.None;
                window.WindowState = WindowState.Maximized;
            }
        }
    }
}
