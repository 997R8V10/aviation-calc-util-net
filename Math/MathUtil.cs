using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.Math
{
    /// <summary>
    /// Math Tools and Calculations
    /// </summary>
    public static class MathUtil
    {
        public static long Factorial(int n)
        {
            return math_factorial(n);
        }

        public static double FactorialRatio(int n, int m)
        {
            return math_factorial_ratio(n, m);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern long math_factorial(int n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double math_factorial_ratio(int n, int m);

    }
}