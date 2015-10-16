using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

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
        internal void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //
        bool? _CloseWindowFlag;
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                RaisePropertyChanged("CloseWindowFlag");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null
                    ? true
                    : !CloseWindowFlag;
            }));
        }
    }
}
