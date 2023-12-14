using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// Represents a temperature quantity.
    /// </summary>
    public class Temperature : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal Temperature(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Temperature with the default value.
        /// </summary>
        public Temperature()
        {
            ptr = units_temperature_default();
        }

        /// <summary>
        /// Creates a new Temperature.
        /// </summary>
        /// <param name="val">Value in K (kelvin)</param>
        public Temperature(double val)
        {
            ptr = units_temperature_new(val);
        }

        /// <summary>
        /// Gets the temperature in K (kelvin).
        /// </summary>
        public double Value()
        {
            return units_temperature_value(ptr);
        }

        /// <summary>
        /// Creates a new Temperature.
        /// </summary>
        /// <param name="val">Value in K (kelvin)</param>
        public static Temperature FromKelvin(double val)
        {
            return new Temperature(units_temperature_from_kelvin(val));
        }

        /// <summary>
        /// Creates a new Temperature.
        /// </summary>
        /// <param name="val">Value in °C (degrees celsius).</param>
        public static Temperature FromCelsius(double val)
        {
            return new Temperature(units_temperature_from_celsius(val));
        }

        /// <summary>
        /// Gets the temperature in K (kelvin).
        /// </summary>
        public double Kelvin => units_temperature_as_kelvin(ptr);

        /// <summary>
        /// Gets the temperature in °C (degrees celsius).
        /// </summary>
        public double Celsius => units_temperature_as_celsius(ptr);

        /// <summary>
        /// Conversion factor from K (kelvin) to °C (degrees celsius)
        /// </summary>
        public static double CONV_FACTOR_KELVIN_C => units_temperature_get_const_CONV_FACTOR_KELVIN_C();

        /// <summary>
        /// Convert K (kelvin) to °C (degrees celsius)
        /// </summary>
        public static double ConvertCelsiusToKelvin(double val)
        {
            return units_temperature_static_convert_celsius_to_kelvin(val);
        }

        /// <summary>
        /// Convert °C (degrees celsius) to K (kelvin)
        /// </summary>
        public static double ConvertKelvinToCelsius(double val)
        {
            return units_temperature_static_convert_kelvin_to_celsius(val);
        }

        /// <summary>
        /// Casts an Temperature to a double as K (kelvin).
        /// </summary>
        public static explicit operator double(Temperature v) => v.Value();

        /// <summary>
        /// Casts a double to a Temperature as K (kelvin).
        /// </summary>
        public static explicit operator Temperature(double v) => new Temperature(v);

        /// <inheritdoc />
        public static Temperature operator -(Temperature a) => new Temperature(units_temperature_neg(a.ptr));
        /// <inheritdoc />
        public static Temperature operator +(Temperature a, Temperature b) => new Temperature(units_temperature_add(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Temperature operator -(Temperature a, Temperature b) => new Temperature(units_temperature_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Temperature operator *(Temperature a, Temperature b) => new Temperature(units_temperature_mul(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Temperature operator /(Temperature a, Temperature b) => new Temperature(units_temperature_div(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Temperature operator %(Temperature a, Temperature b) => new Temperature(units_temperature_rem(a.ptr, b.ptr));

        /// <inheritdoc />
        public static Temperature operator +(Temperature a, double b) => new Temperature(units_temperature_add_f64(a.ptr, b));
        /// <inheritdoc />
        public static Temperature operator -(Temperature a, double b) => new Temperature(units_temperature_sub_f64(a.ptr, b));
        /// <inheritdoc />
        public static Temperature operator *(Temperature a, double b) => new Temperature(units_temperature_mul_f64(a.ptr, b));
        /// <inheritdoc />
        public static Temperature operator /(Temperature a, double b) => new Temperature(units_temperature_div_f64(a.ptr, b));
        /// <inheritdoc />
        public static Temperature operator %(Temperature a, double b) => new Temperature(units_temperature_rem_f64(a.ptr, b));

        /// <inheritdoc />
        public static bool operator ==(Temperature a, Temperature b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Temperature a, Temperature b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Temperature a, Temperature b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Temperature a, Temperature b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Temperature a, Temperature b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Temperature a, Temperature b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Temperature(units_temperature_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return units_temperature_compare(ptr, ((Temperature)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return units_temperature_eq(ptr, ((Temperature)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropTools.InteropUtil.MarshallUnmanagedStringPtr(units_temperature_to_string(ptr));
        }

        /// <inheritdoc />
        ~Temperature()
        {
            units_temperature_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_new(double value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_temperature_value(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void units_temperature_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool units_temperature_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int units_temperature_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_add(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_add_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_sub(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_sub_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_mul(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_mul_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_div(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_div_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_rem(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_rem_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_from_celsius(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_from_kelvin(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_temperature_as_celsius(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_temperature_as_kelvin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_temperature_get_const_CONV_FACTOR_KELVIN_C();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_temperature_static_convert_celsius_to_kelvin(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_temperature_static_convert_kelvin_to_celsius(double val);
    }
}
