using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.MathTools
{
    /// <summary>
    /// Representaion of a polynomial
    /// </summary>
    public class Polynomial
    {
        internal IntPtr ptr;

        internal Polynomial(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public Polynomial(double[] coefficients)
        {
            ptr = math_polynomial_new(InteropUtil.ManagedArrayToStruct(coefficients));
        }

        ~Polynomial()
        {
            math_polynomial_drop(ptr);
        }

        public double Evaluate(double x)
        {
            return math_polynomial_evaluate(ptr, x);
        }

        public Polynomial Derivative(int n)
        {
            IntPtr returned = math_polynomial_derivative(ptr, n);
            return new Polynomial(returned);
        }

        public double[] Coefficients => InteropUtil.MarshallUnmanagedDoubleArr(math_polynomial_coefficients(ptr));

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropArrStruct math_polynomial_coefficients(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr math_polynomial_derivative(IntPtr ptr, int n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void math_polynomial_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double math_polynomial_evaluate(IntPtr ptr, double x);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr math_polynomial_new(InteropArrStruct2<double> coeffs);

    }
}