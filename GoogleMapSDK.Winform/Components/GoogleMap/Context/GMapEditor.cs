using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Components.GoogleMap.Context
{
    internal class GMapEditor
    {
        private readonly Dictionary<string, GMapOverlay> _overlays;
        private int _defaultOverlayNum = 0;

        public GMapEditor(Dictionary<string, GMapOverlay> overlays)
        {
            _overlays = overlays;
        }

        /// <summary>
        /// 回傳GMapOverlay圖層，如果沒有該overlayId則創建並回傳新圖層，
        /// 若overlayId為null則使用內建overlayId
        /// </summary>
        /// <param name="overlayId"></param>
        /// <returns></returns>
        public GMapOverlay GetOrCreateOverlay(string overlayId = null)
        {
            if (overlayId == null)
            {
                _defaultOverlayNum++;
                overlayId = $"Overlay {_defaultOverlayNum}";
                return CreateOverlay(overlayId);
            }

            if (_overlays.ContainsKey(overlayId))
            {
                return _overlays[overlayId];
            }

            return CreateOverlay(overlayId);
        }

        private GMapOverlay CreateOverlay(string overlayId)
        {
            var overlay = new GMapOverlay();
            _overlays.Add(overlayId, overlay);
            return overlay;
        }
    }
}
