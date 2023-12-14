using AviationCalcUtilNet.Atmos.Grib;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Math
{
    public class LegendreManager
    {

        internal IntPtr ptr;

        internal LegendreManager(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public LegendreManager()
        {
            ptr = math_legendre_legendremanager_new();
        }

        public double LegendreFunction(int n, int m, double x)
        {
            return math_legendre_legendremanager_legendre_function(ptr, n, m, x);
        }

        ~LegendreManager()
        {
            math_legendre_legendremanager_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void math_legendre_legendremanager_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double math_legendre_legendremanager_legendre_function(IntPtr ptr, int n, int m, double x);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr math_legendre_legendremanager_new();
    }
}
