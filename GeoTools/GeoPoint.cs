using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.GeoTools
{
    public class GeoPoint
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc")] private static extern IntPtr CreateGeoPoint(double lat, double lon, double alt);
        [DllImport("aviationcalc")] private static extern void DisposeGeoPoint(IntPtr ptr);
        [DllImport("aviationcalc")] private static extern void GeoPointMoveByM(IntPtr ptr, double bearing, double distance);
        [DllImport("aviationcalc")] private static extern void GeoPointMoveByNMi(IntPtr ptr, double bearing, double distance);
        [DllImport("aviationcalc")] private static extern double GeoPointFlatDistanceM(IntPtr ptr1, IntPtr ptr2);
        [DllImport("aviationcalc")] private static extern double GeoPointFlatDistanceNMi(IntPtr ptr1, IntPtr ptr2);
        [DllImport("aviationcalc")] private static extern double GeoPointDistanceM(IntPtr ptr1, IntPtr ptr2);
        [DllImport("aviationcalc")] private static extern double GeoPointDistanceNMi(IntPtr ptr1, IntPtr ptr2);
        [DllImport("aviationcalc")] private static extern IntPtr GeoPointIntersection(IntPtr ptr1, double bearing1, IntPtr ptr2, double bearing2);
        [DllImport("aviationcalc")] private static extern double GeoPointInitialBearing(IntPtr ptr1, IntPtr ptr2);
        [DllImport("aviationcalc")] private static extern double GeoPointFinalBearing(IntPtr ptr1, IntPtr ptr2);
        [DllImport("aviationcalc")] private static extern bool GeoPointEquals(IntPtr ptr1, IntPtr ptr2);
        [DllImport("aviationcalc")] private static extern double GeoPointGetLat(IntPtr ptr);
        [DllImport("aviationcalc")] private static extern void GeoPointSetLat(IntPtr ptr, double newLat);
        [DllImport("aviationcalc")] private static extern double GeoPointGetLon(IntPtr ptr);
        [DllImport("aviationcalc")] private static extern void GeoPointSetLon(IntPtr ptr, double newLon);
        [DllImport("aviationcalc")] private static extern double GeoPointGetAlt(IntPtr ptr);
        [DllImport("aviationcalc")] private static extern void GeoPointSetAlt(IntPtr ptr, double newAlt);

        public GeoPoint(double lat = 0, double lon = 0, double alt = 0)
        {
            ptr = CreateGeoPoint(lat, lon, alt);
        }

        internal GeoPoint(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public void MoveByM(double bearing, double distance)
        {
            GeoPointMoveByM(ptr, bearing, distance);
        }

        public void MoveByNMi(double bearing, double distance)
        {
            GeoPointMoveByNMi(ptr, bearing, distance);
        }

        public static double operator -(GeoPoint point1, GeoPoint point2)
        {
            return GeoPointDistanceM(point1.ptr, point2.ptr);
        }

        public static double FlatDistanceM(GeoPoint point1, GeoPoint point2)
        {
            return GeoPointFlatDistanceM(point1.ptr, point2.ptr);
        }

        public static double FlatDistanceNMi(GeoPoint point1, GeoPoint point2)
        {
            return GeoPointFlatDistanceNMi(point1.ptr, point2.ptr);
        }

        public static double DistanceM(GeoPoint point1, GeoPoint point2)
        {
            return GeoPointDistanceM(point1.ptr, point2.ptr);
        }

        public static double DistanceNMi(GeoPoint point1, GeoPoint point2)
        {
            return GeoPointDistanceNMi(point1.ptr, point2.ptr);
        }

        public static GeoPoint Intersection(GeoPoint point1, double bearing1, GeoPoint point2, double bearing2)
        {
            IntPtr ptr = GeoPointIntersection(point1.ptr, bearing1, point2.ptr, bearing2);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            return new GeoPoint(ptr);
        }

        public static double InitialBearing(GeoPoint point1, GeoPoint point2)
        {
            return GeoPointInitialBearing(point1.ptr, point2.ptr);
        }

        public static double FinalBearing(GeoPoint point1, GeoPoint point2)
        {
            return GeoPointFinalBearing(point1.ptr, point2.ptr);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return GeoPointEquals(ptr, ((GeoPoint) obj).ptr);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hashCode = Lat.GetHashCode() & 65535;
            hashCode <<= 16;
            hashCode += Lon.GetHashCode() & 65535;
            return hashCode;
        }

        public double Lat {
            get => GeoPointGetLat(ptr);
            set => GeoPointSetLat(ptr, value);
        }

        public double Lon {
            get => GeoPointGetLon(ptr);
            set => GeoPointSetLon(ptr, value);
        }

        public double Alt {
            get => GeoPointGetAlt(ptr);
            set => GeoPointSetAlt(ptr, value);
        }

        ~GeoPoint()
        {
            DisposeGeoPoint(ptr);
        }
    }
}