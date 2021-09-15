using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.GeoTools.MagneticTools
{
    public class MagneticTile
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc")] private static extern double MagneticTileGetResolution();
        [DllImport("aviationcalc")] private static extern IntPtr MagneticTileFindOrCreateTile(IntPtr pos, InteropDateStruct dStruct);
        [DllImport("aviationcalc")] private static extern IntPtr CreateMagneticTile(IntPtr point, InteropDateStruct dStruct);
        [DllImport("aviationcalc")] private static extern void DisposeMagneticTile(IntPtr tile);
        [DllImport("aviationcalc")] private static extern bool MagneticTileIsValid(IntPtr tile, InteropDateStruct dStruct);
        [DllImport("aviationcalc")] private static extern IntPtr MagneticTileGetData(IntPtr tile);
        [DllImport("aviationcalc")] private static extern bool MagneticTileIsPointInTile(IntPtr tile, IntPtr point);
        [DllImport("aviationcalc")] private static extern IntPtr MagneticTileGetCenterPoint(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double MagneticTileGetBottomLat(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double MagneticTileGetTopLat(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double MagneticTileGetLeftLon(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double MagneticTileGetRightLon(IntPtr tile);

        public static double RESOLUTION => MagneticTileGetResolution();

        internal MagneticTile(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public static MagneticTile FindOrCreateTile(GeoPoint pos, DateTime date)
        {
            var ptr = MagneticTileFindOrCreateTile(pos.ptr, InteropUtil.ManagedDateToDateStruct(date));
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            return new MagneticTile(ptr);
        }

        public MagneticTile(GeoPoint point, DateTime date)
        {
            ptr = CreateMagneticTile(point.ptr, InteropUtil.ManagedDateToDateStruct(date));
        }

        public bool IsValid(DateTime date)
        {
            return MagneticTileIsValid(ptr, InteropUtil.ManagedDateToDateStruct(date));
        }

        public MagneticResult Data {
            get {
                var resptr = MagneticTileGetData(ptr);
                if (resptr == IntPtr.Zero)
                {
                    return null;
                }

                return new MagneticResult(resptr);
            }
        }

        public bool IsPointInTile(GeoPoint point)
        {
            return MagneticTileIsPointInTile(ptr, point.ptr);
        }

        public static bool operator ==(MagneticTile tile, GeoPoint point)
        {
            return tile.IsPointInTile(point);
        }

        public static bool operator !=(MagneticTile tile, GeoPoint point)
        {
            return !tile.IsPointInTile(point);
        }

        public GeoPoint CenterPoint {
            get {
                var ptPtr = MagneticTileGetCenterPoint(ptr);
                if (ptPtr == IntPtr.Zero)
                {
                    return new GeoPoint(0, 0);
                }
                return new GeoPoint(ptPtr);
            }
        }

        public double TopLatitude => MagneticTileGetTopLat(ptr);

        public double BottomLatitude => MagneticTileGetBottomLat(ptr);

        public double LeftLongitude => MagneticTileGetLeftLon(ptr);

        public double RightLongitude => MagneticTileGetRightLon(ptr);
    }
}
