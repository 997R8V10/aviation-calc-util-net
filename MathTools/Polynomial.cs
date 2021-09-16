using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.MathTools
{
    public class Polynomial
    {
        internal IntPtr ptr;
        [DllImport("aviationcalc")] private static extern IntPtr CreatePolynomial(double[] coefficients, int coefficientsSize);
        [DllImport("aviationcalc")] private static extern void DisposePolynomial(IntPtr ptr);
        [DllImport("aviationcalc")] private static extern double PolynomialEvaluate(IntPtr ptr, double x);
        [DllImport("aviationcalc")] private static extern IntPtr PolynomialDerivative(IntPtr ptr, int n);
        [DllImport("aviationcalc")] private static extern double[] PolynomialGetCoefficients(IntPtr ptr, out int size);

        internal Polynomial(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public Polynomial(List<double> coefficients)
        {
            ptr = CreatePolynomial(coefficients.ToArray(), coefficients.Count);
        }

        ~Polynomial()
        {
            DisposePolynomial(ptr);
        }

        public double Evaluate(double x)
        {
            return PolynomialEvaluate(ptr, x);
        }

        public Polynomial Derivative(int n)
        {
            IntPtr returned = PolynomialDerivative(ptr, n);
            if (returned != IntPtr.Zero)
            {
                return new Polynomial(returned);
            }
            return null;
        }

        public List<double> GetCoefficients()
        {
            var asArray = PolynomialGetCoefficients(ptr, out var size);
            return new List<double>(asArray);
        }
        
    }
}