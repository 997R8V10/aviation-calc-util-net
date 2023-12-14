using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.Magnetic;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    public class GeoTileBounds : IGeoTile, ICloneable
    {
        internal IntPtr ptr;

        public Latitude BottomLat => new Latitude(geo_geo_tile_bounds_bottom_lat(ptr));

        public Latitude TopLat => new Latitude(geo_geo_tile_bounds_top_lat(ptr));

        public Longitude LeftLon => new Longitude(geo_geo_tile_bounds_left_lon(ptr));

        public Longitude RightLon => new Longitude(geo_geo_tile_bounds_right_lon(ptr));

        public GeoPoint CenterPoint => new GeoPoint(geo_geo_tile_bounds_center_point(ptr));

        internal GeoTileBounds(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public GeoTileBounds()
        {
            ptr = geo_geo_tile_bounds_default();
        }

        public GeoTileBounds(Latitude botLat, Latitude topLat, Longitude leftLon, Longitude rightLon)
        {
            ptr = geo_geo_tile_bounds_new(botLat.ptr, topLat.ptr, leftLon.ptr, rightLon.ptr);
        }

        public GeoTileBounds(GeoPoint point, Angle resolution)
        {
            ptr = geo_geo_tile_bounds_new_from_point(point.ptr, resolution.ptr);
        }

        public bool IsPointInTile(GeoPoint point)
        {
            return geo_geo_tile_bounds_is_point_in_tile(ptr, point.ptr);
        }

        /// <inheritdoc />
        public static bool operator ==(GeoTileBounds a, GeoTileBounds b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(GeoTileBounds a, GeoTileBounds b) => !Equals(a, b);

        /// <inheritdoc />
        public object Clone()
        {
            return new GeoTileBounds(geo_geo_tile_bounds_clone(ptr));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return geo_geo_tile_bounds_eq(ptr, ((GeoTileBounds)obj).ptr);
        }

        ~GeoTileBounds() {
            geo_geo_tile_bounds_drop(ptr);
        }
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_bottom_lat(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_center_point(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void geo_geo_tile_bounds_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool geo_geo_tile_bounds_eq(IntPtr a, IntPtr b);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool geo_geo_tile_bounds_is_point_in_tile(IntPtr ptr, IntPtr point);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_left_lon(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_new(IntPtr bot_lat, IntPtr top_lat, IntPtr leftLon, IntPtr rightLon);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_new_from_point(IntPtr point, IntPtr resolution);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_right_lon(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr geo_geo_tile_bounds_top_lat(IntPtr ptr);
    }
}
