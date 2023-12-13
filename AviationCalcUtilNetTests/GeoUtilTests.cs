using System;
using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.Units;
using NUnit.Framework;

namespace AviationCalcUtilNetTests
{
	public class GeoUtilTests
	{
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestCalculateArcInfo1()
        {
            GeoPoint center = new GeoPoint(Latitude.FromDegrees(38), Longitude.FromDegrees(-77));
            GeoPoint aircraft = new GeoPoint(Latitude.FromDegrees(38), Longitude.FromDegrees(-77));
            aircraft.MoveBy(Bearing.FromDegrees(280), Length.FromMeters(11000));
            double xTk = GeoUtil.CalculateArcCourseInfo(aircraft, center, 250, 30, 10000, true, out double requiredCourse, out double aTk);

            Assert.LessOrEqual(Math.Abs(xTk - -1000), 1.0);
            Assert.LessOrEqual(Math.Abs(requiredCourse - 10), 0.1);
            Assert.LessOrEqual(Math.Abs(aTk - 19198.62), 1.0);
        }
	}
}

