using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Energy.Library
{
    /// <summary>
    /// Configuration class stores basic configuration information
    /// COM port, default rate, etc.
    /// </summary>
    public class Configuration
    {
        private string name;
        private string description;
        private string comPort;
        private int baud;
        private Parity parity;
        private int databits;
        private int stopbits;
        private int rateid;

        public Configuration()
        {
            name = string.Empty;
            description = string.Empty;
            comPort = string.Empty;
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

        public string COMPort
        {
            get { return comPort; }
            set { comPort = value; }
        }

        public int Baud
        {
            get { return baud; }
            set { baud = value; }
        }

        public Parity Parity
        {
            get { return parity; }
            set { parity = value; }
        }

        public int DataBits
        {
            get { return databits; }
            set { databits = value; }
        }

        public int StopBits
        {
            get { return stopbits; }
            set { stopbits = value; }
        }

        public int RateID
        {
            get { return rateid; }
            set { rateid = value; }
        }

    }
}
