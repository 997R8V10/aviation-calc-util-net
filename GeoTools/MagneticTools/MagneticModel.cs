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

        internal MagneticModel(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public MagneticModel(double modelEpoch, string modelName, DateTime releaseDate, List<MagneticModelCoefficients> coefficients)
        {
            IntPtr[] coeffsArr = new IntPtr[coefficients.Count];

            for (int i = 0; i < coefficients.Count; i++)
            {
                coeffsArr[i] = coefficients[i].ptr;
            }

            ptr = CreateMagModel(modelEpoch, modelName, InteropUtil.ManagedDateToDateStruct(releaseDate), coeffsArr, coeffsArr.Length);
        }

        public MagneticModelCoefficients GetCoeffs(int n, int m)
        {
            var coeffs = MagModelGetCoeffs(ptr, n, m);
            if (coeffs == IntPtr.Zero)
            {
                return null;
            }

            return new MagneticModelCoefficients(coeffs);
        }

        public double ModelEpoch => MagModelGetModelEpoch(ptr);

        public string ModelName {
            get {
                return Marshal.PtrToStringAnsi(MagModelGetModelName(ptr));
            }
        }

        public DateTime ReleaseDate => InteropUtil.DateStructToManagedDate(MagModelGetReleaseDate(ptr));

        ~MagneticModel()
        {
            DisposeMagModel(ptr);
        }
    }
}
