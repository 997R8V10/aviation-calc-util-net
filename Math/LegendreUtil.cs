using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.MathTools
{
    public static class LegendreUtil
    {
        public static Polynomial LegendrePolynomial(int n)
        {
            var toReturn = math_legendre_legendre_polynomial(n);
            return new Polynomial(toReturn);
        }
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr math_legendre_legendre_polynomial(int n);
    }
}