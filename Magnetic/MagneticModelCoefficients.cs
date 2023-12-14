using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Magnetic
{
    public class MagneticModelCoefficients : ICloneable
    {
        internal IntPtr ptr;

        internal MagneticModelCoefficients(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public MagneticModelCoefficients()
        {
            ptr = magnetic_magnetic_model_coefficients_default();
        }

        public MagneticModelCoefficients GetPointOnDate(double modelEpoch, DateTime date)
        {
            IntPtr retPtr = magnetic_magnetic_model_coefficients_get_point_on_date(ptr, modelEpoch, InteropUtil.ManagedDateToDateStruct(date));
            return new MagneticModelCoefficients(retPtr);
        }

        public uint Degree
        {
            get => (uint) magnetic_magnetic_model_coefficients_n(ptr);
            set => magnetic_magnetic_model_coefficients_set_n(ptr, new UIntPtr(value));
        }

        public uint Order
        {
            get => (uint)magnetic_magnetic_model_coefficients_m(ptr);
            set => magnetic_magnetic_model_coefficients_set_m(ptr, new UIntPtr(value));
        }

        public double MainFieldG
        {
            get => magnetic_magnetic_model_coefficients_g_nm(ptr);
            set => magnetic_magnetic_model_coefficients_set_g_nm(ptr, value);
        }

        public double MainFieldH
        {
            get => magnetic_magnetic_model_coefficients_h_nm(ptr);
            set => magnetic_magnetic_model_coefficients_set_h_nm(ptr, value);
        }

        public double SecularVariationG
        {
            get => magnetic_magnetic_model_coefficients_g_dot_nm(ptr);
            set => magnetic_magnetic_model_coefficients_set_g_dot_nm(ptr, value);
        }

        public double SecularVariationH
        {
            get => magnetic_magnetic_model_coefficients_h_dot_nm(ptr);
            set => magnetic_magnetic_model_coefficients_set_h_dot_nm(ptr, value);
        }

        /// <inheritdoc />
        public static bool operator ==(MagneticModelCoefficients a, MagneticModelCoefficients b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(MagneticModelCoefficients a, MagneticModelCoefficients b) => !Equals(a, b);

        /// <inheritdoc />
        public object Clone()
        {
            return new MagneticModelCoefficients(magnetic_magnetic_model_coefficients_clone(ptr));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return magnetic_magnetic_model_coefficients_eq(ptr, ((MagneticModelCoefficients)obj).ptr);
        }

        ~MagneticModelCoefficients()
        {
            magnetic_magnetic_model_coefficients_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_coefficients_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_coefficients_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_coefficients_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool magnetic_magnetic_model_coefficients_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_coefficients_g_dot_nm(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_coefficients_g_nm(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_model_coefficients_get_point_on_date(IntPtr ptr, double modelEpoch, InteropDateStruct date);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_coefficients_h_dot_nm(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_model_coefficients_h_nm(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern UIntPtr magnetic_magnetic_model_coefficients_m(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern UIntPtr magnetic_magnetic_model_coefficients_n(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_coefficients_set_g_dot_nm(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_coefficients_set_g_nm(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_coefficients_set_h_dot_nm(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_coefficients_set_h_nm(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_coefficients_set_m(IntPtr ptr, UIntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_model_coefficients_set_n(IntPtr ptr, UIntPtr val);
    }
}
