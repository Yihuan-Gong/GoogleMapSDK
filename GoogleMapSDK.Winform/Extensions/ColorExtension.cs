using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace GoogleMapSDK.Winform.Extensions
{
    public static class ColorExtension
    {
        public static Color GetWinformColor(this Contract.Components.GoogleMap.Models.Color color)
        {
            return new Mapper<Contract.Components.GoogleMap.Models.Color, Color>().Map(color);
        }
    }
}
