using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GoogleMapSDK.WPF.Extensions
{
    public static class ColorExtension
    {
        public static Color GetWPFColor(this Contract.Components.GoogleMap.Models.Color color)
        {
            string colorName = color.ToString();
            PropertyInfo prop = typeof(Colors).GetProperty(colorName, BindingFlags.Public | BindingFlags.Static);

            if (prop == null)
                throw new ArgumentException($"Color '{colorName}' does not exist in System.Windows.Media.Colors.");

            return (Color)prop.GetValue(null);
        }
    }
}
