using AviationCalcUtilNet.MathTools;
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

        /// <summary>
        /// Interoplates between two numbers with a multiplier.
        /// </summary>
        public static double InterpolateNumbers(double start, double end, double multiplier)
        {
            return math_interpolate_numbers(start, end, multiplier);
        }

        public static Polynomial CreateLineEquation(double x1, double y1, double x2, double y2)
        {
            var ptr = math_create_line_equation(x1, y1, x2, y2);

            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            return new Polynomial(ptr);
        }

        public static (double x, double y) Find2LinesIntersection(double m1, double b1, double m2, double b2)
        {
            math_find_2_lines_intersection(m1, b1, m2, b2, out double x, out double y);
            return (x, y);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern long math_factorial(int n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double math_factorial_ratio(int n, int m);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double math_interpolate_numbers(double start, double end, double multiplier);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr math_create_line_equation(double x1, double y1, double x2, double y2);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void math_find_2_lines_intersection(double m1, double b1, double m2, double b2, out double x, out double y);

    }
}