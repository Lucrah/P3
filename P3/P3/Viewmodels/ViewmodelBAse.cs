using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using P3.Helpers;
using System.Windows.Interactivity;
using System.Runtime.CompilerServices;

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

        internal void RaisePropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;


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


    }
}
