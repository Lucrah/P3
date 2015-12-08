using P3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
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


        //When we want to make sure that some input is not text, bind this to the previewTextInput event in xaml.
        public static bool NumericOnly(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
        private void TextInputValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumericOnly(e.Text);
        }


        //It turned out to be way easier to do this in code behind rather than in the viewmodel, because of no support for deep property guard methods in caliburn. 
        private void CanSearch(object sender, TextChangedEventArgs e)
        {
          TextBox TxtB = sender as TextBox;
          GetResults.IsEnabled = true;
          string[] TxtBString = TxtB.Text.Split();

          if (string.IsNullOrEmpty(TxtB.Text))
          {
            GetResults.IsEnabled = false;
            return;
          }

          for (int i = 0; i < TxtB.Text.Split().Length - 2; ++i)
          {
            if (!Char.IsLetter(TxtBString[i][0]))
            {
              GetResults.IsEnabled = false;
              return;
            }
          }

          if (!Char.IsDigit(TxtBString[TxtB.Text.Split().Length - 2][0]))
          {
            GetResults.IsEnabled = false;
            return;
          }

          foreach (char ch in TxtBString[TxtB.Text.Split().Length-1])
          {
            if (!Char.IsDigit(ch))
              {
                GetResults.IsEnabled = false;
                return;
              }
          }
        }

        private void GetResults_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            advanced.IsEnabled = false;
            advanced.Visibility = Visibility.Hidden;
            OptionsGrid.IsEnabled = true;
            OptionsGrid.Visibility = Visibility.Visible;
        }

        private void SearchSettings_Andelsbolig_Copy_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
