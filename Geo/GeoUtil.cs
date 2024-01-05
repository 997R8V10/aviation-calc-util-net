using AviationCalcUtilNet.Units;
using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.GeoTools
{
    /// <summary>
    /// Geographic Calculations
    /// </summary>
    public static class GeoUtil
    {
        /// <summary>
        /// Average radius of the Earth
        /// </summary>
        public static Length EARTH_RADIUS = new Length(geo_get_const_EARTH_RADIUS());

        /// <summary>
        /// Earth Surface Gravitational Acceleration
        /// </summary>
        public static Acceleration EARTH_GRAVITY = new Acceleration(geo_get_const_EARTH_GRAVITY());

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_get_const_EARTH_RADIUS();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_get_const_EARTH_GRAVITY();
    }
}