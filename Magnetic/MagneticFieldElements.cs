using AviationCalcUtilNet.Units;
using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.Magnetic
{
    public class MagneticFieldElements : ICloneable
    {
        internal IntPtr ptr;

        internal MagneticFieldElements(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        public MagneticFieldElements()
        {
            ptr = magnetic_magnetic_field_elements_default();
        }

        public double NorthComponent
        {
            get => magnetic_magnetic_field_elements_x(ptr);
            set => magnetic_magnetic_field_elements_set_x(ptr, value);
        }

        public double EastComponent
        {
            get => magnetic_magnetic_field_elements_y(ptr);
            set => magnetic_magnetic_field_elements_set_y(ptr, value);
        }

        public double DownComponent
        {
            get => magnetic_magnetic_field_elements_z(ptr);
            set => magnetic_magnetic_field_elements_set_z(ptr, value);
        }

        public double HorizontalIntensity
        {
            get => magnetic_magnetic_field_elements_h(ptr);
            set => magnetic_magnetic_field_elements_set_h(ptr, value);
        }

        public double TotalIntensity
        {
            get => magnetic_magnetic_field_elements_f(ptr);
            set => magnetic_magnetic_field_elements_set_f(ptr, value);
        }

        public Angle Declination
        {
            get => new Angle(magnetic_magnetic_field_elements_decl(ptr));
            set => magnetic_magnetic_field_elements_set_decl(ptr, value.ptr);
        }

        public Angle Inclination
        {
            get => new Angle(magnetic_magnetic_field_elements_incl(ptr));
            set => magnetic_magnetic_field_elements_set_incl(ptr, value.ptr);
        }

        /// <inheritdoc />
        public static bool operator ==(MagneticFieldElements a, MagneticFieldElements b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(MagneticFieldElements a, MagneticFieldElements b) => !Equals(a, b);

        /// <inheritdoc />
        public object Clone()
        {
            return new MagneticFieldElements(magnetic_magnetic_field_elements_clone(ptr));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return magnetic_magnetic_field_elements_eq(ptr, ((MagneticFieldElements)obj).ptr);
        }

        ~MagneticFieldElements()
        {
            magnetic_magnetic_field_elements_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_elements_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_elements_decl(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_elements_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool magnetic_magnetic_field_elements_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_field_elements_f(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_field_elements_h(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_elements_incl(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_set_decl(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_set_f(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_set_h(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_set_incl(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_set_x(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_set_y(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_elements_set_z(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_field_elements_x(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_field_elements_y(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double magnetic_magnetic_field_elements_z(IntPtr ptr);
    }
}