using System;

namespace BnS
{
    public class BnSCharacteristic
    {
        public double StockPrice { get; set; }
        public double StrikePrice { get; set; }
        public double TimeToMaturity { get; set; }
        public double StdDeviation { get; set; }
        public double RiskFreeInterestRate { get; set; }

        public BnSCharacteristic(double stockPrice, double strikePrice, double timeToMaturity, double stdDeviation, double riskFreeInterestRate)
        {
            StockPrice = stockPrice;
            StrikePrice = strikePrice;
            TimeToMaturity = timeToMaturity;
            StdDeviation = stdDeviation;
            RiskFreeInterestRate = riskFreeInterestRate;
        }
    }
}
