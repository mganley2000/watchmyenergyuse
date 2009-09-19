using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Energy.Library;
using System.IO.Ports;

namespace Energy.EnergyWatcher
{
    /// <summary>
    /// COM port configuration form
    /// </summary>
    public partial class ConfigurationForm : Form
    {
        private Configuration config;

        public ConfigurationForm()
        {
            InitializeComponent();

            labResult.Visible = false;

            config = DatabaseController.GetConfiguration();

            txtCOMPort.Text = config.COMPort;
            txtBaud.Text = config.Baud.ToString();
            txtParity.Text = ((int)(config.Parity)).ToString();
            txtDataBits.Text = config.DataBits.ToString();
            txtStopBits.Text = config.StopBits.ToString();

        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                config.COMPort = txtCOMPort.Text;
                config.Baud = System.Convert.ToInt32(txtBaud.Text);
                config.Parity = (Parity)(System.Convert.ToInt32(txtParity.Text));
                config.DataBits = System.Convert.ToInt32(txtDataBits.Text);
                config.StopBits = System.Convert.ToInt32(txtStopBits.Text);

                DatabaseController.UpdatePortConfiguration("default", config);
                labResult.Text = "Update successful.";
                labResult.Visible = true;
            }
            catch
            {
                labResult.Text = "Error updating configuration.";
                labResult.Visible = true;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
