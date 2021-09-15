using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.GeoTools.MagneticTools
{
    public class MagneticModelCoefficients
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc")] private static extern IntPtr CopyMagModelCoeffs(IntPtr o);
        [DllImport("aviationcalc")] private static extern IntPtr CreateMagModelCoeffs(int n, int m, double g_nm, double h_nm, double g_dot_nm, double h_dot_nm);
        [DllImport("aviationcalc")] private static extern void DisposeMagModelCoeffs(IntPtr coeffs);
        [DllImport("aviationcalc")] private static extern int MagModelCoeffsGetN(IntPtr coeffs);
        [DllImport("aviationcalc")] private static extern int MagModelCoeffsGetM(IntPtr coeffs);
        [DllImport("aviationcalc")] private static extern double MagModelCoeffsGetG(IntPtr coeffs);
        [DllImport("aviationcalc")] private static extern double MagModelCoeffsGetH(IntPtr coeffs);
        [DllImport("aviationcalc")] private static extern double MagModelCoeffsGetGDot(IntPtr coeffs);
        [DllImport("aviationcalc")] private static extern double MagModelCoeffsGetHDot(IntPtr coeffs);
        [DllImport("aviationcalc")] private static extern IntPtr MagModelCoeffsGetPointOnDate(IntPtr coeffs, double modelEpoch, InteropDateStruct dateStruct);

		internal MagneticModelCoefficients(IntPtr ptr)
        {
			this.ptr = ptr;
        }

		public MagneticModelCoefficients(int n, int m, double g_nm, double h_nm, double g_dot_nm, double h_dot_nm)
        {
			ptr = CreateMagModelCoeffs(n, m, g_nm, h_nm, g_dot_nm, h_dot_nm);
        }

		public MagneticModelCoefficients GetPointOnDate(double modelEpoch, DateTime date)
        {
			IntPtr retPtr = MagModelCoeffsGetPointOnDate(ptr, modelEpoch, InteropUtil.ManagedDateToDateStruct(date));
			if (retPtr == IntPtr.Zero)
            {
				return null;
            }

			return new MagneticModelCoefficients(retPtr);
        }

		MagneticModelCoefficients GetCopy()
        {
			IntPtr retPtr = CopyMagModelCoeffs(ptr);
			if (retPtr == IntPtr.Zero)
			{
				return null;
			}

			return new MagneticModelCoefficients(retPtr);
		}

		public double Degree => MagModelCoeffsGetN(ptr);

		public double Order => MagModelCoeffsGetM(ptr);

		public double MainFieldG => MagModelCoeffsGetG(ptr);

		public double MainFieldH => MagModelCoeffsGetH(ptr);

		public double SecularVariationG => MagModelCoeffsGetGDot(ptr);

		public double SecularVariationH => MagModelCoeffsGetHDot(ptr);

        ~MagneticModelCoefficients()
        {
            DisposeMagModelCoeffs(ptr);
        }
    }
}
