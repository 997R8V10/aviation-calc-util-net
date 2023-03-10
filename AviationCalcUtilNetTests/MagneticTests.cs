using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.GeoTools.MagneticTools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationCalcUtilNetTests
{
    public class MagneticTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void TestEpochYear1()
        {
            double epoch = MagneticUtil.GetEpochYear(DateTime.UtcNow);
            Assert.AreNotEqual(0, epoch);
        }

        [Test]
        public void TestMagneticField()
        {
            MagneticUtil.GetMagneticField(new GeoPoint(0, 0), DateTime.UtcNow);
        }
    }
}
