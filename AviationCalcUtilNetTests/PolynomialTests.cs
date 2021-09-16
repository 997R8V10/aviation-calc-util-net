using System;
using System.Collections.Generic;
using System.Linq;
using AviationCalcUtilNet.MathTools;
using NUnit.Framework;

namespace AviationCalcUtilNetTests
{
    public class PolynomialTests
    {
        private Polynomial _polynomial;
        private List<double> _coefficients;

        [SetUp]
        public void Setup()
        {
            _coefficients = new List<double>() { 1, 0, 1 };
            //x^2+1
            _polynomial = new Polynomial(_coefficients);
        }
        
        [Test]
        public void TestPolynomial1()
        {
            Assert.AreEqual(26, _polynomial.Evaluate(5), double.Epsilon);
        }

        [Test]
        public void TestGetCoeffs()
        {
            var coeffsReturned = _polynomial.GetCoefficients();
            string toPrint1 = "";
            foreach (double d in _coefficients)
            {
                toPrint1 += d + " ";
            }
            string toPrint2 = "";
            foreach (double e in coeffsReturned)
            {
                toPrint2 += e + " ";
            }
            TestContext.Out.WriteLine(toPrint1);
            
            TestContext.Out.WriteLine(toPrint2);
            Assert.True(coeffsReturned.SequenceEqual(_coefficients));
        }


        [Test]
        public void Derive()
        {
            Polynomial derived = _polynomial.Derivative(1);
            Assert.True(derived.GetCoefficients().SequenceEqual(new List<double>(){0,2}));
        }
    }
}