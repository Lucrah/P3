using Caliburn.Micro;
using i_hate_windows.Helpers;
using MahApps.Metro.Controls;
using P3.Models;
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
    /// Interaction logic for ResultScreenView.xaml
    /// </summary>
    public partial class ResultScreenView : UserControl
    {
        public ResultScreenView()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void OnInitialize(object sender, EventArgs e)
        {
        }

        private void Checkbox_checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            Listing selectedItem = checkbox.DataContext as Listing;
            selectedItem.IsSelected = true;
        }
    }
}
