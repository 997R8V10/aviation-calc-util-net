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
            var tile = GribTile.FindOrCreateGribTile(new GeoPoint(0, 0), DateTime.Now);
            Assert.Pass();
        }
    }
}