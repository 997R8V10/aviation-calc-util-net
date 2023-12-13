using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    /// <summary>
    /// Represents a bearing from 0 to 2pi rads (radians) or 0 to 360° (degrees).
    /// </summary>
    public class Bearing
    {
        internal IntPtr ptr;

        internal Bearing(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Bearing with the default value.
        /// </summary>
        public Bearing()
        {
            ptr = geo_bearing_default();
        }

        /// <summary>
        /// Creates a new Bearing.
        /// </summary>
        public Bearing(Angle val)
        {
            ptr = geo_bearing_new(val.ptr);
        }

        /// <summary>
        /// Creates a new Bearing.
        /// </summary>
        /// <param name="val">Value in rads (radians)</param>
        public static Bearing FromRadians(double val)
        {
            return new Bearing(geo_bearing_from_radians(val));
        }

        /// <summary>
        /// Creates a new Bearing.
        /// </summary>
        /// <param name="val">Value in ° (degrees)</param>
        public static Bearing FromDegrees(double val)
        {
            return new Bearing(geo_bearing_from_degrees(val));
        }

        /// <summary>
        /// Gets the Bearing as an Angle
        /// </summary>
        public Angle Angle => new Angle(geo_bearing_as_angle(ptr));

        /// <summary>
        /// Gets the Bearing in rads (radians).
        /// </summary>
        public double Radians => geo_bearing_as_radians(ptr);

        /// <summary>
        /// Gets the Bearing in ° (degrees).
        /// </summary>
        public double Degrees => geo_bearing_as_degrees(ptr);


        /// <inheritdoc />
        public static Bearing operator +(Bearing a, Angle b) => new Bearing(geo_bearing_add_angle(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Angle operator -(Bearing a, Bearing b) => new Angle(geo_bearing_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static Bearing operator -(Bearing a, Angle b) => new Bearing(geo_bearing_sub_angle(a.ptr, b.ptr));
        /// <inheritdoc />
        public static bool operator ==(Bearing a, Bearing b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Bearing a, Bearing b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Bearing a, Bearing b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Bearing a, Bearing b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Bearing a, Bearing b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Bearing a, Bearing b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Bearing(geo_bearing_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return geo_bearing_compare(ptr, ((Bearing)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return geo_bearing_eq(ptr, ((Bearing)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Radians.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropUtil.MarshallUnmanagedStringPtr(geo_bearing_to_string(ptr));
        }

        /// <inheritdoc />
        ~Bearing()
        {
            geo_bearing_drop(ptr);
        }

        /// <summary>
        /// Normalizes angle between 0 to 2pi rads (radians) or 0 to 360° (degrees).
        /// </summary>
        /// <param name="val">Input Angle</param>
        /// <returns>Normalized Angle</returns>
        public static Angle NormalizeBearing(Angle val)
        {
            return new Angle(geo_bearing_normalize_bearing(val.ptr));
        }

        /// <summary>
        /// Calculate the amount of turn for the shortest turn between two bearings. <br />
        /// Positive indicates right turn, Negative indicates left turn.
        /// </summary>
        public static Angle CalculateBearingDelta(Bearing bearing1, Bearing bearing2)
        {
            return new Angle(geo_bearing_calculate_bearing_delta(bearing1.ptr, bearing2.ptr));
        }

        /// <summary>
        /// Calculates the amount of turn for a turn from one bearing to another. <br />
        /// Positive indicates right turn, Negative indicates left turn.
        /// </summary>
        public static Angle CalculateBearingDelta(Bearing bearing1, Bearing bearing2, bool isRightTurn)
        {
            return new Angle(geo_bearing_calculate_bearing_delta_with_dir(bearing1.ptr, bearing2.ptr, isRightTurn));
        }

        /// <summary>
        /// Calculates the end bearing given start bearing and turn amount <br />
        /// A negative bearing_delta indicates a left turn.
        /// </summary>
        public static Bearing CalculateEndBearing(Bearing startBearing, Angle bearingDelta)
        {
            return new Bearing(geo_bearing_calculate_end_bearing(startBearing.ptr, bearingDelta.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_add_angle(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_as_angle(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double geo_bearing_as_degrees(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double geo_bearing_as_radians(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_calculate_bearing_delta(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_calculate_bearing_delta_with_dir(IntPtr ptr, IntPtr other, bool isRightTurn);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_calculate_end_bearing(IntPtr ptr, IntPtr delta);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int geo_bearing_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_bearing_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool geo_bearing_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_from_degrees(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_from_radians(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_neg(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_new(IntPtr value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_normalize_bearing(IntPtr value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_sub(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_sub_angle(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_bearing_to_string(IntPtr ptr);
    }
}
