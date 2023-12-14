using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.Units;
using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.GeoTools
{
    /// <summary>
    /// Represents a 3D Coordinate Point on the globe.
    /// </summary>
    public class GeoPoint : ICloneable
    {
        internal IntPtr ptr;

        /// <summary>
        /// Creates a new GeoPoint
        /// </summary>
        public GeoPoint()
        {
            ptr = geo_geo_point_default();
        }

        /// <summary>
        /// Creates a new GeoPoint
        /// </summary>
        public GeoPoint(Latitude lat, Longitude lon, Length alt)
        {
            ptr = geo_geo_point_new(lat.ptr, lon.ptr, alt.ptr);
        }

        /// <summary>
        /// Creates a new GeoPoint
        /// </summary>
        public GeoPoint(Latitude lat, Longitude lon)
        {
            ptr = geo_geo_point_new(lat.ptr, lon.ptr, new Length().ptr);
        }

        internal GeoPoint(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        /// <summary>
        /// Moves the GeoPoint on a bearing by a distance
        /// </summary>
        public void MoveBy(Bearing bearing, Length distance)
        {
            geo_geo_point_move_by(ptr, bearing.ptr, distance.ptr);
        }

        /// <summary>
        /// Calculates the flat distance between two GeoPoints
        /// </summary>
        public static Length FlatDistance(GeoPoint point1, GeoPoint point2)
        {
            return new Length(geo_geo_point_flat_distance(point1.ptr, point2.ptr));
        }

        /// <summary>
        /// Calculates the distance including altitude between two GeoPoints
        /// </summary>
        public static Length Distance(GeoPoint point1, GeoPoint point2)
        {
            return new Length(geo_geo_point_distance(point1.ptr, point2.ptr));
        }

        /// <summary>
        /// Calculates the intersection between two points and two courses
        /// </summary>
        /// <remarks>This function will not account for reciprocal of the bearings</remarks>
        public static GeoPoint Intersection(GeoPoint point1, Bearing bearing1, GeoPoint point2, Bearing bearing2)
        {
            IntPtr ptr = geo_geo_point_intersection(point1.ptr, bearing1.ptr, point2.ptr, bearing2.ptr);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            return new GeoPoint(ptr);
        }

        /// <summary>
        /// Find closest intersection between two points and two radials.
        /// </summary>
        /// <remarks>This function will try both the radial and the reciprocal</remarks>
        public static GeoPoint FindClosestIntersection(GeoPoint point1, Bearing radial1, GeoPoint point2, Bearing radial2)
        {
            IntPtr ptr = geo_geo_point_closest_intersection(point1.ptr, radial1.ptr, point2.ptr, radial2.ptr);
            if (ptr == IntPtr.Zero)
            {
                return null;
            }

            return new GeoPoint(ptr);
        }

        /// <summary>
        /// Calculates initial bearing from one GeoPoint to other
        /// </summary>
        public static Bearing InitialBearing(GeoPoint point1, GeoPoint point2)
        {
            return new Bearing(geo_geo_point_initial_bearing(point1.ptr, point2.ptr));
        }

        /// <summary>
        /// Calculates final bearing from one GeoPoint to other
        /// </summary>ram>
        /// <returns></returns>
        public static Bearing FinalBearing(GeoPoint point1, GeoPoint point2)
        {
            return new Bearing(geo_geo_point_final_bearing(point1.ptr, point2.ptr));
        }

        /// <summary>
        /// Latitude
        /// </summary>
        public Latitude Lat {
            get => new Latitude(geo_geo_point_lat(ptr));
            set => geo_geo_point_set_lat(ptr, value.ptr);
        }

        /// <summary>
        /// Longitude
        /// </summary>
        public Longitude Lon {
            get => new Longitude(geo_geo_point_lon(ptr));
            set => geo_geo_point_set_lon(ptr, value.ptr);
        }

        /// <summary>
        /// Altitude
        /// </summary>
        public Length Alt {
            get => new Length(geo_geo_point_alt(ptr));
            set => geo_geo_point_set_alt(ptr, value.ptr);
        }

        /// <inheritdoc />
        public static Length operator -(GeoPoint a, GeoPoint b) => new Length(geo_geo_point_sub(a.ptr, b.ptr));
        /// <inheritdoc />
        public static bool operator ==(GeoPoint a, GeoPoint b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(GeoPoint a, GeoPoint b) => !Equals(a, b);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return geo_geo_point_eq(ptr, ((GeoPoint)obj).ptr);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hashCode = Lat.GetHashCode() & 65535;
            hashCode <<= 16;
            hashCode += Lon.GetHashCode() & 65535;
            return hashCode;
        }

        /// <inheritdoc />
        public object Clone()
        {
            return new GeoPoint(geo_geo_point_clone(ptr));
        }

        ~GeoPoint()
        {
            geo_geo_point_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_alt(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_closest_intersection(IntPtr ptr, IntPtr bearing1, IntPtr other, IntPtr bearing2);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_distance(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_geo_point_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool geo_geo_point_eq(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_final_bearing(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_flat_distance(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_initial_bearing(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_intersection(IntPtr ptr, IntPtr bearing1, IntPtr other, IntPtr bearing2);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_lat(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_lon(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_geo_point_move_by(IntPtr ptr, IntPtr bearing, IntPtr distance);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_new(IntPtr lat, IntPtr lon, IntPtr alt);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_geo_point_set_alt(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_geo_point_set_lat(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_geo_point_set_lon(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_point_sub(IntPtr ptr, IntPtr rhs);
    }
}