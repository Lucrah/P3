using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
