using System;
using System.Runtime.InteropServices;
using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;

namespace AviationCalcUtilNet.Magnetic
{
    public class MagneticField : ICloneable
    {
        internal IntPtr ptr;

        internal MagneticField(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public MagneticField()
        {
            ptr = magnetic_magnetic_field_default();
        }        

        public MagneticFieldElements MainFieldElements
        {
            get => new MagneticFieldElements(magnetic_magnetic_field_field_elements(ptr));
            set => magnetic_magnetic_field_set_field_elements(ptr, value.ptr);
        }

        public MagneticFieldElements SecularFieldElements
        {
            get => new MagneticFieldElements(magnetic_magnetic_field_sec_elements(ptr));
            set => magnetic_magnetic_field_set_sec_elements(ptr, value.ptr);
        }

        public Bearing TrueToMagnetic(Bearing trueBearing)
        {
            return new Bearing(magnetic_magnetic_field_true_to_magnetic(ptr, trueBearing.ptr));
        }

        public Bearing MagneticToTrue(Bearing magneticBearing)
        {
            return new Bearing(magnetic_magnetic_field_magnetic_to_true(ptr, magneticBearing.ptr));
        }

        /// <inheritdoc />
        public static bool operator ==(MagneticField a, MagneticField b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(MagneticField a, MagneticField b) => !Equals(a, b);

        /// <inheritdoc />
        public object Clone()
        {
            return new MagneticField(magnetic_magnetic_field_clone(ptr));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return magnetic_magnetic_field_eq(ptr, ((MagneticField)obj).ptr);
        }

        ~MagneticField()
        {
            magnetic_magnetic_field_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool magnetic_magnetic_field_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_field_elements(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_magnetic_to_true(IntPtr ptr, IntPtr bearing);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_sec_elements(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_set_field_elements(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_field_set_sec_elements(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_field_true_to_magnetic(IntPtr ptr, IntPtr bearing);
    }
}