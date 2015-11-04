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
using MahApps.Metro.Controls;

namespace MahAppsTesting.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : MetroWindow
    {
        public ShellView()
        {
            InitializeComponent();
        }

        //This is  a dependency property used to scale the window n shit and funktions to go with it
        //#region ScaleValue Depdency Property
        //public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(ShellView), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));

        //private static object OnCoerceScaleValue(DependencyObject o, object value)
        //{
        //    ShellView mainWindow = o as ShellView;
        //    if (mainWindow != null)
        //        return ShellView.OnCoerceScaleValue((double)value);
        //    else
        //        return value;
        //}

        //private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        //{
        //    ShellView mainWindow = o as ShellView;
        //    if (mainWindow != null)
        //        mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        //}

        //protected  static double OnCoerceScaleValue(double value)
        //{
        //    if (double.IsNaN(value))
        //        return 1.0d;

        //    value = Math.Max(0.1, value);
        //    return value;
        //}

        //protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        //{

        //}

        //public double ScaleValue
        //{
        //    get
        //    {
        //        return (double)GetValue(ScaleValueProperty);
        //    }
        //    set
        //    {
        //        SetValue(ScaleValueProperty, value);
        //    }
        //}





        //private void MainGrid_SizeChanged(object sender, EventArgs e)
        //{
        //    CalculateScale();
        //}

        //private void CalculateScale()
        //{
        //    double yScale = ActualHeight / 400.0d;
        //    double xScale = ActualWidth / 500.0d;
        //    double value = Math.Min(xScale, yScale);
        //    ScaleValue = (double)OnCoerceScaleValue(MainGrid, value);
        //}
        //#endregion
    }
}
