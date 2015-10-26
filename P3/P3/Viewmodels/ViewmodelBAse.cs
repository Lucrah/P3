using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using P3.Models;
using P3.Helpers;
using P3.Views;

namespace P3.Viewmodels
{
    class ViewModelBase : INotifyPropertyChanged
    {

        /*
         * Dont ever make a constructor in a viewmodel, it breaks the view - viewmodel connection, as it is only possible to do because a viemodel specifically have no constructor
         * Base for all viewmodels, implements INotifyPropertyChanged
         * If you were to use collections with INotifyPropertyChanged, use dispatcher, or the changes will not go through to the view. Something about it being of different threads i think.
         * Link to this: http://blogs.msdn.com/b/davidrickard/archive/2010/04/01/using-the-dispatcher-with-mvvm.aspx
         */
        //Holder for whatever Viewmodel we are currently using. The according view is automatically showed when the viewmodel is shifted.
        #region RPC
        //Implementation of InotifyPropertyChanged
        internal void RaisePropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Common behaviour
        //Commands  that are available for all windows, should be in here. 
        // Procedure: Make function in viewmodel,set property to true to trigger, bind function to control in xaml.
        internal bool closeTrigger;
        public bool CloseTrigger
        {
            get { return this.closeTrigger; }
            set
            {
                this.closeTrigger = value;
                RaisePropertyChanged();
            }
        }
        internal bool toggleFullScreen;
        public bool ToggleFullScreen
        {
            get { return this.toggleFullScreen; }
            set
            {
                this.toggleFullScreen = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
