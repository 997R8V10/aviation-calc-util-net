using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// Represents a angle quantity.
    /// </summary>
    public class Angle : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal Angle(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Angle with the default value.
        /// </summary>
        public Angle()
        {
            ptr = units_angle_default();
        }

        /// <summary>
        /// Creates a new Angle.
        /// </summary>
        /// <param name="val">Value in rads (radians)</param>
        public Angle(double val)
        {
            ptr = units_angle_new(val);
        }

        /// <summary>
        /// Gets the angle in rads (radians).
        /// </summary>
        public double Value()
        {
            return units_angle_value(ptr);
        }

        /// <summary>
        /// Creates a new Angle.
        /// </summary>
        /// <param name="val">Value in rads (radians)</param>
        public static Angle FromRadians(double val)
        {
            return new Angle(units_angle_from_radians(val));
        }

        /// <summary>
        /// Creates a new Angle.
        /// </summary>
        /// <param name="val">Value in ° (degrees)</param>
        public static Angle FromDegrees(double val)
        {
            return new Angle(units_angle_from_degrees(val));
        }

        /// <summary>
        /// Creates a new Angle from degrees, mins, secs
        /// </summary>
        public static Angle FromDegMinSec(int degrees, uint mins, double secs)
        {
            return new Angle(units_angle_from_deg_min_sec(new DegMinSec() { degrees = degrees, mins = mins, secs = secs }));
        }

        /// <summary>
        /// Calculates Angle given arc length
        /// </summary>
        /// <param name="arcLength">Arc Length</param>
        /// <param name="radius">Radius of circle</param>
        /// <returns></returns>
        public static Angle CalculateAngleFromArcLength(Length arcLength, Length radius)
        {
            return new Angle(units_angle_calculate_angle_from_arc_length(arcLength.ptr, radius.ptr));
        }

        /// <summary>
        /// Calculate Arc Length
        /// </summary>
        /// <param name="angle">Angle</param>
        /// <param name="radius">Radius of circle</param>
        /// <returns></returns>
        public static Length CalculateArcLength(Angle angle, Length radius)
        {
            return new Length(units_angle_calculate_arc_length(angle.ptr, radius.ptr));
        }

        /// <summary>
        /// Gets the angle in rads (radians).
        /// </summary>
        public double Radians => units_angle_as_radians(ptr);

        /// <summary>
        /// Gets the angle in ° (degrees).
        /// </summary>
        public double Degrees => units_angle_as_degrees(ptr);

        /// <summary>
        /// Gets the angle in degrees, mins, secs
        /// </summary>
        public (int degrees, uint mins, double secs) DegMinSec { 
            get {
                var s = units_angle_as_deg_min_sec(ptr);
                return (s.degrees, s.mins, s.secs);
            }
        }

        /// <summary>
        /// Casts an Angle to a double as rads (radians).
        /// </summary>
        public static explicit operator double(Angle v) => v.Value();

        /// <summary>
        /// Casts a double to a Angle as rads (radians).
        /// </summary>
        public static explicit operator Angle(double v) => new Angle(v);

        /// <inheritdoc />
        public static Angle operator -(Angle a) => new Angle(units_angle_neg(a.ptr));
        /// <inheritdoc />
        public static Angle operator +(Angle a, Angle b) => new Angle(units_angle_add(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Angle operator -(Angle a, Angle b) => new Angle(units_angle_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Angle operator *(Angle a, Angle b) => new Angle(units_angle_mul(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Angle operator /(Angle a, Angle b) => new Angle(units_angle_div(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Angle operator %(Angle a, Angle b) => new Angle(units_angle_rem(a.ptr, b.ptr));

        /// <inheritdoc />
        public static Angle operator +(Angle a, double b) => new Angle(units_angle_add_f64(a.ptr, b));
        /// <inheritdoc />
        public static Angle operator -(Angle a, double b) => new Angle(units_angle_sub_f64(a.ptr, b));
        /// <inheritdoc />
        public static Angle operator *(Angle a, double b) => new Angle(units_angle_mul_f64(a.ptr, b));
        /// <inheritdoc />
        public static Angle operator /(Angle a, double b) => new Angle(units_angle_div_f64(a.ptr, b));
        /// <inheritdoc />
        public static AngularVelocity operator /(Angle a, TimeSpan b) => new AngularVelocity(units_angle_div_duration(a.ptr, InteropUtil.ManagedTimeSpanToDateTimeStruct(b)));
        /// <inheritdoc />
        public static Angle operator %(Angle a, double b) => new Angle(units_angle_rem_f64(a.ptr, b));

        /// <inheritdoc />
        public static bool operator ==(Angle a, Angle b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Angle a, Angle b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Angle a, Angle b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Angle a, Angle b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Angle a, Angle b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Angle a, Angle b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Angle(units_angle_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return units_angle_compare(ptr, ((Angle)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return units_angle_eq(ptr, ((Angle)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropTools.InteropUtil.MarshallUnmanagedStringPtr(units_angle_to_string(ptr));
        }

        /// <inheritdoc />
        ~Angle()
        {
            units_angle_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_new(double value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_angle_value(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void units_angle_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool units_angle_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int units_angle_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_add(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_add_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_sub(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_sub_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_mul(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_mul_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_div(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_div_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_div_duration(IntPtr ptr, InteropDateTimeStruct rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_rem(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_rem_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_from_radians(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_from_degrees(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_from_deg_min_sec(DegMinSec val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_angle_as_radians(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_angle_as_degrees(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern DegMinSec units_angle_as_deg_min_sec(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_calculate_angle_from_arc_length(IntPtr arc_length, IntPtr radius);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_calculate_arc_length(IntPtr angle, IntPtr radius);
    }
}
