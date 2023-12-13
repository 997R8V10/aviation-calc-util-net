using System;
using System.IO;
using System.Threading;
using AviationCalcUtilNet.Atmos.Grib;
using AviationCalcUtilNet.GeoTools;
using NUnit.Framework;

namespace AviationCalcUtilNetTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        public void TestFetchGribTile1()
        {
            var geoPoint = new GeoPoint(0, 0);
            var manager = new GribTileManager(Path.Combine(Path.GetTempPath(), "grib_tile_tests", "grib_tiles"));
            var tile = manager.FindOrCreateTile(geoPoint, DateTime.UtcNow);
            Assert.NotNull(tile);
            GribDataPoint point;
            int i = 0;
            while ((point = tile.GetClosestPoint(geoPoint)) == null && i < 30){
                Thread.Sleep(1000);
                i++;
            }
            Assert.NotNull(point);

        }
    }
}