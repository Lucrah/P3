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
    class ShellViewModel : Conductor<object>, IViewAware
    {
        #region Fields 
        private readonly IEventAggregator _eventAggregator;
        #endregion
        #region Ctor/s
        //This is just used to gain a reference to the eventAggregator in the bootstrapper. We can then use this to publish events on the right thread, or something like that.
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            //This is how you publish an event.

        }
        #endregion
        #region NavigateFunctions
        /*Shows how to display an item(in this case a usercontrol)
         *you then do something like this on a button:
         * <Button x:Name="ShowResultScreen" Content="ResultScreen" Height="29.5" VerticalAlignment="Top" Width="96"/>
         * And really, this can be used to bind any function to any button/other control.
         * */
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
        #endregion

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
