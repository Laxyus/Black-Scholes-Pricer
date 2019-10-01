using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BnS.App.ViewModels.Annotations;
using BnS.Domain;

namespace BnS.App.ViewModels
{
    public class BnSViewModel : INotifyPropertyChanged
    {
        private BnSCharacteristic characteristic = new BnSCharacteristic(50, 55, 1, 0.2, 0.09);
        private BnSCalculator calculator = new BnSCalculator();

        public double StockPrice
        {
            get
            {
               return characteristic.StockPrice;
            }
            set
            {
                if (characteristic.StockPrice != value)
                {
                    characteristic.StockPrice = value;
                    OnPropertyChanged("StockPrice");
                    OnPropertyChanged("CallPrice");
                    OnPropertyChanged("PutPrice");
                }
            }
        }

        public double StrikePrice
        {
            get
            {
                return characteristic.StrikePrice;
            }
            set
            {
                if (characteristic.StrikePrice != value)
                {
                    characteristic.StrikePrice = value;
                    OnPropertyChanged("StrikePrice");
                    OnPropertyChanged("CallPrice");
                    OnPropertyChanged("PutPrice");
                }
            }
        }

        public double StdDeviation
        {
            get
            {
                return characteristic.StdDeviation;
            }
            set
            {
                if (characteristic.StdDeviation != value)
                {
                    characteristic.StdDeviation = value;
                    OnPropertyChanged("StdDeviation");
                    OnPropertyChanged("CallPrice");
                    OnPropertyChanged("PutPrice");
                }
            }
        }

        public double TimeToMaturity
        {
            get
            {
                return characteristic.TimeToMaturity;
            }
            set
            {
                if (characteristic.TimeToMaturity != value)
                {
                    characteristic.TimeToMaturity = value;
                    OnPropertyChanged("TimeToMaturity");
                    OnPropertyChanged("CallPrice");
                    OnPropertyChanged("PutPrice");
                }
            }
        }

        public double RiskFreeInterestRate
        {
            get
            {
                return characteristic.RiskFreeInterestRate;
            }
            set
            {
                if (characteristic.RiskFreeInterestRate != value)
                {
                    characteristic.RiskFreeInterestRate = value;
                    OnPropertyChanged("RiskFreeInterestRate");
                    OnPropertyChanged("CallPrice");
                    OnPropertyChanged("PutPrice");
                }
            }
        }

        public double CallPrice
        {
            get { return calculator.ComputeCall(characteristic); }
        }

        public double PutPrice
        {
            get { return calculator.ComputePut(characteristic); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
