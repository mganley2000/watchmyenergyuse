using System;
using System.Collections.Generic;
using System.Text;

namespace Energy.Communication
{
    /// <summary>
    /// Store and process xbee wireless device chirps 
    /// </summary>
    public class chirp
    {
        private int id;
        private int[] data1;            // raw voltage samples
        private int[] data2;            // raw current samples
        private int[] voltage;          // processed voltage
        private double[] current;       // processed current
        private double[] power;         // power[i] = voltage[i] * current[i]
        private double cyclePower;      // adjusted average power for this chirp
        private double cumulativePower; // Total accumulated power for all chirps
        private string sourceBlurb;     // text view of this chirp
        private DateTime timestamp;

        public chirp()
        {
            cyclePower = 0.0;
            cumulativePower = 0.0;
            sourceBlurb = String.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int[] VoltageSamples
        {
            get { return data1; }
            set { data1 = value; }
        }

        public int[] CurrentSamples
        {
            get { return data2; }
            set { data2 = value; }
        }

        public int[] Voltage
        {
            get { return voltage; }
            set { voltage = value; }
        }

        public double[] Current
        {
            get { return current; }
            set { current = value; }
        }

        public double[] Power
        {
            get { return power; }
            set { power = value; }
        }

        public double CyclePower
        {
            get { return cyclePower; }
            set { cyclePower = value; }
        }

        public double CumulativePower
        {
            get { return cumulativePower; }
            set { cumulativePower = value; }
        }

        public string SourceBlurb
        {
            get { return sourceBlurb; }
            set { sourceBlurb = value; }
        }

        public DateTime TimeStamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }



        //
        // Process the samples into usable volts and amps
        //

        public void ProcessSamples()
        {
            ProcessSamples(constants.VREF);
        }

        public void ProcessSamples(int calibratedVREF)
        {
            int min_v;
            int max_v;
            int pp_v;
            double avg_v;

            // Load n-1 samples from raw data samples
            if (voltage == null)
            {
                voltage = new int[data1.Length - 1];
            }

            if (current == null)
            {
                current = new double[data2.Length - 1];
            }

            for (int i = 1; i <= data1.Length - 1; i++)
            {
                voltage[i - 1] = data1[i];
            }

            for (int i = 1; i <= data2.Length - 1; i++)
            {
                current[i - 1] = data2[i];
            }

            // ** get max and min voltage and normalize the curve to '0' **
            // to make the graph 'AC coupled' / signed
            min_v = 1024;
            max_v = 0;
            for (int i = 0; i <= voltage.Length - 1; i++)
            {
                if (min_v > voltage[i]) { min_v = voltage[i]; }
                if (max_v < voltage[i]) { max_v = voltage[i]; }
            }
            // figure out the 'average' of the max and min readings
            avg_v = (max_v + min_v) / 2;
            // also calculate the peak to peak measurements
            pp_v = max_v - min_v;

            for (int i = 0; i <= voltage.Length - 1; i++)
            {
                voltage[i] = (int)(((voltage[i] - avg_v) * constants.MAINSVPP) / pp_v);
            }

            // ** normalize current readings **
            for (int i = 0; i <= current.Length - 1; i++)
            {
                current[i] = ((double)((current[i] - calibratedVREF)) / constants.CURRENTNORM);
            }

            // ** power **
            if (power == null)
            {
                power = new double[voltage.Length];
            }

            for (int i = 0; i <= power.Length - 1; i++)
            {
                power[i] = voltage[i] * current[i];     // P=VI
            }

            // ** cycle power **
            // sum up power drawn over one 1/60hz cycle
            // 16.6 samples per second, one cycle = ~17 samples; index 0 -> 16
            cyclePower = 0;
            for (int i = 0; i <= 16; i++)
            {
                cyclePower = cyclePower + Math.Abs(power[i]);
            }
            cyclePower = cyclePower / 17.0;

        }

    }
}
