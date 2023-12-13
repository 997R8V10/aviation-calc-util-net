using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.Magnetic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AviationCalcUtilNetTests
{
    public class MagneticTests
    {
        private MagneticModel model;

        [SetUp]
        public void SetUp()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            model = MagneticModel.FromFile(Path.Combine(strWorkPath, "WMM.COF"));
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
            model.CalculateField(new GeoPoint(), DateTime.UtcNow);
        }
    }
}
