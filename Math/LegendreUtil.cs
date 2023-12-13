using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.MathTools
{
    public static class LegendreUtil
    {
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr LegendreUtilPolynomial(int n);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double LegendreUtilFactorialRatio(int n, int m);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double LegendreUtilLegendreFunction(int n, int m, double x);

        public static Polynomial LegendrePolynomial(int n)
        {
            var toReturn = LegendreUtilPolynomial(n);
            if (toReturn != IntPtr.Zero)
            {
                return new Polynomial(toReturn);
            }
            return null;
        }

        public static double FactorialRatio(int n, int m)
        {
            return LegendreUtilFactorialRatio(n, m);
        }

        public static double LegendreFunction(int n, int m, double x)
        {
            return LegendreUtilLegendreFunction(n, m, x);
        }
        
    }
}