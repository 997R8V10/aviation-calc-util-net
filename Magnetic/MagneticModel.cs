using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Magnetic
{
    /// <summary>
    /// Represents a Magnetic Model
    /// </summary>
    public class MagneticModel
    {
        internal IntPtr ptr;

        internal MagneticModel(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public MagneticModel(double epoch, string name, DateTime releaseDate, List<MagneticModelCoefficients> coefficients)
        {
            IntPtr[] coeffsArr = new IntPtr[coefficients.Count];

            for (int i = 0; i < coefficients.Count; i++)
            {
                coeffsArr[i] = coefficients[i].ptr;
            }

            ptr = magnetic_magnetic_model_new(epoch, name, InteropUtil.ManagedDateToDateStruct(releaseDate), InteropUtil.ManagedArrayToStruct<IntPtr>(coeffsArr));
        }

        /// <summary>
        /// Loads the Magnetic Model from a *.COF file
        /// </summary>
        public static MagneticModel FromFile(string filename)
        {
            var ptr = magnetic_magnetic_model_from_file(filename, out IntPtr error_str);

            if (error_str !=  IntPtr.Zero)
            {
                var error = InteropUtil.MarshallUnmanagedStringPtr(error_str);
                throw new Exception(error);
            }

            return new MagneticModel(ptr);
        }

        /// <summary>
        /// Returns the magnetic coefficients for n and m
        /// </summary>
        public MagneticModelCoefficients Coeffs(uint n, uint m)
        {
            var coeffs = magnetic_magnetic_model_coeffs(ptr, new UIntPtr(n), new UIntPtr(m));

            return new MagneticModelCoefficients(coeffs);
        }

        /// <summary>
        /// Calculates the Magnetic Field at a point and time
        /// </summary>
        public MagneticField CalculateField(GeoPoint point, DateTime date)
        {
            return new MagneticField(magnetic_magnetic_model_calculate_field(ptr, point.ptr, InteropUtil.ManagedDateToDateStruct(date)));
        }

        /// <summary>
        /// Epoch: A decimal year
        /// </summary>
        public double Epoch
        {
            get => magnetic_magnetic_model_epoch(ptr);
            set => magnetic_magnetic_model_set_epoch(ptr, value);
        }

        public string Name
        {
            get => InteropUtil.MarshallUnmanagedStringPtr(magnetic_magnetic_model_name(ptr));
            set => magnetic_magnetic_model_set_name(ptr, value);
        }

        public DateTime ReleaseDate
        {
            get => InteropUtil.DateStructToManagedDate(magnetic_magnetic_model_release_date(ptr));
            set => magnetic_magnetic_model_set_release_date(ptr, InteropUtil.ManagedDateToDateStruct(value));
        }

        ~MagneticModel()
        {
            magnetic_magnetic_model_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_calculate_field(IntPtr ptr, IntPtr point, InteropDateStruct date);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_coeffs(IntPtr ptr, UIntPtr n, UIntPtr m);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_epoch(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_from_file([MarshalAs(UnmanagedType.LPStr)] string filename, out IntPtr error_string);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_name(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_new(double epoch, [MarshalAs(UnmanagedType.LPStr)] string name, InteropDateStruct releaseDate, InteropArrStruct2<IntPtr> coeffs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropDateStruct magnetic_magnetic_model_release_date(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_set_epoch(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_set_name(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_set_release_date(IntPtr ptr, InteropDateStruct date);
    }
}
