using AviationCalcUtilNet.InteropTools;
using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.Magnetic
{
    /// <summary>
    /// Magnetic Calculations
    /// </summary>
    public static class MagneticUtil
    {
        public static double EARTH_WGS84_SEMI_MAJOR_AXIS => magnetic_magnetic_model_get_const_EARTH_WGS84_SEMI_MAJOR_AXIS();
        public static double EARTH_WGS84_RECIPROCAL_FLATTENING => magnetic_magnetic_model_get_const_EARTH_WGS84_RECIPROCAL_FLATTENING();
        public static uint WMM_EXPANSION => (uint) magnetic_magnetic_model_get_const_WMM_EXPANSION();
        public static double GEOMAGNETIC_REFERENCE_RADIUS => magnetic_magnetic_model_get_const_GEOMAGNETIC_REFERENCE_RADIUS();
        public static double GetEpochYear(DateTime date)
        {
            return magnetic_get_epoch_year(InteropUtil.ManagedDateToDateStruct(date));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_get_epoch_year(InteropDateStruct date);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_get_const_EARTH_WGS84_RECIPROCAL_FLATTENING();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_get_const_EARTH_WGS84_SEMI_MAJOR_AXIS();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_get_const_GEOMAGNETIC_REFERENCE_RADIUS();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern UIntPtr magnetic_magnetic_model_get_const_WMM_EXPANSION();
    }
}
