using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AviationCalcUtilNet.GeoTools;

namespace AviationCalcUtilNet.Atmos.Grib
{
    public class GribDataPoint
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr CreateGribDataPoint(double lat, double lon, int level_hPa);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void DisposeGribDataPoint(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetDistanceFrom(IntPtr point, IntPtr pos);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr GribDataPointToString(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetLatitude(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetLongitude(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetLongitudeNormalized(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetGeoPotentialHeightM(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void GribDataPointSetGeoPotentialHeightM(IntPtr point, double newGeoPotHtM);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetGeoPotentialHeightFt(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern int GribDataPointGetLevelHPa(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetTempK(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void GribDataPointSetTempK(IntPtr point, double newTempK);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetTempC(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetVMpers(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void GribDataPointSetVMpers(IntPtr point, double newVMpers);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetUMpers(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void GribDataPointSetUMpers(IntPtr point, double newUMpers);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetWindSpeedMpers(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetWindSpeedKts(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetWindDirRads(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetWindDirDegs(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetRelHumidity(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void GribDataPointSetRelHumidity(IntPtr point, double newRelHumidity);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GribDataPointGetSfcPressHPa(IntPtr point);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void GribDataPointSetSfcPressHPa(IntPtr point, double newSfcPressHPa);

        public GribDataPoint(double lat, double lon, int level_hPa)
        {
            ptr = CreateGribDataPoint(lat, lon, level_hPa);
        }

        internal GribDataPoint(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public double GetDistanceFrom(GeoPoint pos)
        {
            return GribDataPointGetDistanceFrom(ptr, pos.ptr);
        }

        public override string ToString()
        {
            return Marshal.PtrToStringAnsi(GribDataPointToString(ptr));
        }

        ~GribDataPoint()
        {
            DisposeGribDataPoint(ptr);
        }

        public double Latitude => GribDataPointGetLatitude(ptr);

        public double Longitude => GribDataPointGetLongitude(ptr);

        public double Longitude_Norm => GribDataPointGetLongitudeNormalized(ptr);

        public double GeoPotentialHeight_M
        {
            get => GribDataPointGetGeoPotentialHeightM(ptr);
            set => GribDataPointSetGeoPotentialHeightM(ptr, value);
        }

        public double GeoPotentialHeight_Ft => GribDataPointGetGeoPotentialHeightFt(ptr);

        public double Level_hPa => GribDataPointGetLevelHPa(ptr);

        public double Temp_K
        {
            get => GribDataPointGetTempK(ptr);
            set => GribDataPointSetTempK(ptr, value);
        }

        public double Temp_C => GribDataPointGetTempC(ptr);

        public double V_mpers
        {
            get => GribDataPointGetVMpers(ptr);
            set => GribDataPointSetVMpers(ptr, value);
        }

        public double U_mpers
        {
            get => GribDataPointGetUMpers(ptr);
            set => GribDataPointSetUMpers(ptr, value);
        }

        public double WSpeed_mpers => GribDataPointGetWindSpeedMpers(ptr);

        public double WSpeed_kts => GribDataPointGetWindSpeedKts(ptr);

        public double WDir_rads => GribDataPointGetWindDirRads(ptr);

        public double WDir_deg => GribDataPointGetWindDirDegs(ptr);

        public double RelativeHumidity
        {
            get => GribDataPointGetRelHumidity(ptr);
            set => GribDataPointSetRelHumidity(ptr, value);
        }

        public double SfcPress_hPa
        {
            get => GribDataPointGetSfcPressHPa(ptr);
            set => GribDataPointSetSfcPressHPa(ptr, value);
        }
    }
}
