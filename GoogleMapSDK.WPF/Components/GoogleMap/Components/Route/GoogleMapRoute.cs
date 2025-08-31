using GMap.NET;
using GMap.NET.WindowsPresentation;
using GoogleMapSDK.Contract.Components.GoogleMap.Components.Route;
using GoogleMapSDK.WPF.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace GoogleMapSDK.WPF.Components.GoogleMap.Components.Route
{
    internal class GoogleMapRoute : GMapRoute, IGoogleMapRoute
    {
        private Color _color;
        private double _thickness;
        
        public GoogleMapRoute() : base(new List<PointLatLng>())
        {
        }

        public void Load(string polyline, Contract.Components.GoogleMap.Models.Color color, double thickness = 5)
        {
            Points = PureProjection.PolylineDecode(polyline);
            _color = color.GetWPFColor();
        }


        // 這個function是GMapControl用來在Marker被變更時，更新Route並渲染到畫面上時所使用
        // 我們要將裡面的stroke改成可以自行設定顏色
        public override Path CreatePath(List<System.Windows.Point> localPath, bool addBlurEffect)
        {
            // Create a StreamGeometry to use to specify myPath.
            var geometry = new StreamGeometry();

            using (var ctx = geometry.Open())
            {
                ctx.BeginFigure(localPath[0], false, false);
                // Draw a line to the next specified point.
                ctx.PolyLineTo(localPath, true, true);
            }

            // Freeze the geometry (make it unmodifiable)
            // for additional performance benefits.
            geometry.Freeze();
            // Create a path to draw a geometry with.
            var myPath = new Path();
            {
                // Specify the shape of the Path using the StreamGeometry.
                myPath.Data = geometry;

                if (addBlurEffect)
                {
                    var ef = new BlurEffect();
                    {
                        ef.KernelType = KernelType.Gaussian;
                        ef.Radius = 3.0;
                        ef.RenderingBias = RenderingBias.Performance;
                    }
                    myPath.Effect = ef;
                }

                myPath.Stroke = new SolidColorBrush(_color);
                myPath.StrokeThickness = _thickness;
                //myPath.StrokeLineJoin = PenLineJoin.Round;
                //myPath.StrokeStartLineCap = PenLineCap.Triangle;
                //myPath.StrokeEndLineCap = PenLineCap.Square;
                //myPath.Opacity = 0.6;
                myPath.IsHitTestVisible = false;
            }
            return myPath;
        }
    }
}
