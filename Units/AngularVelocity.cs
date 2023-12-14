using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// Represents a angular velocity quantity.
    /// </summary>
    public class AngularVelocity : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal AngularVelocity(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Angular Velocity with the default value.
        /// </summary>
        public AngularVelocity()
        {
            ptr = units_angular_velocity_default();
        }

        /// <summary>
        /// Creates a new Angular Velocity.
        /// </summary>
        /// <param name="val">Value in rad/s (radians per second)</param>
        public AngularVelocity(double val)
        {
            ptr = units_angular_velocity_new(val);
        }

        /// <summary>
        /// Gets the angular velocity in rad/s (radians per second).
        /// </summary>
        public double Value()
        {
            return units_angular_velocity_value(ptr);
        }

        /// <summary>
        /// Creates a new Angular Velocity.
        /// </summary>
        /// <param name="val">Value in rad/s (radians per second)</param>
        public static AngularVelocity FromRadiansPerSecond(double val)
        {
            return new AngularVelocity(units_angular_velocity_from_radians_per_second(val));
        }

        /// <summary>
        /// Creates a new Angular Velocity.
        /// </summary>
        /// <param name="val">Value in °/s (degrees per second)</param>
        public static AngularVelocity FromDegreesPerSecond(double val)
        {
            return new AngularVelocity(units_angular_velocity_from_degrees_per_second(val));
        }

        /// <summary>
        /// Gets the angular velocity in rad/s (radians per second).
        /// </summary>
        public double RadiansPerSecond => units_angular_velocity_as_radians_per_second(ptr);

        /// <summary>
        /// Gets the angular velocity in °/s (degrees per second).
        /// </summary>
        public double DegreesPerSecond => units_angular_velocity_as_degrees_per_second(ptr);

        /// <summary>
        /// Casts an AngularVelocity to a double as rad/s (radians per second).
        /// </summary>
        public static explicit operator double(AngularVelocity v) => v.Value();

        /// <summary>
        /// Casts a double to a AngularVelocity as rad/s (radians per second).
        /// </summary>
        public static explicit operator AngularVelocity(double v) => new AngularVelocity(v);

        /// <inheritdoc />
        public static AngularVelocity operator -(AngularVelocity a) => new AngularVelocity(units_angular_velocity_neg(a.ptr));
        /// <inheritdoc />
        public static AngularVelocity operator +(AngularVelocity a, AngularVelocity b) => new AngularVelocity(units_angular_velocity_add(a.ptr, b.ptr));
        /// <inheritdoc />
        public static AngularVelocity operator -(AngularVelocity a, AngularVelocity b) => new AngularVelocity(units_angular_velocity_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static AngularVelocity operator *(AngularVelocity a, AngularVelocity b) => new AngularVelocity(units_angular_velocity_mul(a.ptr, b.ptr));
        /// <inheritdoc />
        public static AngularVelocity operator /(AngularVelocity a, AngularVelocity b) => new AngularVelocity(units_angular_velocity_div(a.ptr, b.ptr));
        /// <inheritdoc />
        public static AngularVelocity operator %(AngularVelocity a, AngularVelocity b) => new AngularVelocity(units_angular_velocity_rem(a.ptr, b.ptr));

        /// <inheritdoc />
        public static AngularVelocity operator +(AngularVelocity a, double b) => new AngularVelocity(units_angular_velocity_add_f64(a.ptr, b));
        /// <inheritdoc />
        public static AngularVelocity operator -(AngularVelocity a, double b) => new AngularVelocity(units_angular_velocity_sub_f64(a.ptr, b));
        /// <inheritdoc />
        public static AngularVelocity operator *(AngularVelocity a, double b) => new AngularVelocity(units_angular_velocity_mul_f64(a.ptr, b));
        /// <inheritdoc />
        public static Angle operator *(AngularVelocity a, TimeSpan b) => new Angle(units_angular_velocity_mul_duration(a.ptr, InteropUtil.ManagedTimeSpanToDateTimeStruct(b)));
        /// <inheritdoc />
        public static AngularVelocity operator /(AngularVelocity a, double b) => new AngularVelocity(units_angular_velocity_div_f64(a.ptr, b));
        /// <inheritdoc />
        public static AngularVelocity operator %(AngularVelocity a, double b) => new AngularVelocity(units_angular_velocity_rem_f64(a.ptr, b));

        /// <inheritdoc />
        public static bool operator ==(AngularVelocity a, AngularVelocity b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(AngularVelocity a, AngularVelocity b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(AngularVelocity a, AngularVelocity b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(AngularVelocity a, AngularVelocity b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(AngularVelocity a, AngularVelocity b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(AngularVelocity a, AngularVelocity b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new AngularVelocity(units_angular_velocity_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return units_angular_velocity_compare(ptr, ((AngularVelocity)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return units_angular_velocity_eq(ptr, ((AngularVelocity)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropTools.InteropUtil.MarshallUnmanagedStringPtr(units_angular_velocity_to_string(ptr));
        }

        /// <inheritdoc />
        ~AngularVelocity()
        {
            units_angular_velocity_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_new(double value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_angular_velocity_value(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void units_angular_velocity_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool units_angular_velocity_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int units_angular_velocity_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_add(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_add_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_sub(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_sub_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_mul(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_mul_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_mul_duration(IntPtr ptr, InteropDateTimeStruct rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_div(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_div_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_rem(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_rem_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_from_radians_per_second(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_from_degrees_per_second(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_angular_velocity_as_radians_per_second(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_angular_velocity_as_degrees_per_second(IntPtr ptr);
    }
}
