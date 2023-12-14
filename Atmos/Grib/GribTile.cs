using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Atmos.Grib
{
    public class GribTile : IGeoTile
    {
        internal IntPtr ptr;

        public GribTile(GeoPoint pos, DateTime dateTime, string downloadPath)
        {
            ptr = grib_grib_tile_new(pos.ptr, InteropUtil.ManagedDateToDateTimeStruct(dateTime), downloadPath);
        }

        internal GribTile(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public Latitude TopLat => new Latitude(grib_grib_tile_top_lat(ptr));

        public Latitude BottomLat => new Latitude(grib_grib_tile_bottom_lat(ptr));

        public Longitude LeftLon => new Longitude(grib_grib_tile_left_lon(ptr));

        public Longitude RightLon => new Longitude(grib_grib_tile_right_lon(ptr));

        public GeoPoint CenterPoint => new GeoPoint(grib_grib_tile_center_point(ptr));

        public DateTime ForecastDateUtc => InteropUtil.DateTimeStructToManagedDate(grib_grib_tile_forecast_date_utc(ptr));

        public string GribFileName
        {
            get
            {
                return InteropUtil.MarshallUnmanagedStringPtr(grib_grib_tile_grib_file_name(ptr));
            }
        }

        public string DownloadUrl
        {
            get
            {
                return InteropUtil.MarshallUnmanagedStringPtr(grib_grib_tile_download_url(ptr));
            }
        }

        public GribDataPoint GetClosestPoint(GeoPoint acftPos)
        {
            IntPtr retPtr = grib_grib_tile_closest_point(ptr, acftPos.ptr);

            if (retPtr == IntPtr.Zero)
            {
                return null;
            }

            return new GribDataPoint(retPtr);
        }

        public bool IsValid(DateTime dateTime)
        {
            return grib_grib_tile_is_valid(ptr, InteropUtil.ManagedDateToDateTimeStruct(dateTime));
        }

        public bool IsPointInTile(GeoPoint pos)
        {
            return grib_grib_tile_is_point_in_tile(ptr, pos.ptr);
        }

        ~GribTile()
        {
            grib_grib_tile_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_new(IntPtr pos, InteropDateTimeStruct dateTime, [MarshalAs(UnmanagedType.LPStr)] string download_path);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void grib_grib_tile_drop(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropDateTimeStruct grib_grib_tile_forecast_date_utc(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_grib_file_name(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_download_url(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_closest_point(IntPtr tile, IntPtr acftPos);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool grib_grib_tile_is_valid(IntPtr tile, InteropDateTimeStruct dateTime);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern bool grib_grib_tile_is_point_in_tile(IntPtr tile, IntPtr point);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_center_point(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_bottom_lat(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_top_lat(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_left_lon(IntPtr tile);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_right_lon(IntPtr tile);
    }
}
