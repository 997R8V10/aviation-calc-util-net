using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.GeoTools
{
	public class GeoTile
	{
		internal IntPtr ptr;

		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr CreateGeoTile(double botLat, double topLat, double leftLon, double rightLon);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr CreateGeoTileFromGeoPoint(IntPtr point, double resolutionDegs);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr CopyGeoTile(IntPtr point);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void DisposeGeoTile(IntPtr tile);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern bool GeoTileIsPointInTile(IntPtr tile, IntPtr point);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr GeoTileGetCenterPoint(IntPtr tile);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GeoTileGetBottomLat(IntPtr tile);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GeoTileGetTopLat(IntPtr tile);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GeoTileGetLeftLon(IntPtr tile);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double GeoTileGetRightLon(IntPtr tile);

		public GeoTile(double botLat, double topLat, double leftLon, double rightLon)
		{
			ptr = CreateGeoTile(botLat, topLat, leftLon, rightLon);
		}

		internal GeoTile(IntPtr ptr)
		{
			this.ptr = ptr;
		}

		public GeoTile(GeoTile tile)
		{
			ptr = CopyGeoTile(tile.ptr);
		}

		public bool IsPointInTile(GeoPoint point)
		{
			return GeoTileIsPointInTile(ptr, point.ptr);
		}

		public static bool operator ==(GeoTile tile, GeoPoint point)
		{
			return GeoTileIsPointInTile(tile.ptr, point.ptr);
		}

		public static bool operator !=(GeoTile tile, GeoPoint point)
		{
			return !GeoTileIsPointInTile(tile.ptr, point.ptr);
		}

		public GeoPoint CenterPoint {
			get {
				IntPtr cPt = GeoTileGetCenterPoint(ptr);
				if (cPt == IntPtr.Zero)
				{
					return null;
				}
				return new GeoPoint(cPt);
			}
		}

		public double BottomLat => GeoTileGetBottomLat(ptr);

		public double TopLat => GeoTileGetTopLat(ptr);

		public double LeftLon => GeoTileGetLeftLon(ptr);

		public double RightLon => GeoTileGetRightLon(ptr);
	}
}
