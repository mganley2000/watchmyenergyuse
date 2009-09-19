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
    /// Name and Description of Meters Form
    /// This for was originally named as Device Properties
    /// </summary>
    public partial class DevicePropertiesForm : Form
    {
        int chosen_device = -1;
        MeterCollection databaseMeters;
        List<xbeeMeter> xbeeMeters;
        private Meter currentMeter = null;
        bool initialDropdownLoad = false;

        public DevicePropertiesForm(List<xbeeMeter> meters)
        {
            InitializeComponent();

            xbeeMeters = meters;

            initialDropdownLoad = true;
            databaseMeters = DatabaseController.GetMeters();
            LoadDeviceDropDown(databaseMeters);

            if (databaseMeters.Count > 0)
            {
                chosen_device = (int)(((System.Data.DataRowView)(ddDevice.SelectedItem)).Row.ItemArray[1]);
                currentMeter = DatabaseController.GetMeter(chosen_device);
                LoadFormData(currentMeter);
            }

            initialDropdownLoad = false;
        }

        private void ddDevice_SelectedIndexCommitted(object sender, EventArgs e)
        {
            int meterID;

            if (!initialDropdownLoad)
            {
                meterID = (int)ddDevice.SelectedValue;
                currentMeter = DatabaseController.GetMeter(meterID);
                LoadFormData(currentMeter);
            }

        }

        public void LoadFormData(Meter meter)
        {
            txtName.Text = meter.Name;
            txtDescription.Text = meter.Description;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            int result = -1;

            currentMeter.Name = txtName.Text;
            currentMeter.Description = txtDescription.Text;

            // Save settings 
            result = DatabaseController.UpdateMeter(currentMeter);

            // Be sure to mark name as changed and change name of live meter with same ID
            foreach (xbeeMeter m in xbeeMeters)
            {
                if (m.ID == currentMeter.ID)
                {
                    m.IsNameChanged = true;
                    m.Name = m.Name = currentMeter.Name;
                    break;
                }
            }

        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDeviceDropDown(MeterCollection dbMeters)
        {
            int i = 0;
            ddDevice.Items.Clear();

            DataTable list = new DataTable();
            list.Columns.Add(new DataColumn("Display", typeof(string)));
            list.Columns.Add(new DataColumn("Id", typeof(int)));

            foreach (Meter m in dbMeters)
            {
                list.Rows.Add(list.NewRow());
                list.Rows[i][0] = m.Name;
                list.Rows[i][1] = m.ID;
                i++;
            }

            ddDevice.DisplayMember = "Display";
            ddDevice.ValueMember = "Id";
            ddDevice.DataSource = list;
        }


    }
}
