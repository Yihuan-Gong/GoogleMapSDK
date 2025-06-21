using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.GoogleMap.Models
{
    public class ToolTipModel
    {
        public string Text { get; set; }
        public Brush Fill { get; set; }
        public Brush Foreground { get; set; }
        public Font Font { get; set; }
        public Point OffSet { get; set; }
        public Pen Stroke { get; set; }
        public Size TextPadding { get; set; }
    }
}
