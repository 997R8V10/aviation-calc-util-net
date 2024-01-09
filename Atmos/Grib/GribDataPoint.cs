using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;

namespace AviationCalcUtilNet.Atmos.Grib
{
    public class GribDataPoint : ICloneable
    {
        internal IntPtr ptr;

        public GribDataPoint()
        {
            ptr = atmos_grib_grib_data_point_default();
        }

        public GribDataPoint(Latitude lat, Longitude lon, Pressure level)
        {
            ptr = atmos_grib_grib_data_point_new(lat.ptr, lon.ptr, level.ptr);
        }

        internal GribDataPoint(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public Length DistanceFrom(GeoPoint pos)
        {
            return new Length(atmos_grib_grib_data_point_distance_from(ptr, pos.ptr));
        }

        public Latitude Lat
        {
            get => new Latitude(atmos_grib_grib_data_point_lat(ptr));
            set => atmos_grib_grib_data_point_set_lat(ptr, value.ptr);
        }

        public Longitude Lon
        {
            get => new Longitude(atmos_grib_grib_data_point_lon(ptr));
            set => atmos_grib_grib_data_point_set_lon(ptr, value.ptr);
        }

        public Length GeoPotentialHeight
        {
            get => new Length(atmos_grib_grib_data_point_geo_pot_height(ptr));
            set => atmos_grib_grib_data_point_set_geo_pot_height(ptr, value.ptr);
        }

        public Pressure LevelPressure
        {
            get => new Pressure(atmos_grib_grib_data_point_level_pressure(ptr));
            set => atmos_grib_grib_data_point_set_level_pressure(ptr, value.ptr);
        }

        public Temperature Temp
        {
            get => new Temperature(atmos_grib_grib_data_point_temp(ptr));
            set => atmos_grib_grib_data_point_set_temp(ptr, value.ptr);
        }

        public Velocity V
        {
            get => new Velocity(atmos_grib_grib_data_point_v(ptr));
            set => atmos_grib_grib_data_point_set_v(ptr, value.ptr);
        }

        public Velocity U
        {
            get => new Velocity(atmos_grib_grib_data_point_u(ptr));
            set => atmos_grib_grib_data_point_set_u(ptr, value.ptr);
        }

        public (Bearing windDir, Velocity windSpd) Wind
        {
            get
            {
                var str = atmos_grib_grib_data_point_wind(ptr);
                return (new Bearing(str.dir), new Velocity(str.spd));
            }
        }

        public double RelativeHumidity
        {
            get => atmos_grib_grib_data_point_rh(ptr);
            set => atmos_grib_grib_data_point_set_rh(ptr, value);
        }

        public Pressure SfcPress
        {
            get => new Pressure(atmos_grib_grib_data_point_sfc_press(ptr));
            set => atmos_grib_grib_data_point_set_sfc_press(ptr, value.ptr);
        }

        /// <inheritdoc />
        public static bool operator ==(GribDataPoint a, GribDataPoint b) => Equals(a, b);
        /// <inheritdoc />
        public static bool operator !=(GribDataPoint a, GribDataPoint b) => !Equals(a, b);

        /// <inheritdoc />
        public object Clone()
        {
            return new GribDataPoint(atmos_grib_grib_data_point_clone(ptr));
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return atmos_grib_grib_data_point_eq(ptr, ((GribDataPoint)obj).ptr);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return ptr.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return InteropTools.InteropUtil.MarshallUnmanagedStringPtr(atmos_grib_grib_data_point_to_string(ptr));
        }

        /// <inheritdoc />
        ~GribDataPoint()
        {
            atmos_grib_grib_data_point_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_clone(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_default();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_distance_from(IntPtr ptr, IntPtr point);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool atmos_grib_grib_data_point_eq(IntPtr ptr, IntPtr rhs);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_geo_pot_height(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_lat(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_level_pressure(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_lon(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_new(IntPtr lat, IntPtr lon, IntPtr level_pressure);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_grib_grib_data_point_rh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_geo_pot_height(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_lat(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_level_pressure(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_lon(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_rh(IntPtr ptr, double val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_sfc_press(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_temp(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_u(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void atmos_grib_grib_data_point_set_v(IntPtr ptr, IntPtr val);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_sfc_press(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_temp(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_to_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_u(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_grib_grib_data_point_v(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropWindStruct atmos_grib_grib_data_point_wind(IntPtr ptr);
    }
}
