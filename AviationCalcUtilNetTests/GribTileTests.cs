using System;
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
            var tile = GribTile.FindOrCreateGribTile(geoPoint, DateTime.Now);
            Assert.NotNull(tile);
        }
    }
}