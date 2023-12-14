using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    /// <summary>
    /// Represents a latitude on a globe
    /// </summary>
    public class Latitude : ICloneable, IComparable
    {
        internal IntPtr ptr;

        internal Latitude(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Latitude with the default value.
        /// </summary>
        public Latitude()
        {
            ptr = geo_latitude_default();
        }

        /// <summary>
        /// Creates a new Latitude.
        /// </summary>
        public Latitude(Angle val)
        {
            ptr = geo_latitude_new(val.ptr);
        }

        /// <summary>
        /// Creates a new Latitude.
        /// </summary>
        /// <param name="val">Value in rads (radians)</param>
        public static Latitude FromRadians(double val)
        {
            return new Latitude(geo_latitude_from_radians(val));
        }

        /// <summary>
        /// Creates a new Latitude.
        /// </summary>
        /// <param name="val">Value in ° (degrees)</param>
        public static Latitude FromDegrees(double val)
        {
            return new Latitude(geo_latitude_from_degrees(val));
        }

        /// <summary>
        /// Creates a new Latitude from degrees, mins, secs
        /// </summary>
        public static Latitude FromDegMinSec(int degrees, uint mins, double secs)
        {
            return new Latitude(geo_latitude_from_deg_min_sec(new DegMinSec() { degrees = degrees, mins = mins, secs = secs }));
        }

        /// <summary>
        /// Creates a new latitude from SCT format. <br />
        /// String should be formatted like `N049.52.27.771`
        /// </summary>
        /// <exception cref="InvalidOperationException">Coordinate String is invalid</exception>
        public static Latitude FromVrc(string vrc)
        {
            IntPtr ptr = geo_latitude_from_vrc(vrc);
            if (ptr == IntPtr.Zero)
            {
                throw new InvalidOperationException($"{vrc} was invalid!");
            }
            return new Latitude(ptr);
        }

        /// <summary>
        /// Creates a new latitude from the NATS format used in AIPs.
        /// </summary>
        /// <exception cref="InvalidOperationException">Coordinate String is invalid</exception>
        public static Latitude FromNats(string nats)
        {
            IntPtr ptr = geo_latitude_from_nats(nats);
            if (ptr == IntPtr.Zero)
            {
                throw new InvalidOperationException($"{nats} was invalid!");
            }
            return new Latitude(ptr);
        }

        /// <summary>
        /// Gets the latitude as an Angle
        /// </summary>
        public Angle Angle => new Angle(geo_latitude_as_angle(ptr));

        /// <summary>
        /// Gets the Latitude in rads (radians).
        /// </summary>
        public double Radians => geo_latitude_as_radians(ptr);

        /// <summary>
        /// Gets the Latitude in ° (degrees).
        /// </summary>
        public double Degrees => geo_latitude_as_degrees(ptr);

        /// <summary>
        /// Gets the Latitude in degrees, mins, secs
        /// </summary>
        public (int degrees, uint mins, double secs) DegMinSec
        {
            get
            {
                var s = geo_latitude_as_deg_min_sec(ptr);
                return (s.degrees, s.mins, s.secs);
            }
        }

        /// <summary>
        /// Gets the latitude as a SCT string
        /// </summary>
        public string Vrc => InteropUtil.MarshallUnmanagedStringPtr(geo_latitude_as_vrc(ptr));

        /// <summary>
        /// Gets the latitude as a NATS string
        /// </summary>
        public string Nats => InteropUtil.MarshallUnmanagedStringPtr(geo_latitude_as_nats(ptr));

        /// <summary>
        /// Casts a Latitude to a double as ° (degrees).
        /// </summary>
        public static explicit operator double(Latitude v) => v.Degrees;

        /// <summary>
        /// Casts a double to a Latitude as ° (degrees).
        /// </summary>
        public static explicit operator Latitude(double v) => FromDegrees(v);

        /// <summary>
        /// Casts a Latitude to an Angle
        /// </summary>
        public static explicit operator Angle(Latitude v) => v.Angle;

        /// <summary>
        /// Casts an Angle to a Latitude.
        /// </summary>
        public static explicit operator Latitude(Angle v) => new Latitude(v);

        /// <inheritdoc />
        public static bool operator ==(Latitude a, Latitude b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Latitude a, Latitude b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Latitude a, Latitude b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Latitude a, Latitude b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Latitude a, Latitude b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Latitude a, Latitude b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Latitude(geo_latitude_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return geo_latitude_compare(ptr, ((Latitude)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return geo_latitude_eq(ptr, ((Latitude)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Radians.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropUtil.MarshallUnmanagedStringPtr(geo_latitude_to_string(ptr));
        }

        /// <inheritdoc />
        ~Latitude()
        {
            geo_latitude_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_new(IntPtr value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_latitude_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool geo_latitude_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int geo_latitude_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_from_radians(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_from_degrees(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_from_deg_min_sec(DegMinSec val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_from_vrc([MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_from_nats([MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_as_angle(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double geo_latitude_as_radians(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double geo_latitude_as_degrees(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern DegMinSec geo_latitude_as_deg_min_sec(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_as_vrc(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_latitude_as_nats(IntPtr ptr);
    }
}
