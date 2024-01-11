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
            aircraft.MoveBy((Bearing)280, (Length)11000);
            (Bearing requiredCourse, Length aTk, Length xTk) = AviationUtil.CalculateArcCourseIntercept(aircraft, center, Bearing.FromDegrees(250), Bearing.FromDegrees(30), Length.FromMeters(10000), true);

            Assert.LessOrEqual(Math.Abs(xTk.Meters - -1000), 1.0);
            Assert.LessOrEqual(Math.Abs(requiredCourse.Degrees - 10), 0.1);
            Assert.LessOrEqual(Math.Abs(aTk.Meters - 19198.62), 1.0);
        }

        [Test]
        public void TestCalculateTurnLeadDist1()
        {
            GeoPoint waypoint = new GeoPoint(54.45237778, -5.3348194400000422, 0);
            GeoPoint aircraft = new GeoPoint(54.3527834, -5.07700259999998, 10_000);
            var aircraft_course = Bearing.FromDegrees(32.111653320461478);
            var waypoint_course = Bearing.FromDegrees(313.98221920547149);
            var true_airspeed = Velocity.FromKnots(290.58338915806166);
            var wind_dir = Bearing.FromDegrees(0.0);
            var wind_spd = Velocity.FromKnots(0.0);

            var calculated = AviationUtil.CalculateTurnLeadDistance(
                aircraft,
                waypoint,
                aircraft_course,
                true_airspeed,
                waypoint_course,
                wind_dir,
                wind_spd,
                Angle.FromDegrees(25),
                AngularVelocity.FromDegreesPerSecond(3)
            );

            Assert.IsTrue(calculated.HasValue);
        }
    }
}

