using System;
using System.Collections.Generic;
using System.Text;

namespace Energy.Communication
{
    /// <summary>
    /// An xbee metering device and all the running statistics and rolling lists
    /// </summary>
    public class xbeeMeter
    {
        private int id;
        private string name;
        private bool isNameChanged;
        private int calibratedVREF;
        private DateTime discoveredTime;
        private List<chirp> chirps = new List<chirp>();
        private List<read> oneMinuteReads = new List<read>();       // kW (avg draw over 1 minute)
        private List<read> fifteenMinuteReads = new List<read>();   // kW (avg draw over 15 minutes)
        private List<read> hourlyReads = new List<read>();          // kWh (quantity used in kWh)

        public xbeeMeter()
        {
            name = string.Empty;
            isNameChanged = false;
            calibratedVREF = -1;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsNameChanged
        {
            get { return isNameChanged; }
            set { isNameChanged = value; }
        }

        public int CalibratedVREF
        {
            get { return calibratedVREF; }
            set { calibratedVREF = value; }
        }

        public DateTime DiscoveredTime
        {
            get { return discoveredTime; }
            set { discoveredTime = value; }
        }

        public List<chirp> Chirps
        {
            get { return chirps; }
            set { chirps = value; }
        }

        public List<read> OneMinuteReads
        {
            get { return oneMinuteReads; }
            set { oneMinuteReads = value; }
        }

        public List<read> FifteenMinuteReads
        {
            get { return fifteenMinuteReads; }
            set { fifteenMinuteReads = value; }
        }

        public List<read> HourlyReads
        {
            get { return hourlyReads; }
            set { hourlyReads = value; }
        }

    }
}
