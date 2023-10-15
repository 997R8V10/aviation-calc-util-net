using System;
using AviationCalcUtilNet.GeoTools;
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
            GeoPoint center = new GeoPoint(38, -77, 0);
            GeoPoint aircraft = new GeoPoint(38, -77, 0);
            aircraft.MoveByM(280, 11000);
            double xTk = GeoUtil.CalculateArcCourseInfo(aircraft, center, 250, 30, 10000, true, out double requiredCourse, out double aTk);

            Assert.LessOrEqual(Math.Abs(xTk - -1000), 1.0);
            Assert.LessOrEqual(Math.Abs(requiredCourse - 10), 0.1);
            Assert.LessOrEqual(Math.Abs(aTk - 19198.62), 1.0);
        }
	}
}

