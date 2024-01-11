using AviationCalcUtilNet.InteropTools;
using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// Represents a length quantity.
    /// </summary>
	public class Length : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal Length(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Length with a value of 0m.
        /// </summary>
        public Length()
        {
            ptr = units_length_default();
        }

        /// <summary>
        /// Creates a new Length.
        /// </summary>
        /// <param name="meters">Value in m (meters)</param>
        public Length(double meters)
        {
            ptr = units_length_new(meters);
        }

        /// <summary>
        /// Creates a new Length.
        /// </summary>
        /// <param name="val">Value in  m (meters)</param>
        public static Length FromMeters(double val)
        {
            return new Length(units_length_from_meters(val));
        }

        /// <summary>
        /// Creates a new Length.
        /// </summary>
        /// <param name="val">Value in ft (feet)</param>
        public static Length FromFeet(double val)
        {
            return new Length(units_length_from_feet(val));
        }

        /// <summary>
        /// Creates a new Length.
        /// </summary>
        /// <param name="val">Value in nmi (nautical miles)</param>
        public static Length FromNauticalMiles(double val)
        {
            return new Length(units_length_from_nautical_miles(val));
        }

        /// <summary>
        /// Creates a new Length.
        /// </summary>
        /// <param name="val">Value in mi (statute miles)</param>
        public static Length FromStatuteMiles(double val)
        {
            return new Length(units_length_from_statute_miles(val));
        }

        /// <summary>
        /// Gets the length in m (meters).
        /// </summary>
        public double Meters => units_length_as_meters(ptr);

        /// <summary>
        /// Gets the length in ft (feet).
        /// </summary>
        public double Feet => units_length_as_feet(ptr);

        /// <summary>
        /// Gets the length in nmi (nautical miles).
        /// </summary>
        public double NauticalMiles => units_length_as_nautical_miles(ptr);

        /// <summary>
        /// Gets the length in mi (statute miles).
        /// </summary>
        public double StatuteMiles => units_length_as_statute_miles(ptr);

        /// <summary>
        /// Gets the length in m (meters).
        /// </summary>
        public double Value()
        {
            return units_length_value(ptr);
        }

        // Constants
        /// <summary>
        /// Conversion factor from m (meters) to ft (feet)
        /// </summary>
        public static double CONV_FACTOR_M_FT => units_length_get_const_CONV_FACTOR_M_FT();

        /// <summary>
        /// Conversion factor from nmi (nautical miles) to m (meters)
        /// </summary>
        public static double CONV_FACTOR_NMI_M => units_length_get_const_CONV_FACTOR_NMI_M();

        /// <summary>
        /// Conversion factor from mi (statute miles) to m (meters)
        /// </summary>
        public static double CONV_FACTOR_MI_M => units_length_get_const_CONV_FACTOR_MI_M();

        /// <summary>
        /// Convert m (meters) to ft (feet)
        /// </summary>
        public static double ConvertMetersToFeet(double meters)
        {
            return units_length_static_convert_meters_to_feet(meters);
        }

        /// <summary>
        /// Convert m (meters) to nmi (nautical miles)
        /// </summary>
        public static double ConvertMetersToNauticalMiles(double meters)
        {
            return units_length_static_convert_meters_to_nautical_miles(meters);
        }

        /// <summary>
        /// Convert m (meters) to mi (statute miles)
        /// </summary>
        public static double ConvertMetersToStatuteMiles(double meters)
        {
            return units_length_static_convert_meters_to_statute_miles(meters);
        }

        /// <summary>
        /// Convert ft (feet) to m (meters)
        /// </summary>
        public static double ConvertFeetToMeters(double feet)
        {
            return units_length_static_convert_feet_to_meters(feet);
        }

        /// <summary>
        /// Convert nmi (nautical miles) to m (meters)
        /// </summary>
        public static double ConvertNauticalMilesToMeters(double nmi)
        {
            return units_length_static_convert_nautical_miles_to_meters(nmi);
        }

        /// <summary>
        /// Convert mi (statute miles) to m (meters)
        /// </summary>
        public static double ConvertStatuteMilesToMeters(double mi)
        {
            return units_length_static_convert_statute_miles_to_meters(mi);
        }

        /// <summary>
        /// Casts an Length to a double as m (meters).
        /// </summary>
        public static explicit operator double(Length v) => v.Value();

        /// <summary>
        /// Casts a double to a Length as m (meters).
        /// </summary>
        public static explicit operator Length(double v) => new Length(v);

        /// <inheritdoc />
        public static Length operator -(Length a) => new Length(units_length_neg(a.ptr));
        /// <inheritdoc />
        public static Length operator +(Length a, Length b) => new Length(units_length_add(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Length operator -(Length a, Length b) => new Length(units_length_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Length operator *(Length a, Length b) => new Length(units_length_mul(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Length operator /(Length a, Length b) => new Length(units_length_div(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Length operator %(Length a, Length b) => new Length(units_length_rem(a.ptr, b.ptr));

        /// <inheritdoc />
        public static Length operator +(Length a, double b) => new Length(units_length_add_f64(a.ptr, b));
        /// <inheritdoc />
        public static Length operator -(Length a, double b) => new Length(units_length_sub_f64(a.ptr, b));
        /// <inheritdoc />
        public static Length operator *(Length a, double b) => new Length(units_length_mul_f64(a.ptr, b));
        /// <inheritdoc />
        public static Length operator /(Length a, double b) => new Length(units_length_div_f64(a.ptr, b));
        /// <inheritdoc />
        public static Velocity operator /(Length a, TimeSpan b) => new Velocity(units_length_div_duration(a.ptr, InteropUtil.ManagedTimeSpanToDateTimeStruct(b)));
        /// <inheritdoc />
        public static TimeSpan operator /(Length a, Velocity b) => InteropUtil.DateTimeStructToManagedTimeSpan(units_length_div_velocity(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Length operator %(Length a, double b) => new Length(units_length_rem_f64(a.ptr, b));
        /// <inheritdoc />
        public static bool operator ==(Length a, Length b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Length a, Length b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Length a, Length b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Length a, Length b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Length a, Length b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Length a, Length b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Length(units_length_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return units_length_compare(ptr, ((Length)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return units_length_eq(ptr, ((Length)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (ptr == IntPtr.Zero)
            {
                return "";
            }
            return InteropUtil.MarshallUnmanagedStringPtr(units_length_to_string(ptr));
        }

        /// <inheritdoc />
        ~Length()
        {
            units_length_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_new(double value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_value(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void units_length_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool units_length_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int units_length_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_add(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_add_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_sub(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_sub_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_mul(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_mul_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_div(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_div_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_div_duration(IntPtr ptr, InteropDateTimeStruct rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropDateTimeStruct units_length_div_velocity(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_rem(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_rem_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_from_feet(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_from_meters(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_from_nautical_miles(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_from_statute_miles(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_as_meters(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_as_feet(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_as_nautical_miles(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_as_statute_miles(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_get_const_CONV_FACTOR_M_FT();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_get_const_CONV_FACTOR_NMI_M();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_get_const_CONV_FACTOR_MI_M();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_static_convert_meters_to_feet(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_static_convert_meters_to_nautical_miles(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_static_convert_meters_to_statute_miles(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_static_convert_feet_to_meters(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_static_convert_nautical_miles_to_meters(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_length_static_convert_statute_miles_to_meters(double val);
    }
}

