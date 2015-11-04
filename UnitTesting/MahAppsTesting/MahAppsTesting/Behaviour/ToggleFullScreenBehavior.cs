using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using System.Windows;

namespace P3.Behaviour
{
    public class ToggleFullScreenBehavior : Behavior<Window>
	{
		public bool ToggleFullScreen
		{
			get { return (bool)GetValue(ToggleFullScreenProperty); }
			set { SetValue(ToggleFullScreenProperty, value); }
		}
	
		public static readonly DependencyProperty ToggleFullScreenProperty =
			DependencyProperty.Register("ToggleFullScreen", typeof(bool), typeof(ToggleFullScreenBehavior), new PropertyMetadata(false, OnToggleFullScreenChanged));
	
		private static void OnToggleFullScreenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var behavior = d as ToggleFullScreenBehavior;
	
			if (behavior != null)
			{
				behavior.OnToggleFullScreenChanged();
			}
		}
	
		private void OnToggleFullScreenChanged()
		{
			if (this.ToggleFullScreen)
			{
                if (this.AssociatedObject.WindowState == WindowState.Maximized)
                { 
                    this.AssociatedObject.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.AssociatedObject.WindowState = WindowState.Normal;
                }
                else
                {
                    
                    this.AssociatedObject.WindowStyle = WindowStyle.None;
                    this.AssociatedObject.WindowState = WindowState.Maximized; 
                }
			}
		}
	}
}