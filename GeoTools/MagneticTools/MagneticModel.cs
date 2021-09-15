using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.GeoTools.MagneticTools
{
    public class MagneticModel
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc")] private static extern IntPtr CreateMagModel(double modelEpoch, [MarshalAs(UnmanagedType.LPStr)] string modelName, InteropDateStruct dStruct, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] coefficients, int coeffsSize);
        [DllImport("aviationcalc")] private static extern void DisposeMagModel(IntPtr model);
        [DllImport("aviationcalc")] private static extern IntPtr MagModelGetCoeffs(IntPtr model, int n, int m);
        [DllImport("aviationcalc")] private static extern double MagModelGetModelEpoch(IntPtr model);
        [DllImport("aviationcalc")] private static extern IntPtr MagModelGetModelName(IntPtr model);
        [DllImport("aviationcalc")] private static extern InteropDateStruct MagModelGetReleaseDate(IntPtr model);
    }
}
