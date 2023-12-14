using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Atmos.Grib
{
    /// <summary>
    /// A Thread-Safe Manager for Grib Data access.
    /// </summary>
    public class GribTileManager
    {
        internal IntPtr ptr;

        internal GribTileManager(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public GribTileManager(string downloadPath)
        {
            ptr = grib_grib_tile_manager_new(downloadPath);
        }

        public GribTile FindOrCreateTile(GeoPoint point, DateTime date)
        {
            return new GribTile(grib_grib_tile_manager_find_or_create_tile(ptr, point.ptr, InteropUtil.ManagedDateToDateTimeStruct(date)));
        }

        ~GribTileManager() {
            grib_grib_tile_manager_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void grib_grib_tile_manager_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_manager_find_or_create_tile(IntPtr ptr, IntPtr point, InteropDateTimeStruct date);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr grib_grib_tile_manager_new([MarshalAs(UnmanagedType.LPStr)] string download_path);
    }
}
