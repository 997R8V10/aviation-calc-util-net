using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.GeoTools
{
    public class GeoPoint
    {
        private IntPtr ptr;

        [DllImport("aviationcalc")]
        private static extern IntPtr CreateGeoPoint(double lat, double lon, double alt);
        
        [DllImport("aviationcalc")]
        private static extern void DisposeGeoPoint(IntPtr ptr);

        public GeoPoint(double lat = 0, double lon = 0, double alt = 0)
        {
            ptr = CreateGeoPoint(lat, lon, alt);
        }

        ~GeoPoint()
        {
            DisposeGeoPoint(ptr);
        }
    }
}