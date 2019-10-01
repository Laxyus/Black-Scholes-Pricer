using System;

namespace BnS.Domain
{
    public class BnSCalculator
    {
        public double ComputePut(BnSCharacteristic characteristics)
        {
            return (characteristics.StrikePrice * Math.Exp((-characteristics.RiskFreeInterestRate * characteristics.TimeToMaturity)) * ComputeNormal(-ComputeD2(characteristics)))  - (characteristics.StockPrice * ComputeNormal(-ComputeD1(characteristics)));
        }

        public double ComputeCall(BnSCharacteristic characteristics)
        {
            return (characteristics.StockPrice * ComputeNormal(ComputeD1(characteristics))) - (characteristics.StrikePrice * Math.Exp((-characteristics.RiskFreeInterestRate*characteristics.TimeToMaturity)) * ComputeNormal(ComputeD2(characteristics)));
        }

        public double ComputeNormal(double X)
        {
            const double a1 = 0.31938153;
            const double a2 = -0.356563782;
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;

            var L = Math.Abs(X);
            var K = 1.0 / (1.0 + 0.2316419 * L);
            var normal = 1.0 - 1.0 / Math.Sqrt(2 * Math.PI) * Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) + a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));

            if (X < 0)
            {

                return 1.0 - normal;
            }
            return normal;
        }

        public double ComputeD1(BnSCharacteristic characteristics)
        {
            return (Math.Log(characteristics.StockPrice / characteristics.StrikePrice)  + ((characteristics.RiskFreeInterestRate + (Math.Pow(characteristics.StdDeviation, 2) / 2)) * characteristics.TimeToMaturity)) / (characteristics.StdDeviation * Math.Sqrt(characteristics.TimeToMaturity));
        }

        public double ComputeD2(BnSCharacteristic characteristics)
        {
            return ComputeD1(characteristics) -
                   (characteristics.StdDeviation * Math.Sqrt(characteristics.TimeToMaturity));
        }
    }
}
