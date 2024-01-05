using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// Represents a velocity quantity.
    /// </summary>
    public class Velocity : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal Velocity(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Velocity with the default value.
        /// </summary>
        public Velocity()
        {
            ptr = units_velocity_default();
        }

        /// <summary>
        /// Creates a new Velocity.
        /// </summary>
        /// <param name="val">Value in m/s (meters per second)</param>
        public Velocity(double val)
        {
            ptr = units_velocity_new(val);
        }

        /// <summary>
        /// Gets the velocity in m/s (meters per second).
        /// </summary>
        public double Value()
        {
            return units_velocity_value(ptr);
        }

        /// <summary>
        /// Creates a new Velocity.
        /// </summary>
        /// <param name="val">Value in m/s (meters per second)</param>
        public static Velocity FromMetersPerSecond(double val)
        {
            return new Velocity(units_velocity_from_meters_per_second(val));
        }

        /// <summary>
        /// Creates a new Velocity.
        /// </summary>
        /// <param name="val">Value in kts (knots, nautical miles per hour)</param>
        public static Velocity FromKnots(double val)
        {
            return new Velocity(units_velocity_from_knots(val));
        }

        /// <summary>
        /// Creates a new Velocity.
        /// </summary>
        /// <param name="val">Value in ft/min (feet per minute)</param>
        public static Velocity FromFeetPerMinute(double val)
        {
            return new Velocity(units_velocity_from_feet_per_minute(val));
        }

        /// <summary>
        /// Gets the velocity in m/s (meters per second).
        /// </summary>
        public double MetersPerSecond => units_velocity_as_meters_per_second(ptr);

        /// <summary>
        /// Gets the velocity in kts (knots, nautical miles per hour)
        /// </summary>
        public double Knots => units_velocity_as_knots(ptr);

        /// <summary>
        /// Gets the velocity in ft/min (feet per minute)
        /// </summary>
        public double FeetPerMinute => units_velocity_as_feet_per_minute(ptr);

        /// <summary>
        /// Conversion factor from m/s (meters per second) to kts (knots, nautical miles per hour)
        /// </summary>
        public static double CONV_FACTOR_MPERS_KTS => units_velocity_get_const_CONV_FACTOR_MPERS_KTS();

        /// <summary>
        /// Convert m/s (meters per second) to kts (knots, nautical miles per hour)
        /// </summary>
        public static double ConvertMpersToKts(double val)
        {
            return units_velocity_static_convert_mpers_to_kts(val);
        }

        /// <summary>
        /// Convert kts (knots, nautical miles per hour) to m/s (meters per second)
        /// </summary>
        public static double ConvertKtsToMpers(double val)
        {
            return units_velocity_static_convert_kts_to_mpers(val);
        }

        /// <summary>
        /// Convert m/s (meters per second) to ft/min (feet per minute)
        /// </summary>
        public static double ConvertMpersToFtpermin(double val)
        {
            return units_velocity_static_convert_mpers_to_ftpermin(val);
        }

        /// <summary>
        /// Convert ft/min (feet per minute) to m/s (meters per second)
        /// </summary>
        public static double ConvertFtperminToMpers(double val)
        {
            return units_velocity_static_convert_ftpermin_to_mpers(val);
        }

        /// <summary>
        /// Casts an Velocity to a double as m/s (meters per second).
        /// </summary>
        public static explicit operator double(Velocity v) => v.Value();

        /// <summary>
        /// Casts a double to a Velocity as m/s (meters per second).
        /// </summary>
        public static explicit operator Velocity(double v) => new Velocity(v);

        /// <inheritdoc />
        public static Velocity operator -(Velocity a) => new Velocity(units_velocity_neg(a.ptr));
        /// <inheritdoc />
        public static Velocity operator +(Velocity a, Velocity b) => new Velocity(units_velocity_add(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Velocity operator -(Velocity a, Velocity b) => new Velocity(units_velocity_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Velocity operator *(Velocity a, Velocity b) => new Velocity(units_velocity_mul(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Velocity operator /(Velocity a, Velocity b) => new Velocity(units_velocity_div(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Velocity operator %(Velocity a, Velocity b) => new Velocity(units_velocity_rem(a.ptr, b.ptr));

        /// <inheritdoc />
        public static Velocity operator +(Velocity a, double b) => new Velocity(units_velocity_add_f64(a.ptr, b));
        /// <inheritdoc />
        public static Velocity operator -(Velocity a, double b) => new Velocity(units_velocity_sub_f64(a.ptr, b));
        /// <inheritdoc />
        public static Velocity operator *(Velocity a, double b) => new Velocity(units_velocity_mul_f64(a.ptr, b));
        /// <inheritdoc />
        public static Length operator *(Velocity a, TimeSpan b) => new Length(units_velocity_mul_duration(a.ptr, InteropUtil.ManagedTimeSpanToDateTimeStruct(b)));
        /// <inheritdoc />
        public static Velocity operator /(Velocity a, double b) => new Velocity(units_velocity_div_f64(a.ptr, b));
        /// <inheritdoc />
        public static Acceleration operator /(Velocity a, TimeSpan b) => new Acceleration(units_velocity_div_duration(a.ptr, InteropUtil.ManagedTimeSpanToDateTimeStruct(b)));
        /// <inheritdoc />
        public static Velocity operator %(Velocity a, double b) => new Velocity(units_velocity_rem_f64(a.ptr, b));

        /// <inheritdoc />
        public static bool operator ==(Velocity a, Velocity b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Velocity a, Velocity b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Velocity a, Velocity b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Velocity a, Velocity b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Velocity a, Velocity b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Velocity a, Velocity b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Velocity(units_velocity_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return units_velocity_compare(ptr, ((Velocity)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return units_velocity_eq(ptr, ((Velocity)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropTools.InteropUtil.MarshallUnmanagedStringPtr(units_velocity_to_string(ptr));
        }

        /// <inheritdoc />
        ~Velocity()
        {
            units_velocity_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_new(double value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_value(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void units_velocity_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool units_velocity_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int units_velocity_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_add(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_add_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_sub(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_sub_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_mul(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_mul_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_mul_duration(IntPtr ptr, InteropDateTimeStruct rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_div(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_div_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_div_duration(IntPtr ptr, InteropDateTimeStruct rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_rem(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_rem_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_from_meters_per_second(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_from_knots(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_from_feet_per_minute(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_as_meters_per_second(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_as_knots(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_as_feet_per_minute(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_get_const_CONV_FACTOR_MPERS_KTS();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_static_convert_ftpermin_to_mpers(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_static_convert_kts_to_mpers(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_static_convert_mpers_to_ftpermin(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_velocity_static_convert_mpers_to_kts(double val);
    }
}
