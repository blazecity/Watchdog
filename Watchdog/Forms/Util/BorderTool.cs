using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Watchdog.Forms.Util
{
    public class BorderTool
    {
        public static Border SetBorderTopLeft(UIElement uIElement)
        {
            Border border = new Border();
            Thickness thickness = new Thickness(1, 1, 0, 0);
            border.BorderThickness = thickness;
            border.BorderBrush = Brushes.Black;
            border.Child = uIElement;
            return border;
        }
    }
}
