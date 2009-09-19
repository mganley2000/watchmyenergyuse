using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Energy.Communication;
using Energy.Library;

namespace Energy.EnergyWatcher
{
    /// <summary>
    /// Calibrate the remote xbee transmitters by choosing one and trying to find the 'zero'
    /// </summary>
    public partial class CalibrateForm : Form
    {
        int chosen_device = 0;
        string chosen_deviceName = string.Empty;
        List<xbeeMeter> liveMeters;
        MeterCollection databaseMeters;
        private bool logToDatabase = false;

        public CalibrateForm(List<xbeeMeter> meters, bool logDataToDatabase)
        {
            InitializeComponent();

            if (meters.Count > 0)
            {
                liveMeters = meters;
                logToDatabase = logDataToDatabase;

                databaseMeters = DatabaseController.GetMeters();

                LoadDeviceDropDown(liveMeters, databaseMeters);
            }
            else
            {
                butStart.Enabled = false;
            }

        }

        private void LoadDeviceDropDown(List<xbeeMeter> meters, MeterCollection dbMeters )
        {
            int i = 0;
            Meter dbMeter;
            string name;

            ddDevice.Items.Clear();

            DataTable list = new DataTable();
            list.Columns.Add(new DataColumn("Display", typeof(string)));
            list.Columns.Add(new DataColumn("Id", typeof(int)));

            foreach (xbeeMeter meter in meters)
            {
                dbMeter = dbMeters.FindMeter(meter.ID);
                if (dbMeter != null)
                {
                    if (dbMeter.IsCalibratedVREF)
                    {
                        // if already calibrated
                        name = dbMeter.Name + " (calibrated)";  
                    }
                    else
                    {
                        name = dbMeter.Name;
                    }
                    
                }
                else
                {
                    name = "xbee " + meter.ID.ToString();
                }

                list.Rows.Add(list.NewRow());
                list.Rows[i][0] = name;
                list.Rows[i][1] = meter.ID;
                i++;
            }

            ddDevice.DisplayMember = "Display";
            ddDevice.ValueMember = "Id";
            ddDevice.DataSource = list;

        }

        private void butStart_Click(object sender, EventArgs e)
        {
            int currentSamplesCount;
            double avgRawCurrentSampleForCalibration = 0;
            int recentChirpIndex = 0;

            chosen_device = (int)(((System.Data.DataRowView)(ddDevice.SelectedItem)).Row.ItemArray[1]);
            chosen_deviceName = (string)(((System.Data.DataRowView)(ddDevice.SelectedItem)).Row.ItemArray[0]);

            foreach (xbeeMeter meter in liveMeters)
            {
                if (meter.ID == chosen_device)
                {
                    recentChirpIndex = meter.Chirps.Count;
                    currentSamplesCount = meter.Chirps[recentChirpIndex - 1].CurrentSamples.Length;
                    for (int i = 0; i <= currentSamplesCount - 1; i++)
                    {
                        avgRawCurrentSampleForCalibration += meter.Chirps[recentChirpIndex - 1].CurrentSamples[i];
                    }
                    avgRawCurrentSampleForCalibration /= currentSamplesCount;

                    meter.CalibratedVREF = (int)avgRawCurrentSampleForCalibration;

                    if (logToDatabase)
                    {
                        // Update the calibration to the database for this meter;
                        DatabaseController.UpdateMeterCalibration(meter.ID, meter.CalibratedVREF);
                    }

                    labDone.Text = labDone.Text.Replace("{s}", chosen_deviceName);
                    labDone.Visible = true;

                    butCancel.Visible = false;
                    butStart.Visible = false;
                    butOK.Visible = true;
                } 
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
