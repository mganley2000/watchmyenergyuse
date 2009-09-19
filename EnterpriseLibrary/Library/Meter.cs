using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Energy.Library
{
    /// <summary>
    /// Meter class
    /// </summary>
    public class Meter
    {
        private int id;
        private Enums.MeterType type;
        private string name;
        private string description;
        private int calibratedVREF;
        private bool calibratedVREFInd;

        public Meter()
        {
        }

        public Meter(int meterID, Enums.MeterType meterType, string meterName, string meterDesc, int meterCalibratedVREF, bool calibrated)
        {
            id = meterID;
            type = meterType;
            name = meterName;
            description = meterDesc;
            calibratedVREF = meterCalibratedVREF;
            calibratedVREFInd = calibrated;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Enums.MeterType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int CalibratedVREF
        {
            get { return calibratedVREF; }
            set { calibratedVREF = value; }
        }

        public bool IsCalibratedVREF
        {
            get { return calibratedVREFInd; }
            set { calibratedVREFInd = value; }
        }

    }
}
