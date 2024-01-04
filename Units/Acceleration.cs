using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// Represents a acceleration quantity.
    /// </summary>
    public class Acceleration : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal Acceleration(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Acceleration with the default value.
        /// </summary>
        public Acceleration()
        {
            ptr = units_acceleration_default();
        }

        /// <summary>
        /// Creates a new Acceleration.
        /// </summary>
        /// <param name="val">Value in m/s^2 (meters per second squared)</param>
        public Acceleration(double val)
        {
            ptr = units_acceleration_new(val);
        }

        /// <summary>
        /// Gets the Acceleration in m/s^2 (meters per second squared).
        /// </summary>
        public double Value()
        {
            return units_acceleration_value(ptr);
        }

        /// <summary>
        /// Creates a new Acceleration.
        /// </summary>
        /// <param name="val">Value in m/s (meters per second)</param>
        public static Acceleration FromMetersPerSecondSquared(double val)
        {
            return new Acceleration(units_acceleration_from_meters_per_second_squared(val));
        }

        /// <summary>
        /// Creates a new Acceleration.
        /// </summary>
        /// <param name="val">Value in kts/s (knots per second, nautical miles per hour per second)</param>
        public static Acceleration FromKnotsPerSecond(double val)
        {
            return new Acceleration(units_acceleration_from_knots_per_second(val));
        }

        /// <summary>
        /// Gets the Acceleration in m/s^2 (meters per second squared).
        /// </summary>
        public double MetersPerSecondSquared => units_acceleration_as_meters_per_second_squared(ptr);

        /// <summary>
        /// Gets the Acceleration in kts/s (knots per second, nautical miles per hour per second)
        /// </summary>
        public double KnotsPerSecond => units_acceleration_as_knots_per_second(ptr);

        /// <summary>
        /// Casts an Acceleration to a double as m/s^2 (meters per second squared).
        /// </summary>
        public static explicit operator double(Acceleration v) => v.Value();

        /// <summary>
        /// Casts a double to a Acceleration as m/s (meters per second).
        /// </summary>
        public static explicit operator Acceleration(double v) => new Acceleration(v);

        /// <inheritdoc />
        public static Acceleration operator -(Acceleration a) => new Acceleration(units_acceleration_neg(a.ptr));
        /// <inheritdoc />
        public static Acceleration operator +(Acceleration a, Acceleration b) => new Acceleration(units_acceleration_add(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Acceleration operator -(Acceleration a, Acceleration b) => new Acceleration(units_acceleration_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Acceleration operator *(Acceleration a, Acceleration b) => new Acceleration(units_acceleration_mul(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Acceleration operator /(Acceleration a, Acceleration b) => new Acceleration(units_acceleration_div(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Acceleration operator %(Acceleration a, Velocity b) => new Acceleration(units_acceleration_rem(a.ptr, b.ptr));

        /// <inheritdoc />
        public static Acceleration operator +(Acceleration a, double b) => new Acceleration(units_acceleration_add_f64(a.ptr, b));
        /// <inheritdoc />
        public static Acceleration operator -(Acceleration a, double b) => new Acceleration(units_acceleration_sub_f64(a.ptr, b));
        /// <inheritdoc />
        public static Acceleration operator *(Acceleration a, double b) => new Acceleration(units_acceleration_mul_f64(a.ptr, b));
        /// <inheritdoc />
        public static Velocity operator *(Acceleration a, TimeSpan b) => new Velocity(units_acceleration_mul_duration(a.ptr, InteropUtil.ManagedTimeSpanToDateTimeStruct(b)));
        /// <inheritdoc />
        public static Acceleration operator /(Acceleration a, double b) => new Acceleration(units_acceleration_div_f64(a.ptr, b));
        /// <inheritdoc />
        public static Acceleration operator %(Acceleration a, double b) => new Acceleration(units_acceleration_rem_f64(a.ptr, b));

        /// <inheritdoc />
        public static bool operator ==(Acceleration a, Acceleration b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Acceleration a, Acceleration b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Acceleration a, Acceleration b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Acceleration a, Acceleration b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Acceleration a, Acceleration b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Acceleration a, Acceleration b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Acceleration(units_acceleration_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return units_acceleration_compare(ptr, ((Velocity)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return units_acceleration_eq(ptr, ((Velocity)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropTools.InteropUtil.MarshallUnmanagedStringPtr(units_acceleration_to_string(ptr));
        }

        /// <inheritdoc />
        ~Acceleration()
        {
            units_acceleration_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_new(double value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_acceleration_value(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void units_acceleration_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool units_acceleration_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int units_acceleration_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_add(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_add_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_sub(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_sub_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_mul(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_mul_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_mul_duration(IntPtr ptr, InteropDateTimeStruct rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_div(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_div_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_rem(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_rem_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_from_meters_per_second_squared(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_acceleration_from_knots_per_second(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_acceleration_as_meters_per_second_squared(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_acceleration_as_knots_per_second(IntPtr ptr);
    }
}
