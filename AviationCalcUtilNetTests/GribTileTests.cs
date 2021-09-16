using System;
using System.Threading;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.GeoTools.GribTools;
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
            var tile = GribTile.FindOrCreateGribTile(geoPoint, DateTime.UtcNow);
            Assert.NotNull(tile);
            GribDataPoint point;
            int i = 0;
            while ((point = tile.GetClosestPoint(geoPoint)) == null && i < 30){
                Thread.Sleep(1000);
            }
            Assert.NotNull(point);

        }
    }
}