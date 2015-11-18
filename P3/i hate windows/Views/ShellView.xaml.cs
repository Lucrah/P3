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
using System.Windows.Shapes;


namespace P3.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView
    {
        public ShellView()
        {
            InitializeComponent();
        }

        public delegate void KeyEventHandler(object sender, KeyEventArgs e);

        private void FullScreen(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        //disregard, i forgot how to remove these safely. fml.
        private void OnInitialize(object sender, EventArgs e)
        {
        }
    }
}
