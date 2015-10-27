using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Dynamic;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.Hosting;
using Caliburn.Micro;
using P3.Interfaces;

namespace P3.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<object>, IShell
    {
        #region Fields 
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;
        #endregion
        #region Ctor/s
        //This is just used to gain a reference to the eventAggregator in the bootstrapper. We can then use this to publish events on the right thread, or something like that.
        [ImportingConstructor]
        public ShellViewModel(IWindowManager windowManager)
        {
          _windowManager = windowManager;
        }
        //[ImportingConstructor]
        //public ShellViewModel(IEventAggregator eventAggregator,IWindowManager windowManager)
        //{
        //    _eventAggregator = eventAggregator;
        //    _windowManager = windowManager;
        //    //This is how you publish an event:
        //}
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

        public void ToggleFullScreen()
        {
          //Trying to pass in settings to the window
          dynamic settings = new ExpandoObject();
            if (settings.WindowState == WindowState.Maximized)
            {
                settings.WindowStyle = WindowStyle.SingleBorderWindow;
                settings.WindowState = WindowState.Normal;
            }
            else
            {
                settings.WindowStyle = WindowStyle.None;
                settings.WindowState = WindowState.Maximized;
            }
            _windowManager.ShowWindow(new ShellViewModel(_windowManager), null, settings);
        }
    }
}
