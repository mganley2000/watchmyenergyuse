/* 
 * C# version ported by M. Ganley <mganley2000 -at- gmail.com>
 * This quick port based on xbee.py By Amit Snyderman <amit -at- amitsnyderman.com>
 * http://code.google.com/p/python-xbee/source/browse/trunk/xbee.py?spec=svn3&r=3
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Energy.Library;

namespace Energy.Communication
{
    /// <summary>
    ///  xbee is a class that handles xbee (zigbee) data coming in at the serial port
    ///  The port is initialized, and once packets are decomposed, a chirp event is raised
    ///  for listeners to handle and process further
    ///  
    ///  C# version ported by M. Ganley <mganley2000 -at- gmail.com>
    ///  This quick port based on xbee.py By Amit Snyderman <amit -at- amitsnyderman.com>
    ///  http://code.google.com/p/python-xbee/source/browse/trunk/xbee.py?spec=svn3&r=3
    /// </summary>
    public class xbee
    {
        public delegate void ReceivedChirpEventHandler(object sender, ReceivedChirpEventArgs e);
        public event ReceivedChirpEventHandler ReceivedChirp;
        public SerialPort port;

        private const int START_IOPACKET = 0x7e;
        private const int SERIES1_IOPACKET = 0x83;

        private bool packet_started;
        int lengthMSB;
        int lengthLSB;
        int length;
        byte[] buffer;
        int app_id;
        int addrMSB;
        int addrLSB;
        int address_16;
        int rssi;
        bool address_broadcast;
        bool pan_broadcast;
        int total_samples;
        int channel_indicator_high;
        int channel_indicator_low;
        int local_checksum;
        int[][] digital_samples;
        int[][] analog_samples;
        int[] dataD = new int[9] {-1,-1,-1,-1,-1,-1,-1,-1,-1};
        int[] dataADC = new int[6] {-1, -1, -1, -1, -1, -1};
        int digital_channels;
        int digital;
        int digMSB;
        int digLSB;
        int dig;
        int analog_channels;
        int validanalog;
        int analogchan;
        int dataADCMSB;
        int dataADCLSB;
        public StringBuilder sb;

        public xbee()
        {
            port = null;
            sb = new StringBuilder();
        }

        public void StartAcquiring(Configuration config)
        {
            if (port == null)
            {
                packet_started = false;
                buffer = new byte[4096];    // use a 4K working buffer
                InitializeComPort(config);
            }
        }

        public void StopAcquiring()
        {
            if (port != null)
            {
                port.Close();
            }
        }

        private void InitializeComPort(Configuration config)
        {
            port = new SerialPort(config.COMPort, config.Baud, config.Parity, config.DataBits, (StopBits)config.StopBits);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open();

        }

        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int b;
            int byteCountRead;
   
            while (port.BytesToRead != 0)
            {
                b = port.ReadByte();

                if (!packet_started)
                {
                    if (b == START_IOPACKET)
                    {
                        packet_started = true;
                        lengthMSB = port.ReadByte();
                        lengthLSB = port.ReadByte();
                        length = (lengthLSB + (lengthMSB << 8)) + 1;

                        // use 4K buffer
                        byteCountRead = port.Read(buffer, 0, length);
                        if (byteCountRead < length)
                        {
                            for (int i = 0; i <= (length-byteCountRead-1); i++)
                            {
                                b = port.ReadByte();
                                buffer[byteCountRead + i] = Convert.ToByte(b);
                            }
                        }

                        // get values from buffer
                        app_id = buffer[0];

                        if (app_id == SERIES1_IOPACKET)
                        {
                            addrMSB = buffer[1];
                            addrLSB = buffer[2];
                            address_16 = (addrMSB << 8) + addrLSB;

                            rssi = buffer[3];
                            if (((buffer[4] >> 1) & 0x01) == 1)
                            {
                                address_broadcast = true;
                            }
                            else
                            {
                                address_broadcast = false;
                            }

                            if (((buffer[4] >> 2) & 0x01) == 1)
                            {
                                pan_broadcast = true;
                            }
                            else
                            {
                                pan_broadcast = false;
                            }

                            total_samples = buffer[5];
                            channel_indicator_high = buffer[6];
                            channel_indicator_low = buffer[7];
                       
                            local_checksum = app_id + addrMSB + addrLSB + rssi + buffer[4] + total_samples + channel_indicator_high + channel_indicator_low;

                            digital_samples = new int[total_samples][];
                            analog_samples = new int[total_samples][];

                            for (int n = 0; n < total_samples; n++)
                            {
                                digital_channels = channel_indicator_low;
                                digital = 0;

                                for (int i = 0; i < dataD.Length; i++)
                                {
                                    if ((digital_channels & 1) == 1)
                                    {
                                        dataD[i] = 0;
                                        digital = 1;
                                    }
                                    digital_channels = digital_channels >> 1;
                                }

                                if ((channel_indicator_high & 1) == 1)
                                {
                                    dataD[8] = 0;
                                    digital = 1;
                                }

                                if (digital == 1)
                                {
                                    digMSB = buffer[8];
                                    digLSB = buffer[9];
                                    local_checksum += digMSB + digLSB;
                                    dig = (digMSB << 8) + digLSB;
                                    for (int i = 0; i < dataD.Length; i++)
                                    {
                                        if (dataD[i] == 0)
                                        {
                                            dataD[i] = dig & 1;
                                        }
                                        dig = dig >> 1;
                                    }
                                }

                                digital_samples[n] = new int[9];
                                dataD.CopyTo(digital_samples[n],0);

                                analog_channels = channel_indicator_high >> 1;
                                validanalog = 0;
                                for (int i = 0; i < dataADC.Length; i++)
                                {
                                    if (((analog_channels >> i) & 1) == 1)
                                    {
                                        validanalog += 1;
                                    }
                                }

                                for (int i = 0; i < dataADC.Length; i++)
                                {
                                    dataADC[0] = -1;
                                }

                                for (int i = 0; i < dataADC.Length; i++)
                                {
                                    if ((analog_channels & 1) == 1)
                                    {
                                        analogchan = 0;
                                        for (int j = 0; j < i; j++)
                                        {
                                            if (((channel_indicator_high >> (j + 1)) & 1) == 1)
                                            {
                                                analogchan += 1;
                                            }
                                        }

                                        dataADCMSB = buffer[8 + validanalog * n * 2 + analogchan*2];
                                        dataADCLSB = buffer[8 + validanalog * n * 2 + analogchan*2 + 1];
                                        local_checksum += dataADCMSB + dataADCLSB;
                                        dataADC[i] = ((dataADCMSB << 8) + dataADCLSB);
                                    }

                                    analog_channels = analog_channels >> 1;
                                }

                                analog_samples[n] = new int[6];
                                dataADC.CopyTo(analog_samples[n], 0);
                            }

                            // Processed entire frame of data at this point
                            // "<xbee {app_id: %s, address_16: %s, rssi: %s, address_broadcast: %s, pan_broadcast: %s,
                            // total_samples: %s, digital: %s, analog: %s}>" % (self.app_id, self.address_16, self.rssi, self.address_broadcast, self.pan_broadcast, self.total_samples, self.digital_samples, self.analog_samples)

                            sb.Append("<xbee {app_id: ");
                            sb.Append(app_id);
                            sb.Append(", address_16: ");
                            sb.Append(address_16);
                            sb.Append(", rssi: ");
                            sb.Append(rssi);
                            sb.Append(", address_broadcast: ");
                            sb.Append(address_broadcast);
                            sb.Append(", pan_broadcast: ");
                            sb.Append(pan_broadcast);
                            sb.Append(", total_samples: ");
                            sb.Append(total_samples);
                            sb.Append(", digital: [");
                            
                            for (int j = 0; j < total_samples; j++)
                            {
                                sb.Append("[");
                                for (int i = 0; i < digital_samples[j].Length; i++)
                                {
                                    if (i != 0) { sb.Append(","); }
                                    sb.Append(digital_samples[j][i]);
                                }
                                sb.Append("]");
                            }

                            sb.Append("], analog: [");
                            
                            for (int j = 0; j < total_samples; j++)
                            {
                                sb.Append("[");
                                for (int i = 0; i < analog_samples[j].Length; i++)
                                {
                                    if (i != 0) { sb.Append(","); }
                                    sb.Append(analog_samples[j][i]);
                                }
                                sb.Append("]");
                            }

                            sb.Append("]}>");

                            chirp xbeeChirp = new chirp();
                            xbeeChirp.TimeStamp = DateTime.Now;
                            xbeeChirp.ID = address_16;
                            xbeeChirp.SourceBlurb = sb.ToString();
                            xbeeChirp.VoltageSamples = new int[total_samples];
                            xbeeChirp.CurrentSamples = new int[total_samples];
                            for (int j = 0; j < total_samples; j++)
                            {
                                for (int i = 0; i < analog_samples[j].Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        xbeeChirp.VoltageSamples[j] = analog_samples[j][i];
                                    }
                                    if (i == 4)
                                    {
                                        xbeeChirp.CurrentSamples[j] = analog_samples[j][i];
                                    }                                    
                                }
                            }

                            ReceivedChirpEventArgs eventArgs = new ReceivedChirpEventArgs(xbeeChirp);
                            ReceivedChirp(this, eventArgs);

                            sb.Remove(0, sb.Length);

                            packet_started = false;
                        }

                    }
                }
                else
                {
                    // Nothing to read
                }
            }

        }

    }
}
