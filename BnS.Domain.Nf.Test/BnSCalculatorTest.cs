using NUnit.Framework;

namespace BnS.Domain.Test
{
    [TestFixture]
    public class BnSCalculatorTest
    {

        [TestCase(50, 55, 1, 0.2, 0.09, 3.8617)]
        [TestCase(64, 60, 0.4931506, 0.27, 0.045, 7.7661)]
        public void ShouldComputeCallPrice(double stockPrice, double strikePrice, double timeToMaturity, double stdDeviation, double riskFreeInterestRate, double expectedPrice)
        {
            var calculator = new BnSCalculator();
            var characteristics = new BnSCharacteristic(stockPrice, strikePrice, timeToMaturity, stdDeviation, riskFreeInterestRate);

            double callPrice =  calculator.ComputeCall(characteristics);

            Assert.That(callPrice, Is.InRange(expectedPrice - 0.0001, expectedPrice + 0.0001));
        }

        [TestCase(50, 55, 1, 0.2, 0.09, 4.1279)]
        [TestCase(64, 60, 0.4931506, 0.27, 0.045, 2.4493)]
        public void ShouldComputePutPrice(double stockPrice, double strikePrice, double timeToMaturity, double stdDeviation, double riskFreeInterestRate, double expectedPrice)
        {
            var calculator = new BnSCalculator();
            var characteristics = new BnSCharacteristic(stockPrice, strikePrice, timeToMaturity, stdDeviation, riskFreeInterestRate);

            double callPrice = calculator.ComputePut(characteristics);

            Assert.That(callPrice, Is.InRange(expectedPrice - 0.0001, expectedPrice + 0.0001));
        }
    }
}
