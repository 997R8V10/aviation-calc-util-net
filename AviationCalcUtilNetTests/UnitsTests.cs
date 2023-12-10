using System;
using AviationCalcUtilNet.Units;
using NUnit.Framework;

namespace AviationCalcUtilNetTests
{
	public class UnitsTests
	{
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TestLength1()
        {
            Length len = new Length(100);

            Assert.That(len.Meters, Is.EqualTo(100.0));
        }


        [Test]
        public void TestLength2()
        {
            Length len = new Length(100);
            Length len2 = -len;

            Assert.That(len2.Meters, Is.EqualTo(-100.0));
        }
    }
}

