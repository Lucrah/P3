using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i_hate_windows.Helpers
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IOrderedEnumerable<T> col)
        {
            return new BindableCollection<T>(col);
        }
    }
}
