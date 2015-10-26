using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Caliburn.Micro;
using P3.ViewModels;

namespace P3
{
    class ApplicationBootStrapper : BootstrapperBase
    {
        public ApplicationBootStrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        #region MEF
        #endregion
    }
}
