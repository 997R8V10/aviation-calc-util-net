using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Magnetic
{
    /// <summary>
    /// A Thread-Safe Manager for Magnetic Conversions.
    /// This increases performance by caching magnetic calculations
    /// </summary>
    public class MagneticTileManager
    {
        internal IntPtr ptr;

        internal MagneticTileManager(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public MagneticTileManager(ref MagneticModel model)
        {
            ptr = magnetic_magnetic_tile_manager_new(model.ptr);
            model = null;
        }

        public MagneticTile FindOrCreateTile(GeoPoint point, DateTime date)
        {
            return new MagneticTile(magnetic_magnetic_tile_manager_find_or_create_tile(ptr, point.ptr, InteropUtil.ManagedDateToDateStruct(date)));
        }

        public Bearing TrueToMagnetic(GeoPoint point, DateTime date, Bearing trueBearing)
        {
            return new Bearing(magnetic_magnetic_tile_manager_true_to_magnetic(ptr, point.ptr, InteropUtil.ManagedDateToDateStruct(date), trueBearing.ptr));
        }
        public Bearing MagneticToTrue(GeoPoint point, DateTime date, Bearing magneticBearing)
        {
            return new Bearing(magnetic_magnetic_tile_manager_magnetic_to_true(ptr, point.ptr, InteropUtil.ManagedDateToDateStruct(date), magneticBearing.ptr));
        }

        ~MagneticTileManager() {
            magnetic_magnetic_tile_manager_drop(ptr);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void magnetic_magnetic_tile_manager_drop(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_manager_find_or_create_tile(IntPtr ptr, IntPtr point, InteropDateStruct date);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_manager_magnetic_to_true(IntPtr ptr, IntPtr point, InteropDateStruct date, IntPtr magnetic_bearing);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_manager_new(IntPtr model);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr magnetic_magnetic_tile_manager_true_to_magnetic(IntPtr ptr, IntPtr point, InteropDateStruct date, IntPtr true_bearing);
    }
}
