using System;
using AviationCalcUtilNet.Aviation;
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
            GeoPoint center = new GeoPoint(38, -77);
            GeoPoint aircraft = new GeoPoint(38, -77);
            aircraft.MoveBy(Bearing.FromDegrees(280), Length.FromMeters(11000));
            (Bearing requiredCourse, Length aTk, Length xTk) = AviationUtil.CalculateArcCourseIntercept(aircraft, center, Bearing.FromDegrees(250), Bearing.FromDegrees(30), Length.FromMeters(10000), true);

            Assert.LessOrEqual(Math.Abs(xTk.Meters - -1000), 1.0);
            Assert.LessOrEqual(Math.Abs(requiredCourse.Degrees - 10), 0.1);
            Assert.LessOrEqual(Math.Abs(aTk.Meters - 19198.62), 1.0);
        }
	}
}

