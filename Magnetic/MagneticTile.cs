using AviationCalcUtilNet.Atmos.Grib;
using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Magnetic
{
    public class MagneticTile : IGeoTile, ICloneable
    {
        internal IntPtr ptr;

        internal MagneticTile(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public MagneticTile()
        {
            ptr = magnetic_magnetic_tile_default();
        }

        public MagneticTile(GeoPoint point, DateTime date, MagneticModel model)
        {
            ptr = magnetic_magnetic_tile_new(point.ptr, InteropUtil.ManagedDateToDateStruct(date), model.ptr);
        }

        public bool IsValid(GeoPoint point, DateTime date)
        {
            return magnetic_magnetic_tile_is_valid(ptr, point.ptr, InteropUtil.ManagedDateToDateStruct(date));
        }

        public bool IsPointInTile(GeoPoint point)
        {
            return magnetic_magnetic_tile_is_point_in_tile(ptr, point.ptr);
        }

        public GeoTileBounds Bounds
        {
            get => new GeoTileBounds(magnetic_magnetic_tile_bounds(ptr));
            set => magnetic_magnetic_tile_set_bounds(ptr, value.ptr);
        }

        public DateTime Date
        {
            get => InteropUtil.DateStructToManagedDate(magnetic_magnetic_tile_date(ptr));
            set => magnetic_magnetic_tile_set_date(ptr, InteropUtil.ManagedDateToDateStruct(value));
        }

        public MagneticField Field
        {
            get => new MagneticField(magnetic_magnetic_tile_field(ptr));
            set => magnetic_magnetic_tile_set_field(ptr, value.ptr);
        }

        public GeoPoint CenterPoint => new GeoPoint(magnetic_magnetic_tile_center_point(ptr));

        public Latitude TopLat => new Latitude(magnetic_magnetic_tile_top_lat(ptr));

        public Latitude BottomLat => new Latitude(magnetic_magnetic_tile_bottom_lat(ptr));

        public Longitude LeftLon => new Longitude(magnetic_magnetic_tile_left_lon(ptr));

        public Longitude RightLon => new Longitude(magnetic_magnetic_tile_right_lon(ptr));

        public static Angle MAG_TILE_RES => new Angle(magnetic_magnetic_tile_get_const_MAG_TILE_RES());

        /// <inheritdoc />
        public static bool operator ==(MagneticTile a, MagneticTile b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(MagneticTile a, MagneticTile b) => !Equals(a, b);

        /// <inheritdoc />
        public object Clone()
        {
            return new MagneticTile(magnetic_magnetic_tile_clone(ptr));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return magnetic_magnetic_tile_eq(ptr, ((MagneticTile)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return ptr.GetHashCode();
        }

        /// <inheritdoc />
        ~MagneticTile()
        {
            magnetic_magnetic_tile_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_bottom_lat(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_bounds(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_center_point(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropDateStruct magnetic_magnetic_tile_date(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_tile_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool magnetic_magnetic_tile_eq(IntPtr ptr, IntPtr other);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_field(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_get_const_MAG_TILE_RES();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool magnetic_magnetic_tile_is_point_in_tile(IntPtr ptr, IntPtr point);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool magnetic_magnetic_tile_is_valid(IntPtr ptr, IntPtr point, InteropDateStruct date);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_left_lon(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_new(IntPtr ptr, InteropDateStruct date, IntPtr model);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_right_lon(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_tile_set_bounds(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_tile_set_date(IntPtr ptr, InteropDateStruct val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_tile_set_field(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_top_lat(IntPtr ptr);
    }
}
