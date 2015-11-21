using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P3.Views
{
    /// <summary>
    /// Interaction logic for SearchScreenView.xaml
    /// </summary>
    public partial class SearchScreenView : UserControl
    {
        private int _errors = 0;
        public SearchScreenView()
        {
            InitializeComponent();
        }

        //dunno if dese make any difference, i think not. they can be used to make it so something cant/wont execute unless all fields are filled with valid input.
        private void Confirm_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _errors == 0;
            e.Handled = true;
        }
        private void Confirm_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                _errors++;
            }
            else
                _errors--;
        }
    }
}
