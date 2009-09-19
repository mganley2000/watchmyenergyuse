using System;

namespace Energy.Communication
{
    /// <summary>
    /// Class to hold the running read statistics
    /// </summary>
    public class read
    {
        private double quantity;
        private double runningTotal;
        private double energyConsumption;
        private DateTime intervalEnd;

        public read()
        {
            quantity = 0.0;
            runningTotal = 0.0;
        }

        // The draw of power; could rename this to Draw
        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double CumulativeQuantity
        {
            get { return runningTotal; }
            set { runningTotal = value; }
        }

        // Consumption uom IS kWh 
        public double EnergyConsumption
        {
            get { return energyConsumption; }
            set { energyConsumption = value; }
        }

        public DateTime IntervalEnd
        {
            get { return intervalEnd; }
            set { intervalEnd = value; }
        }

    }
}
