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
            Assert.True(coeffsReturned.SequenceEqual(_coefficients));
        } 
    }
}