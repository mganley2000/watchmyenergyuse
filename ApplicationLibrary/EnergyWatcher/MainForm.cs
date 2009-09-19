using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Energy.Communication;
using Energy.Library;
using Schedule;


namespace Energy.EnergyWatcher
{
    /// <summary>
    /// Main application form with all controls and access to functionality
    /// </summary>
    public partial class MainForm : Form
    {
        private bool logDataToDatabase = false;
        private xbee serialDevice;
        private List<xbeeMeter> xbeeMeters = new List<xbeeMeter>();
        public delegate void UpdateTextHandler(string textForDisplay);
        private bool showVoltageCurrentChart = false;
        private bool showPower2secChart = false;
        private bool showPower1minChart = false;
        private bool showPower15minChart = false;
        private bool showConsumptionHourlyChart = false;

        private static Schedule.ScheduleTimer TickOneMinuteTimer;
        private bool oneMinuteTimerStarted = false;

        private static Schedule.ScheduleTimer TickFifteenMinuteTimer;
        private bool fifteenMinuteTimerStarted = false;

        private static Schedule.ScheduleTimer TickHourlyTimer;
        private bool hourlyTimerStarted = false;

        public MainForm()
        {
            DateTime dt;
            DateTime today = DateTime.Now;
            InitializeComponent();

            // Check database and initialize of needed
            if (!DatabaseController.IsDatabaseValid())
            {
                DatabaseController.InitializeDatabase();
            }

            stopAcquiringToolStripMenuItem.Enabled = false;
            startAcquiringToolStripMenuItem.Enabled = true;

            // 1-Minute Timer setup
            TickOneMinuteTimer = new Schedule.ScheduleTimer();
            TickOneMinuteTimer.Elapsed += new ScheduledEventHandler(TickOneMinuteTimer_Elapsed);
            dt = DateTime.Parse(today.Month + "/" + today.Day + "/" + today.Year);
            TickOneMinuteTimer.AddEvent(new Schedule.SimpleInterval(dt, TimeSpan.FromMinutes(1)));

            // 15-Minute Timer setup
            TickFifteenMinuteTimer = new Schedule.ScheduleTimer();
            TickFifteenMinuteTimer.Elapsed += new ScheduledEventHandler(TickFifteenMinuteTimer_Elapsed);
            dt = DateTime.Parse(today.Month + "/" + today.Day + "/" + today.Year);
            TickFifteenMinuteTimer.AddEvent(new Schedule.SimpleInterval(dt, TimeSpan.FromMinutes(15)));

            // Hourly Timer setup
            TickHourlyTimer = new Schedule.ScheduleTimer();
            TickHourlyTimer.Elapsed += new ScheduledEventHandler(TickHourlyTimer_Elapsed);
            dt = DateTime.Parse(today.Month + "/" + today.Day + "/" + today.Year);
            TickHourlyTimer.AddEvent(new Schedule.SimpleInterval(dt, TimeSpan.FromHours(1)));


        }

        private void TickOneMinuteTimer_Elapsed(object source, ScheduledEventArgs e)
        {
            double deltaPower;
            read r;
            int chirpCount;

            if (xbeeMeters != null)
            {
                if (xbeeMeters.Count > 0)
                {

                    foreach (xbeeMeter meter in xbeeMeters)
                    {
                        chirpCount = meter.Chirps.Count;

                        if (meter.OneMinuteReads.Count > 0)
                        {
                            deltaPower = meter.Chirps[chirpCount - 1].CumulativePower - meter.OneMinuteReads[meter.OneMinuteReads.Count - 1].CumulativeQuantity;
                        }
                        else
                        {
                            // first IntervalEnd
                            deltaPower = meter.Chirps[chirpCount - 1].CumulativePower;
                        }

                        r = new read();
                        r.IntervalEnd = e.EventTime;    // This should be exactly at the minute;
                        r.Quantity = deltaPower / 30;   // There are 30 2-sec chirps per minute;
                        r.EnergyConsumption = (r.Quantity / 60) / 1000;  // divide by 60 to convert to Wh; then by 1000 to convert to kWh
                        r.CumulativeQuantity = meter.Chirps[meter.Chirps.Count - 1].CumulativePower;
                        meter.OneMinuteReads.Add(r);
                        CheckAndHandleSizeOfList(meter.OneMinuteReads);
                    }

                    PowerOneMinuteChart(showPower1minChart);
                }
            }
        }

        private void TickFifteenMinuteTimer_Elapsed(object source, ScheduledEventArgs e)
        {
            double deltaPower;
            read r;
            int chirpCount;

            if (xbeeMeters != null)
            {
                if (xbeeMeters.Count > 0)
                {

                    foreach (xbeeMeter meter in xbeeMeters)
                    {
                        chirpCount = meter.Chirps.Count;

                        if (meter.FifteenMinuteReads.Count > 0)
                        {
                            deltaPower = meter.Chirps[chirpCount - 1].CumulativePower - meter.FifteenMinuteReads[meter.FifteenMinuteReads.Count - 1].CumulativeQuantity;
                        }
                        else
                        {
                            // first IntervalEnd
                            deltaPower = meter.Chirps[chirpCount - 1].CumulativePower;
                        }

                        r = new read();
                        r.IntervalEnd = e.EventTime;    // This should be exactly at the minute;
                        r.Quantity = deltaPower / 450;   // There are 450 2-sec chirps per 15-minutes;
                        r.EnergyConsumption = (r.Quantity / 4) / 1000;  // divide by 4 to convert to Wh; then by 1000 to convert to kWh
                        r.CumulativeQuantity = meter.Chirps[meter.Chirps.Count - 1].CumulativePower;
                        meter.FifteenMinuteReads.Add(r);
                        CheckAndHandleSizeOfList(meter.FifteenMinuteReads);
                    }

                    PowerFifteenMinuteChart(showPower15minChart);
                }
            }
        }

        private void TickHourlyTimer_Elapsed(object source, ScheduledEventArgs e)
        {
            double deltaPower;
            read r;
            int chirpCount;

            if (xbeeMeters != null)
            {
                if (xbeeMeters.Count > 0)
                {

                    foreach (xbeeMeter meter in xbeeMeters)
                    {
                        chirpCount = meter.Chirps.Count;

                        if (meter.HourlyReads.Count > 0)
                        {
                            deltaPower = meter.Chirps[chirpCount - 1].CumulativePower - meter.HourlyReads[meter.HourlyReads.Count - 1].CumulativeQuantity;
                        }
                        else
                        {
                            // first IntervalEnd
                            deltaPower = meter.Chirps[chirpCount - 1].CumulativePower;
                        }

                        r = new read();
                        r.IntervalEnd = e.EventTime;                // This should be exactly at the hour
                        r.Quantity = deltaPower / 1800;             // There are 1800 2-sec chirps per hour
                        r.EnergyConsumption = (r.Quantity) / 1000;  // divide by 1000 to convert to kWh
                        r.CumulativeQuantity = meter.Chirps[meter.Chirps.Count - 1].CumulativePower;
                        meter.HourlyReads.Add(r);
                        CheckAndHandleSizeOfList(meter.HourlyReads);

                        if (logDataToDatabase)
                        {
                            DatabaseController.InsertReading(meter.ID, Enums.Interval.Hourly, Enums.UnitOfMeasure.kWh, r.IntervalEnd, r.EnergyConsumption);
                        }
                    }

                    ConsumptionHourlyChart(showConsumptionHourlyChart);

                }
            }
        }

        private void aboutEnergyWatcherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new AboutForm();

            frmAbout.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmContact = new ContactForm();

            frmContact.ShowDialog(this);
        }


        // Menu item Voltage/Current chart
        private void voltageCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            samplesPlainTextMenuItemMenuItem.Checked = false;
            chartPower2SecToolStripMenuItem.Checked = false;
            voltageCurrentToolStripMenuItem.Checked = true;
            chartPower1MinToolStripMenuItem.Checked = false;
            chartPower15MinuteToolStripMenuItem.Checked = false;
            chartConsumptionhourlyToolStripMenuItem.Checked = false;

            comTextBox.Visible = false;
            showVoltageCurrentChart = true;
            showPower2secChart = false;
            showPower1minChart = false;
            showPower15minChart = false;
            showConsumptionHourlyChart = false;

            VoltageCurrentCharts();
            zg1.Visible = true;
        }

        // Menu item "Samples in plain text"
        private void samplesPlainTextMenuItemMenuItem_Click(object sender, EventArgs e)
        {
            voltageCurrentToolStripMenuItem.Checked = false;
            chartPower2SecToolStripMenuItem.Checked = false;
            samplesPlainTextMenuItemMenuItem.Checked = true;
            chartPower1MinToolStripMenuItem.Checked = false;
            chartPower15MinuteToolStripMenuItem.Checked = false;
            chartConsumptionhourlyToolStripMenuItem.Checked = false;

            showVoltageCurrentChart = false;
            showPower2secChart = false;
            showPower1minChart = false;
            showPower15minChart = false;
            showConsumptionHourlyChart = false;

            comTextBox.Visible = true;

            zg1.Visible = false;
        }

        private void startAcquiringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration config;
            stopAcquiringToolStripMenuItem.Enabled = true;
            startAcquiringToolStripMenuItem.Enabled = false;

            if (!samplesPlainTextMenuItemMenuItem.Checked &
                !voltageCurrentToolStripMenuItem.Checked &
                !chartPower2SecToolStripMenuItem.Checked &
                !chartPower1MinToolStripMenuItem.Checked &
                !chartPower15MinuteToolStripMenuItem.Checked &
                !chartConsumptionhourlyToolStripMenuItem.Checked)
            {
                samplesPlainTextMenuItemMenuItem.Checked = true;
                this.comTextBox.Visible = true;
            }

            this.comTextBox.Clear();

            // Get configuration settings for serial port use
            config = DatabaseController.GetConfiguration();

            try
            {

                // Start acquiring
                serialDevice = new xbee();
                serialDevice.ReceivedChirp += new xbee.ReceivedChirpEventHandler(CollectXBeeData);
                serialDevice.StartAcquiring(config);

                // Start the one minute timer; start the 15-minute timer; start the hourly timer
                // Only start one time; subsequent stop/start acquiring leaves these unaffected;
                if (!oneMinuteTimerStarted)
                {
                    oneMinuteTimerStarted = true;
                    TickOneMinuteTimer.Start();
                }
                if (!fifteenMinuteTimerStarted)
                {
                    fifteenMinuteTimerStarted = true;
                    TickFifteenMinuteTimer.Start();
                }
                if (!hourlyTimerStarted)
                {
                    hourlyTimerStarted = true;
                    TickHourlyTimer.Start();
                }

            }
            catch
            {
                // COM port failed
            }

        }

        private void CollectXBeeData(object sender, ReceivedChirpEventArgs e)
        {
            this.ProcessChirp(e);

            // The text display shows raw chirp data
            if (comTextBox.Visible)
            {
                this.BeginInvoke(new UpdateTextHandler(UpdateComTextBox), new object[1] { e.Chirp.SourceBlurb });
            }

            // This chart simply charts data from latest chirp
            if (showVoltageCurrentChart)
            {
                VoltageCurrentCharts();
            }

            // This chart always gets called so the points can be added for moving plot,
            // even though it may not be displayed; this is the only chart tied directly to the data collection
            Power2SecondChart(showPower2secChart);

        }

        private void UpdateComTextBox(string blurb)
        {
            this.comTextBox.AppendText(blurb);
            this.comTextBox.AppendText(Environment.NewLine);
            this.comTextBox.AppendText(Environment.NewLine);
            this.comTextBox.Refresh();
        }

        private void stopAcquiringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopAcquiringToolStripMenuItem.Enabled = false;
            startAcquiringToolStripMenuItem.Enabled = true;

            try
            {
                if (serialDevice != null)
                {
                    serialDevice.StopAcquiring();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // na
            }

        }

        private void ProcessChirp(ReceivedChirpEventArgs e)
        {
            xbeeMeter meter;
            bool found = false;
            Meter mm;

            // add chirp to meter if meter is found, else add another meter 
            foreach (xbeeMeter m in xbeeMeters)
            {
                if (m.ID == e.Chirp.ID)
                {
                    if (m.CalibratedVREF != -1)
                    {
                        e.Chirp.ProcessSamples(m.CalibratedVREF);
                    }
                    else
                    {
                        e.Chirp.ProcessSamples();
                    }

                    // Accumulate power
                    if (m.Chirps.Count > 0)
                    {
                        e.Chirp.CumulativePower = m.Chirps[m.Chirps.Count - 1].CumulativePower + e.Chirp.CyclePower;
                    }

                    // finally add the chirp
                    m.Chirps.Add(e.Chirp);
                    found = true;
                    CheckAndHandleSizeOfList(m.Chirps);
                    break;
                }
            }

            if (!found)
            {
                meter = new xbeeMeter();
                meter.ID = e.Chirp.ID;
                meter.Name = "xbee meter " + meter.ID.ToString();   // temporary name, could be overriden if found below
                meter.DiscoveredTime = e.Chirp.TimeStamp;

                try
                {
                    if (DatabaseController.DoesMeterIDExist(meter.ID))
                    {
                        // already in the database, grab it to grab configured
                        mm = DatabaseController.GetMeter(meter.ID);
                    }
                    else
                    {
                        // Not in database, add it to database
                        mm = new Meter(meter.ID, Enums.MeterType.maxstream_zigbee_1, meter.Name, "No description.", 0, false);
                        DatabaseController.InsertMeter(mm);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                // Use the calibration value from the database if available
                if (mm.IsCalibratedVREF)
                {
                    e.Chirp.ProcessSamples(mm.CalibratedVREF);
                    //assign the calibated value to the live meter in the xbee meter list
                    meter.CalibratedVREF = mm.CalibratedVREF;
                    meter.Name = mm.Name;
                }
                else
                {
                    e.Chirp.ProcessSamples();       // uncalibrated; could have appliances plugged in
                }

                e.Chirp.CumulativePower = e.Chirp.CyclePower;   // these are the same for the first chirp
                meter.Chirps.Add(e.Chirp);
                xbeeMeters.Add(meter);

            }

        }

        private void loggingPowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loggingPowerToolStripMenuItem.Checked = true;
            logDataToDatabase = true;
        }

        private void autoCalibrateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmCalibrate = new CalibrateForm(xbeeMeters, logDataToDatabase);
            frmCalibrate.ShowDialog(this);
        }

        private void chartPower2SecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            samplesPlainTextMenuItemMenuItem.Checked = false;
            voltageCurrentToolStripMenuItem.Checked = false;
            chartPower2SecToolStripMenuItem.Checked = true;
            chartPower1MinToolStripMenuItem.Checked = false;
            chartPower15MinuteToolStripMenuItem.Checked = false;
            chartConsumptionhourlyToolStripMenuItem.Checked = false;

            comTextBox.Visible = false;
            showVoltageCurrentChart = false;
            showPower2secChart = true;
            showPower1minChart = false;
            showPower15minChart = false;
            showConsumptionHourlyChart = false;

            Power2SecondChart(true);
            zg1.Visible = true;
        }

        private void chartPower1MinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            samplesPlainTextMenuItemMenuItem.Checked = false;
            voltageCurrentToolStripMenuItem.Checked = false;
            chartPower2SecToolStripMenuItem.Checked = false;
            chartPower1MinToolStripMenuItem.Checked = true;
            chartPower15MinuteToolStripMenuItem.Checked = false;
            chartConsumptionhourlyToolStripMenuItem.Checked = false;

            comTextBox.Visible = false;
            showVoltageCurrentChart = false;
            showPower2secChart = false;
            showPower1minChart = true;
            showPower15minChart = false;
            showConsumptionHourlyChart = false;

            PowerOneMinuteChart(true);
            zg1.Visible = true;
        }

        private void chartPower15MinuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            samplesPlainTextMenuItemMenuItem.Checked = false;
            voltageCurrentToolStripMenuItem.Checked = false;
            chartPower2SecToolStripMenuItem.Checked = false;
            chartPower1MinToolStripMenuItem.Checked = false;
            chartPower15MinuteToolStripMenuItem.Checked = true;
            chartConsumptionhourlyToolStripMenuItem.Checked = false;

            comTextBox.Visible = false;
            showVoltageCurrentChart = false;
            showPower2secChart = false;
            showPower1minChart = false;
            showPower15minChart = true;
            showConsumptionHourlyChart = false;

            PowerFifteenMinuteChart(true);
            zg1.Visible = true;
        }

        private void chartConsumptionhourlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            samplesPlainTextMenuItemMenuItem.Checked = false;
            voltageCurrentToolStripMenuItem.Checked = false;
            chartPower2SecToolStripMenuItem.Checked = false;
            chartPower1MinToolStripMenuItem.Checked = false;
            chartPower15MinuteToolStripMenuItem.Checked = false;
            chartConsumptionhourlyToolStripMenuItem.Checked = true;

            comTextBox.Visible = false;
            showVoltageCurrentChart = false;
            showPower2secChart = false;
            showPower1minChart = false;
            showPower15minChart = false;
            showConsumptionHourlyChart = true;

            ConsumptionHourlyChart(true);
            zg1.Visible = true;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmConfiguration = new ConfigurationForm();

            frmConfiguration.ShowDialog(this);
        }

        private void EnergyWatcherHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void moreChartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmChartForm = new ChartForm();

            frmChartForm.ShowDialog(this);
        }

        private void ratesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmRateForm = new RateForm();

            frmRateForm.ShowDialog(this);
        }


        // Removing range of data from a generic list
        private void CheckAndHandleSizeOfList<T>(List<T> list)
        {
            if (list.Count > 200)
            {
                list.RemoveRange(0, 100);
            }
        }

        private void devicePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDeviceProps = new DevicePropertiesForm(xbeeMeters);
            frmDeviceProps.ShowDialog(this);
        }


    }





}