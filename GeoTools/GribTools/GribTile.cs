using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.GeoTools.GribTools
{
    public class GribTile
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr GribTileFindOrCreateGribTile(IntPtr pos, ulong dateTime);
        [DllImport("aviationcalc")] private static extern IntPtr CreateGribTile(IntPtr pos, ulong dateTime);
        [DllImport("aviationcalc")] private static extern void DisposeGribTile(IntPtr tile);
        [DllImport("aviationcalc")] private static extern ulong GribTileGetForecastDateUtc(IntPtr tile);
        [DllImport("aviationcalc")] private static extern IntPtr GribTileGetGribFileName(IntPtr tile);
        [DllImport("aviationcalc")] private static extern IntPtr GribTileGetClosestPoint(IntPtr tile, IntPtr acftPos);
        [DllImport("aviationcalc")] private static extern bool GribTileIsValid(IntPtr tile, ulong dateTime);
        [DllImport("aviationcalc")] private static extern bool GribTileEquals(IntPtr tile, IntPtr o);
        [DllImport("aviationcalc")] private static extern bool GribTileIsPointInTile(IntPtr tile, IntPtr point);
        [DllImport("aviationcalc")] private static extern IntPtr GribTileGetCenterPoint(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double GribTileGetBottomLat(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double GribTileGetTopLat(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double GribTileGetLeftLon(IntPtr tile);
        [DllImport("aviationcalc")] private static extern double GribTileGetRightLon(IntPtr tile);

        public GribTile(GeoPoint pos, DateTime dateTime)
        {
            ptr = CreateGribTile(pos.ptr, InteropUtil.ManagedDateToNs(dateTime));
        }

        internal GribTile(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public static GribTile FindOrCreateGribTile(GeoPoint pos, DateTime dateTime)
        {
            IntPtr ptr = GribTileFindOrCreateGribTile(pos.ptr, InteropUtil.ManagedDateToNs(dateTime));

            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            return new GribTile(ptr);
        }

        public double TopLatitude => GribTileGetTopLat(ptr);

        public double BottomLatitude => GribTileGetBottomLat(ptr);

        public double LeftLongitude => GribTileGetLeftLon(ptr);

        public double RightLongitude => GribTileGetRightLon(ptr);

        public DateTime ForecastDateUtc => InteropUtil.NsToManagedDate(GribTileGetForecastDateUtc(ptr));

        public string GribFileName {
            get {
                return Marshal.PtrToStringAnsi(GribTileGetGribFileName(ptr));
            }
        }

        public GribDataPoint GetClosestPoint(GeoPoint acftPos)
        {
            IntPtr retPtr = GribTileGetClosestPoint(ptr, acftPos.ptr);

            if (retPtr == IntPtr.Zero)
            {
                return null;
            }

            return new GribDataPoint(retPtr);
        }

        public bool IsValid(DateTime dateTime)
        {
            return GribTileIsValid(ptr, InteropUtil.ManagedDateToNs(dateTime));
        }

        public bool IsAcftInside(GeoPoint pos)
        {
            return GribTileIsPointInTile(ptr, pos.ptr);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return GribTileEquals(ptr, ((GribTile)obj).ptr);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
            return base.GetHashCode();
        }

        ~GribTile()
        {
            DisposeGribTile(ptr);
        }
    }
}
