using AviationCalcUtilNet.GeoTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    public interface IGeoTile
    {
        Latitude BottomLat { get; }
        Latitude TopLat { get; }
        Longitude LeftLon { get; }
        Longitude RightLon { get; }
        GeoPoint CenterPoint { get; }
        bool IsPointInTile(GeoPoint point);
    }
}
