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
        private MagneticTileManager magTileMgr;
        private string strWorkPath;

        [SetUp]
        public void SetUp()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            model = MagneticModel.FromFile(Path.Combine(strWorkPath, "WMM.COF"));
            var nmodel = MagneticModel.FromFile(Path.Combine(strWorkPath, "WMM.COF"));
            magTileMgr = new MagneticTileManager(ref nmodel);
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

        [Test]
        public void TestMagneticTileManager1()
        {
            Assert.NotNull(magTileMgr.FindOrCreateTile(new GeoPoint(0, 0), DateTime.UtcNow));
        }
    }
}
