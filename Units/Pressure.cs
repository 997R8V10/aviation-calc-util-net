using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// Represents a pressure quantity.
    /// </summary>
    public class Pressure : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal Pressure(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Pressure with the default value
        /// </summary>
        public Pressure()
        {
            ptr = units_pressure_default();
        }

        /// <summary>
        /// Creates a new Pressure.
        /// </summary>
        /// <param name="val">Value in Pa (pascals)</param>
        public Pressure(double val)
        {
            ptr = units_pressure_new(val);
        }

        /// <summary>
        /// Creates a new Pressure.
        /// </summary>
        /// <param name="val">Value in Pa (pascals)</param>
        public static Pressure FromPascals(double val)
        {
            return new Pressure(units_pressure_from_pascals(val));
        }

        /// <summary>
        /// Creates a new Pressure.
        /// </summary>
        /// <param name="hectopascals">Value in hPa (hectopascals).</param>
        public static Pressure FromHectopascals(double hectopascals)
        {
            return new Pressure(units_pressure_from_hectopascals(hectopascals));
        }

        /// <summary>
        /// Creates a new Pressure.
        /// </summary>
        /// <param name="inches_of_mercury">Value in inHg (inches of mercury).</param>
        public static Pressure FromInchesOfMercury(double inches_of_mercury)
        {
            return new Pressure(units_pressure_from_inches_of_mercury(inches_of_mercury));
        }

        /// <summary>
        /// Gets the pressure in Pa (pascals).
        /// </summary>
        public double Pascals => units_pressure_as_pascals(ptr);

        /// <summary>
        /// Gets the pressure in hPa (hectopascals).
        /// </summary>
        public double Hectopascals => units_pressure_as_hectopascals(ptr);

        /// <summary>
        /// Gets the pressure in inHg (inches of mercury).
        /// </summary>
        public double InchesOfMercury => units_pressure_as_inches_of_mercury(ptr);

        /// <summary>
        /// Gets the pressure in Pa (pascals).
        /// </summary>
        public double Value()
        {
            return units_pressure_value(ptr);
        }

        /// <summary>
        /// Conversion factor from Pa (pascals) to inHg (inches of mercury)
        /// </summary>
        public static double CONV_FACTOR_PA_INHG => units_pressure_get_const_CONV_FACTOR_PA_INHG();

        /// <summary>
        /// Convert from hPa (hectopascals) to inHg (inches of mercury)
        /// </summary>
        public static double ConvertHpaToInhg(double hpa)
        {
            return units_pressure_static_convert_hPa_to_inHg(hpa);
        }

        /// <summary>
        /// Convert from Pa (pascals) to inHg (inches of mercury)
        /// </summary>
        public static double ConvertPaToInhg(double pa)
        {
            return units_pressure_static_convert_Pa_to_inHg(pa);
        }

        /// <summary>
        /// Convert from inHg (inches of mercury) to hPa (hectopascals)
        /// </summary>
        public static double ConvertInhgToHpa(double inhg)
        {
            return units_pressure_static_convert_inHg_to_hPa(inhg);
        }

        /// <summary>
        /// Convert from inHg (inches of mercury) to Pa (pascals)
        /// </summary>
        public static double ConvertInhgToPa(double inhg)
        {
            return units_pressure_static_convert_inHg_to_Pa(inhg);
        }

        /// <summary>
        /// Casts an Pressure to a double as Pa (pascals).
        /// </summary>
        public static explicit operator double(Pressure v) => v.Value();

        /// <summary>
        /// Casts a double to a Pressure as Pa (pascals).
        /// </summary>
        public static explicit operator Pressure(double v) => new Pressure(v);

        /// <inheritdoc />
        public static Pressure operator -(Pressure a) => new Pressure(units_pressure_neg(a.ptr));
        /// <inheritdoc />
        public static Pressure operator +(Pressure a, Pressure b) => new Pressure(units_pressure_add(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Pressure operator -(Pressure a, Pressure b) => new Pressure(units_pressure_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Pressure operator *(Pressure a, Pressure b) => new Pressure(units_pressure_mul(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Pressure operator /(Pressure a, Pressure b) => new Pressure(units_pressure_div(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Pressure operator %(Pressure a, Pressure b) => new Pressure(units_pressure_rem(a.ptr, b.ptr));

        /// <inheritdoc />
        public static Pressure operator +(Pressure a, double b) => new Pressure(units_pressure_add_f64(a.ptr, b));
        /// <inheritdoc />
        public static Pressure operator -(Pressure a, double b) => new Pressure(units_pressure_sub_f64(a.ptr, b));
        /// <inheritdoc />
        public static Pressure operator *(Pressure a, double b) => new Pressure(units_pressure_mul_f64(a.ptr, b));
        /// <inheritdoc />
        public static Pressure operator /(Pressure a, double b) => new Pressure(units_pressure_div_f64(a.ptr, b));
        /// <inheritdoc />
        public static Pressure operator %(Pressure a, double b) => new Pressure(units_pressure_rem_f64(a.ptr, b));

        /// <inheritdoc />
        public static bool operator ==(Pressure a, Pressure b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Pressure a, Pressure b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Pressure a, Pressure b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Pressure a, Pressure b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Pressure a, Pressure b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Pressure a, Pressure b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Pressure(units_pressure_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return units_pressure_compare(ptr, ((Pressure)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return units_pressure_eq(ptr, ((Pressure)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropTools.InteropUtil.MarshallUnmanagedStringPtr(units_pressure_to_string(ptr));
        }

        /// <inheritdoc />
        ~Pressure()
        {
            units_pressure_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_new(double value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_value(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void units_pressure_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool units_pressure_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int units_pressure_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_add(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_add_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_sub(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_sub_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_mul(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_mul_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_div(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_div_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_rem(IntPtr ptr, IntPtr rhs_ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_rem_f64(IntPtr ptr, double rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_from_pascals(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_from_hectopascals(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_from_inches_of_mercury(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_as_pascals(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_as_hectopascals(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_as_inches_of_mercury(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_get_const_CONV_FACTOR_PA_INHG();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_static_convert_Pa_to_inHg(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_static_convert_hPa_to_inHg(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_static_convert_inHg_to_Pa(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double units_pressure_static_convert_inHg_to_hPa(double val);
    }
}
