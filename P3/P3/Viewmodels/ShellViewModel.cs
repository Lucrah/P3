using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
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
    public class ShellViewModel : Conductor<object>.Collection.OneActive, IShell
    {
        /*The Conductor class that this inherits from, is something that lets us activate items(in our case this is our usercontrols)
         * So, with this, we can bind the views controls to ActivateItem, which will then reflect whatever we set it to in the viewmodel. 
         * http://caliburnmicro.com/documentation/composition
         * We use this shellviewmodel class and the corresponding shellview as a base window to host our other windows.
         */
        #region Fields
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;
        #endregion

        #region MainWindowPropertyFields
        //if you wanted to make properties on the main window available here, make their backing fields here
        private WindowStyle _wStyle;
        private WindowState _wState;
        private int _wWidth;
        private int _wHeight;
        private ResizeMode _wRSize;
        #endregion

        #region MainWindowPropertyPublic
        //Public part of the MainWindowPropertyFields
        public ResizeMode WRSize
        {
            get { return _wRSize; }
            set
            {
                _wRSize = value;
                NotifyOfPropertyChange(() => WWidth);
            }
        }
        public int WWidth
        {
            get { return _wWidth; }
            set
            {
                _wWidth = value;
                NotifyOfPropertyChange(() => WWidth);
            }
        }
        public int WHeight
        {
            get { return _wHeight; }
            set
            {
                _wHeight = value;
                NotifyOfPropertyChange(() => WHeight);
            }
        }
        public WindowStyle WStyle
        {
            get { return _wStyle; }
            set
            {
                _wStyle = value;
                NotifyOfPropertyChange(() => WStyle);
            }
        }
        public WindowState WState
        {
            get { return _wState; }
            set
            {
                _wState = value;
                NotifyOfPropertyChange(() => WState);
            }
        }
        #endregion

        #region Ctor/s
        //This is just used to gain a reference to the eventAggregator in the bootstrapper. We can then use this to publish events on the right thread, or something like that.
        [ImportingConstructor]
        public ShellViewModel()
        {
            _windowManager = IoC.Get<IWindowManager>();
            _eventAggregator = IoC.Get<IEventAggregator>();
            WState = WindowState.Maximized;
            WStyle = WindowStyle.None;
            WRSize = ResizeMode.NoResize;
        }
        #endregion

        #region NavigateFunctions
        /*Shows how to display an item(in this case a usercontrol)
         *you then do something like this on a button:
         * <Button x:Name="ShowResultScreen" Content="ResultScreen" Height="29.5" VerticalAlignment="Top" Width="96"/>
         * And really, this can be used to bind any function to any button/other control.
         * This also shows the aforementioned ActivateItem. If i wanted to pass settings or something into the views it could be done here.
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

        #region Functionality

        public void Initialize()
        {

        }
        public void ToggleFullScreenF11(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if(keyArgs != null && keyArgs.Key == Key.F11)
            {
                if (WState == WindowState.Maximized)
                {
                    WState = WindowState.Normal;
                    WStyle = WindowStyle.ThreeDBorderWindow;
                    WRSize = ResizeMode.CanResize;
                    
                }
                else
                {
                    WStyle = WindowStyle.None;
                    WState = WindowState.Maximized;
                    WRSize = ResizeMode.NoResize;
                }
            }
        }
        #endregion
    }
}
