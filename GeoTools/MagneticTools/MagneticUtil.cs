using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.GeoTools.MagneticTools
{
    public static class MagneticUtil
    {
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilGetConst_EARTH_WGS84_SEMI_MAJOR_AXIS();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilGetConst_EARTH_WGS84_RECIPROCAL_FLATTENING();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern int MagneticUtilGetConst_WMM_EXPANSION();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilGetConst_GEOMAGNETIC_REFERENCE_RADIUS();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void MagneticUtilLoadData();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr MagneticUtilGetMagneticField(IntPtr point, InteropDateStruct dStruct);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilGetEpochYear(InteropDateStruct dStruct);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void MagneticUtilGetSpherical(IntPtr point, out double lambda, out double phiPrime, out double r);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilConvertMagneticToTrue1(double magneticBearing, double declination);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilConvertMagneticToTrue2(double magneticBearing, IntPtr position);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilConvertTrueToMagnetic1(double trueBearing, double declination);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilConvertTrueToMagnetic2(double trueBearing, IntPtr position);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilConvertMagneticToTrueTile(double magneticBearing, IntPtr position);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double MagneticUtilConvertTrueToMagneticTile(double trueBearing, IntPtr position);

        public static double EARTH_WGS84_SEMI_MAJOR_AXIS => MagneticUtilGetConst_EARTH_WGS84_SEMI_MAJOR_AXIS();
        public static double EARTH_WGS84_RECIPROCAL_FLATTENING => MagneticUtilGetConst_EARTH_WGS84_RECIPROCAL_FLATTENING();
        public static int WMM_EXPANSION => MagneticUtilGetConst_WMM_EXPANSION();
        public static double GEOMAGNETIC_REFERENCE_RADIUS => MagneticUtilGetConst_GEOMAGNETIC_REFERENCE_RADIUS();

        public static void LoadData()
        {
            MagneticUtilLoadData();
        }

        public static MagneticResult GetMagneticField(GeoPoint point, DateTime date)
        {
            IntPtr res = MagneticUtilGetMagneticField(point.ptr, InteropUtil.ManagedDateToDateStruct(date));
            if (res == IntPtr.Zero)
            {
                return null;
            }

            return new MagneticResult(res);
        }

        public static double GetEpochYear(DateTime date)
        {
            return MagneticUtilGetEpochYear(InteropUtil.ManagedDateToDateStruct(date));
        }

        public static void GetSpherical(GeoPoint point, out double lambda, out double phiPrime, out double r)
        {
            MagneticUtilGetSpherical(point.ptr, out lambda, out phiPrime, out r);
        }

        /// <summary>
        /// Converts Magnetic Bearings to True Bearings with declination
        /// </summary>
        /// <param name="magneticBearing"><c>double</c> Magnetic Bearing (degrees)</param>
        /// <param name="declination"><c>double</c> Magnetic Declination (degrees)</param>
        /// <returns><c>double</c> True Bearing (degrees)</returns>
        public static double ConvertMagneticToTrue(double magneticBearing, double declination)
        {
            return MagneticUtilConvertMagneticToTrue1(magneticBearing, declination);
        }

        /// <summary>
        /// Converts Magnetic Bearings to True Bearings at a position
        /// </summary>
        /// <param name="magneticBearing"><c>double</c> Magnetic Bearing (degrees)</param>
        /// <param name="position"><c>GeoPoint</c> Position</param>
        /// <returns><c>double</c> True Bearing (degrees)</returns>
        public static double ConvertMagneticToTrue(double magneticBearing, GeoPoint position)
        {
            return MagneticUtilConvertMagneticToTrue2(magneticBearing, position.ptr);
        }

        /// <summary>
        /// Converts True Bearings to Magnetic Bearings with declination
        /// </summary>
        /// <param name="trueBearing"><c>double</c> True Bearing (degrees)</param>
        /// <param name="declination"><c>double</c> Magnetic Declination (degrees)</param>
        /// <returns><c>double</c> Magnetic Bearing (degrees)</returns>
        public static double ConvertTrueToMagnetic(double trueBearing, double declination)
        {
            return MagneticUtilConvertTrueToMagnetic1(trueBearing, declination);
        }

        /// <summary>
        /// Converts True Bearings to Magnetic Bearings at a position
        /// </summary>
        /// <param name="trueBearing"><c>double</c> True Bearing (degrees)</param>
        /// <param name="position"><c>GeoPoint</c> Position</param>
        /// <returns><c>double</c> Magnetic Bearing (degrees)</returns>
        public static double ConvertTrueToMagnetic(double trueBearing, GeoPoint position)
        {
            return MagneticUtilConvertTrueToMagnetic2(trueBearing, position.ptr);
        }

        /// <summary>
        /// Converts Magnetic Bearings to True Bearings at a position using cached tiles for improved performance.
        /// Use this if you need to perform multiple magnetic calculations
        /// </summary>
        /// <param name="magneticBearing"><c>double</c> Magnetic Bearing (degrees)</param>
        /// <param name="position"><c>double</c> Position</param>
        /// <returns><c>double</c> True Bearing (degrees)</returns>
        public static double ConvertMagneticToTrueTile(double magneticBearing, GeoPoint position)
        {
            return MagneticUtilConvertMagneticToTrueTile(magneticBearing, position.ptr);
        }

        /// <summary>
        /// Converts True Bearings to Magnetic Bearings at a position using cached tiles for improved performance.
        /// Use this if you need to perform multiple magnetic calculations
        /// </summary>
        /// <param name="magneticBearing"><c>double</c> True Bearing (degrees)</param>
        /// <param name="position"><c>double</c> Position</param>
        /// <returns><c>double</c> Magnetic Bearing (degrees)</returns>
        public static double ConvertTrueToMagneticTile(double trueBearing, GeoPoint position)
        {
            return MagneticUtilConvertTrueToMagneticTile(trueBearing, position.ptr);
        }
    }
}
