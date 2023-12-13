using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    /// <summary>
    /// Represents a longitude on a globe
    /// </summary>
    public class Longitude : IComparable, ICloneable
    {
        internal IntPtr ptr;

        internal Longitude(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Creates a new Longitude with the default value.
        /// </summary>
        public Longitude()
        {
            ptr = geo_longitude_default();
        }

        /// <summary>
        /// Creates a new Longitude.
        /// </summary>
        public Longitude(Angle val)
        {
            ptr = geo_longitude_new(val.ptr);
        }

        /// <summary>
        /// Creates a new Longitude.
        /// </summary>
        /// <param name="val">Value in rads (radians)</param>
        public static Longitude FromRadians(double val)
        {
            return new Longitude(geo_longitude_from_radians(val));
        }

        /// <summary>
        /// Creates a new Longitude.
        /// </summary>
        /// <param name="val">Value in ° (degrees)</param>
        public static Longitude FromDegrees(double val)
        {
            return new Longitude(geo_longitude_from_degrees(val));
        }

        /// <summary>
        /// Creates a new Longitude from degrees, mins, secs
        /// </summary>
        public static Longitude FromDegMinSec(int degrees, uint mins, double secs)
        {
            return new Longitude(geo_longitude_from_deg_min_sec(new DegMinSec() { degrees = degrees, mins = mins, secs = secs }));
        }

        /// <summary>
        /// Creates a new Longitude from SCT format. <br />
        /// String should be formatted like `N049.52.27.771`
        /// </summary>
        /// <exception cref="InvalidOperationException">Coordinate String is invalid</exception>
        public static Longitude FromVrc(string vrc)
        {
            IntPtr ptr = geo_longitude_from_vrc(vrc);
            if (ptr == IntPtr.Zero)
            {
                throw new InvalidOperationException($"{vrc} was invalid!");
            }
            return new Longitude(ptr);
        }

        /// <summary>
        /// Creates a new Longitude from the NATS format used in AIPs.
        /// </summary>
        /// <exception cref="InvalidOperationException">Coordinate String is invalid</exception>
        public static Longitude FromNats(string nats)
        {
            IntPtr ptr = geo_longitude_from_nats(nats);
            if (ptr == IntPtr.Zero)
            {
                throw new InvalidOperationException($"{nats} was invalid!");
            }
            return new Longitude(ptr);
        }

        /// <summary>
        /// Gets the Longitude as an Angle
        /// </summary>
        public Angle Angle => new Angle(geo_longitude_as_angle(ptr));

        /// <summary>
        /// Gets the Longitude in rads (radians).
        /// </summary>
        public double Radians => geo_longitude_as_radians(ptr);

        /// <summary>
        /// Gets the Longitude in ° (degrees).
        /// </summary>
        public double Degrees => geo_longitude_as_degrees(ptr);

        /// <summary>
        /// Gets the Longitude in degrees, mins, secs
        /// </summary>
        public (int degrees, uint mins, double secs) DegMinSec
        {
            get
            {
                var s = geo_longitude_as_deg_min_sec(ptr);
                return (s.degrees, s.mins, s.secs);
            }
        }

        /// <summary>
        /// Gets the Longitude as a SCT string
        /// </summary>
        public string Vrc => InteropUtil.MarshallUnmanagedStringPtr(geo_longitude_as_vrc(ptr));

        /// <summary>
        /// Gets the Longitude as a NATS string
        /// </summary>
        public string Nats => InteropUtil.MarshallUnmanagedStringPtr(geo_longitude_as_nats(ptr));

        /// <inheritdoc />
        public static bool operator ==(Longitude a, Longitude b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(Longitude a, Longitude b) => !Equals(a, b);
        /// <inheritdoc />
        public static bool operator <(Longitude a, Longitude b) => a != null && a.CompareTo(b) < 0;
        /// <inheritdoc />
        public static bool operator >(Longitude a, Longitude b) => a != null && a.CompareTo(b) > 0;
        /// <inheritdoc />
        public static bool operator <=(Longitude a, Longitude b) => a != null && a.CompareTo(b) <= 0;
        /// <inheritdoc />
        public static bool operator >=(Longitude a, Longitude b) => a != null && a.CompareTo(b) >= 0;

        /// <inheritdoc />
        public object Clone()
        {
            return new Longitude(geo_longitude_clone(ptr));
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return 1;
            }

            return geo_longitude_compare(ptr, ((Longitude)obj).ptr);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return geo_longitude_eq(ptr, ((Longitude)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Radians.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropUtil.MarshallUnmanagedStringPtr(geo_longitude_to_string(ptr));
        }

        /// <inheritdoc />
        ~Longitude()
        {
            geo_longitude_drop(ptr);
        }

        /// <summary>
        /// Normalizes Longitude.
        /// </summary>
        /// <param name="angle">Input Longitude</param>
        /// <returns>Normalized Longitude</returns>
        public static Angle NormalizeLongitude(Angle angle)
        {
            return new Angle(geo_longitude_normalize_longitude(angle.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_new(IntPtr value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_longitude_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool geo_longitude_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern int geo_longitude_compare(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_from_radians(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_from_degrees(double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_from_deg_min_sec(DegMinSec val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_from_vrc([MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_from_nats([MarshalAs(UnmanagedType.LPStr)] string value);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_as_angle(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double geo_longitude_as_radians(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double geo_longitude_as_degrees(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern DegMinSec geo_longitude_as_deg_min_sec(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_as_vrc(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_as_nats(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_longitude_normalize_longitude(IntPtr ptr);
    }
}
