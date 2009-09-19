using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using Energy.Communication;

namespace Energy.EnergyWatcher
{

    /// <summary>
    /// Charting details present in this partial class
    /// The real time rolling charts
    /// </summary>
    public partial class MainForm
    {
        GraphPane pane;
        private List<GraphPaneMeter> pane2secPowerList = new List<GraphPaneMeter>();
        private List<GraphPaneMeter> pane1minPowerList = new List<GraphPaneMeter>();
        private List<GraphPaneMeter> pane15minPowerList = new List<GraphPaneMeter>();
        private List<GraphPaneMeter> pane60minConsumptionList = new List<GraphPaneMeter>();

        // updated on a chirp
        private void VoltageCurrentCharts()
        {
            int chirpCount;
            LineItem curve;
            string paneTitle;
            double maxCurrent = 0;
            double current;

            // Get a reference to the GraphPane instance in the ZedGraphControl
            MasterPane master = zg1.MasterPane;

            master.PaneList.Clear();
            master.Title.IsVisible = false;
            master.Title.Text = "Charts";
            master.Margin.All = 5;
            master.Border.IsVisible = false;

            foreach (xbeeMeter meter in xbeeMeters)
            {
                // create one pane per meter
                pane = new GraphPane();

                chirpCount = meter.Chirps.Count;

                // Set the titles and axis labels
                paneTitle = meter.Name + "\n\r" + "Voltage & Current";
                pane.Title.Text = paneTitle;
                pane.XAxis.Title.Text = "Samples";
                pane.YAxis.Title.Text = "Voltage (Volts)";
                pane.Y2Axis.Title.Text = "Current (Amps)";

                // Voltage and Current Series;

                PointPairList list = new PointPairList();
                PointPairList list2 = new PointPairList();
                for (int i = 1; i < meter.Chirps[chirpCount - 1].Voltage.Length; i++)
                {

                    list.Add(i, meter.Chirps[chirpCount - 1].Voltage[i]);

                    current = meter.Chirps[chirpCount - 1].Current[i];
                    list2.Add(i, current);

                    if (current > maxCurrent)
                    {
                        maxCurrent = current;
                    }
                }

                // Generate a red curve with diamond symbols, and "Voltage" in the legend
                curve = pane.AddCurve("Voltage", list, Color.Red, SymbolType.Triangle);
                curve.Symbol.Fill = new Fill(Color.White);

                // Generate a blue curve with circle symbols, and "Current" in the legend
                curve = pane.AddCurve("Current", list2, Color.Blue, SymbolType.Circle);
                curve.Symbol.Fill = new Fill(Color.White);
                curve.IsY2Axis = true;

                // Show the x axis grid
                pane.XAxis.MajorGrid.IsVisible = true;

                // Make the Y axis scale red
                pane.YAxis.Scale.FontSpec.FontColor = Color.Red;
                pane.YAxis.Title.FontSpec.FontColor = Color.Red;
                // turn off the opposite tics so the Y tics don't show up on the Y2 axis
                pane.YAxis.MajorTic.IsOpposite = false;
                pane.YAxis.MinorTic.IsOpposite = false;
                // Don't display the Y zero line
                pane.YAxis.MajorGrid.IsZeroLine = false;
                // Align the Y axis labels so they are flush to the axis
                pane.YAxis.Scale.Align = AlignP.Inside;
                // Manually set the axis range
                //pane.YAxis.Scale.Min = -30;
                //pane.YAxis.Scale.Max = 30;

                // Enable the Y2 axis display
                pane.Y2Axis.IsVisible = true;
                pane.Y2Axis.Scale.Min = -(maxCurrent * 2);
                pane.Y2Axis.Scale.Max = maxCurrent * 2;
                if (pane.Y2Axis.Scale.Max == 0) { pane.Y2Axis.Scale.Max = 0.1; }
                if (pane.Y2Axis.Scale.Min == 0) { pane.Y2Axis.Scale.Min = -0.1; }
                // Make the Y2 axis scale blue
                pane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
                pane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
                // turn off the opposite tics so the Y2 tics don't show up on the Y axis
                pane.Y2Axis.MajorTic.IsOpposite = false;
                pane.Y2Axis.MinorTic.IsOpposite = false;
                // Display the Y2 axis grid lines
                pane.Y2Axis.MajorGrid.IsVisible = true;
                // Align the Y2 axis labels so they are flush to the axis
                pane.Y2Axis.Scale.Align = AlignP.Inside;

                // Fill the axis background with a gradient
                pane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

                master.Add(pane);
            }

            // Refigure the axis ranges for the GraphPanes
            zg1.AxisChange();

            // Layout the GraphPanes using a default Pane Layout
            using (Graphics g = this.CreateGraphics())
            {
                master.SetLayout(g, PaneLayout.SingleColumn);
                //master.Draw(g);
            }

            zg1.Invalidate();
        }

        // updated on a chirp
        private void Power2SecondChart(bool showMe)
        {
            int chirpCount;
            bool foundPaneMeter;
            bool meterIsNew;
            LineItem curve;
            RollingPointPairList list;
            IPointListEdit editList;

            // Get a reference to the GraphPane instance in the ZedGraphControl
            MasterPane master = zg1.MasterPane;

            if (showMe)
            {
                master.PaneList.Clear();
                master.Title.IsVisible = false;
                master.Title.Text = "Charts";
                master.Margin.All = 5;
                master.Border.IsVisible = false;
            }

            foreach (xbeeMeter meter in xbeeMeters)
            {
                // create new or grab existing pane per meter
                meterIsNew = false;
                foundPaneMeter = false;
                foreach (GraphPaneMeter p in pane2secPowerList)
                {
                    if (p.MeterID == meter.ID)
                    {
                        pane = p.Pane;
                        foundPaneMeter = true;
                        break;
                    }
                }
                if (!foundPaneMeter)
                {
                    pane = new GraphPane();
                    GraphPaneMeter newPane = new GraphPaneMeter();
                    newPane.MeterID = meter.ID;
                    newPane.Pane = pane;
                    pane2secPowerList.Add(newPane);
                    meterIsNew = true;
                }

                chirpCount = meter.Chirps.Count;

                if (meterIsNew)
                {
                    // Set the titles and axis labels
                    pane.Title.Text = meter.Name + "\n\r" + "Power (2 second interval)";
                    pane.XAxis.Title.Text = "min:sec";
                    pane.YAxis.Title.Text = "Power (W)";

                    // 2 sec power; rolling point pair, add with no points to start; 
                    list = new RollingPointPairList(70);
                    curve = pane.AddCurve("Power", list, Color.Purple, SymbolType.Diamond);
                    editList = list;
                    curve.Symbol.Fill = new Fill(Color.White);
                    pane.XAxis.MajorGrid.IsVisible = true;
                    pane.YAxis.Scale.FontSpec.FontColor = Color.Purple;
                    pane.YAxis.Title.FontSpec.FontColor = Color.Purple;
                    pane.YAxis.MajorGrid.IsZeroLine = false;
                    pane.YAxis.Scale.Align = AlignP.Inside;

                    pane.YAxis.Scale.Min = 0;

                    //new try date
                    pane.XAxis.Type = AxisType.Date;
                    pane.XAxis.Scale.Format = "mm:ss";
                    pane.XAxis.Scale.MajorUnit = DateUnit.Minute;
                    pane.XAxis.Scale.MinorUnit = DateUnit.Second;
                    pane.XAxis.Scale.MinorStep = 2;
                    pane.XAxis.Scale.MajorStep = 10;
                    //pane.XAxis.Scale.FontSpec.Angle = 0;

                    pane.XAxis.Scale.Max = meter.Chirps[chirpCount - 1].TimeStamp.AddSeconds(65).ToOADate();
                    pane.XAxis.Scale.Min = meter.Chirps[chirpCount - 1].TimeStamp.AddSeconds(0).ToOADate();

                    pane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

                }
                else
                {

                    curve = pane.CurveList[0] as LineItem;
                    if (curve != null)
                    {
                        editList = curve.Points as IPointListEdit;
                        if (editList != null)
                        {
                            //editList.Add((chirpCount-1)*2, meter.Chirps[chirpCount - 1].CyclePower);
                            editList.Add(new XDate(meter.Chirps[chirpCount - 1].TimeStamp), meter.Chirps[chirpCount - 1].CyclePower);

                        }

                    }
                    //pane.XAxis.Scale.Max = (chirpCount - 1) * 2;
                    //pane.XAxis.Scale.Min = pane.XAxis.Scale.Max - 60;
                    if (meter.DiscoveredTime.AddSeconds(60) < meter.Chirps[chirpCount - 1].TimeStamp)
                    {
                        pane.XAxis.Scale.Max = meter.Chirps[chirpCount - 1].TimeStamp.AddSeconds(5).ToOADate();
                        pane.XAxis.Scale.Min = meter.Chirps[chirpCount - 1].TimeStamp.AddSeconds(-60).ToOADate();
                    }
                }

                if (showMe) { master.Add(pane); }
            }

            if (showMe)
            {
                // Refigure the axis ranges for the GraphPanes
                zg1.AxisChange();

                // Layout the GraphPanes using a default Pane Layout
                using (Graphics g = this.CreateGraphics())
                {
                    master.SetLayout(g, PaneLayout.SingleColumn);
                }

                zg1.Invalidate();
            }

        }

        // updated on the 1-minute timer
        private void PowerOneMinuteChart(bool showMe)
        {
            int count;
            bool foundPaneMeter;
            bool meterIsNew;
            LineItem curve;
            RollingPointPairList list;
            IPointListEdit editList;

            // Get a reference to the GraphPane instance in the ZedGraphControl
            MasterPane master = zg1.MasterPane;

            if (showMe)
            {
                master.PaneList.Clear();
                master.Title.IsVisible = false;
                master.Title.Text = "Charts";
                master.Margin.All = 5;
                master.Border.IsVisible = false;
            }

            foreach (xbeeMeter meter in xbeeMeters)
            {
                // create new or grab existing pane per meter
                meterIsNew = false;
                foundPaneMeter = false;
                foreach (GraphPaneMeter p in pane1minPowerList)
                {
                    if (p.MeterID == meter.ID)
                    {
                        pane = p.Pane;
                        foundPaneMeter = true;
                        break;
                    }
                }
                if (!foundPaneMeter)
                {
                    pane = new GraphPane();
                    GraphPaneMeter newPane = new GraphPaneMeter();
                    newPane.MeterID = meter.ID;
                    newPane.Pane = pane;
                    pane1minPowerList.Add(newPane);
                    meterIsNew = true;
                }

                count = meter.OneMinuteReads.Count;



                if (meterIsNew)
                {
                    // Set the titles and axis labels
                    pane.Title.Text = meter.Name + "\n\r" + "Power (1 minute interval)";
                    pane.XAxis.Title.Text = "hour:min";
                    pane.YAxis.Title.Text = "Power (W)";

                    // 1 minute power; rolling point pair, add with no points to start; 
                    list = new RollingPointPairList(60);
                    curve = pane.AddCurve("Power", list, Color.Purple, SymbolType.Diamond);
                    editList = list;
                    curve.Symbol.Fill = new Fill(Color.White);
                    pane.XAxis.MajorGrid.IsVisible = true;
                    pane.YAxis.Scale.FontSpec.FontColor = Color.Purple;
                    pane.YAxis.Title.FontSpec.FontColor = Color.Purple;
                    pane.YAxis.MajorGrid.IsZeroLine = false;
                    pane.YAxis.Scale.Align = AlignP.Inside;
                    pane.YAxis.Scale.Min = 0;

                    //new try date
                    pane.XAxis.Type = AxisType.Date;
                    pane.XAxis.Scale.Format = "HH:mm";
                    pane.XAxis.Scale.MajorUnit = DateUnit.Hour;
                    pane.XAxis.Scale.MinorUnit = DateUnit.Minute;
                    pane.XAxis.Scale.MinorStep = 1;
                    pane.XAxis.Scale.MajorStep = 10;

                    pane.XAxis.Scale.Max = meter.DiscoveredTime.AddMinutes(65).ToOADate();
                    pane.XAxis.Scale.Min = meter.DiscoveredTime.AddMinutes(0).ToOADate();

                    pane.Chart.Fill = new Fill(Color.Ivory, Color.LightCyan, 45.0f);

                }
                else
                {
                    if (count > 0)
                    {
                        curve = pane.CurveList[0] as LineItem;
                        if (curve != null)
                        {
                            editList = curve.Points as IPointListEdit;
                            if (editList != null)
                            {
                                if (editList.Count > 0)
                                {
                                    if (editList[editList.Count - 1].X != meter.OneMinuteReads[count - 1].IntervalEnd.ToOADate())
                                    {
                                        editList.Add(meter.OneMinuteReads[count - 1].IntervalEnd.ToOADate(), meter.OneMinuteReads[count - 1].Quantity);
                                    }
                                }
                                else
                                {
                                    editList.Add(meter.OneMinuteReads[count - 1].IntervalEnd.ToOADate(), meter.OneMinuteReads[count - 1].Quantity);
                                }
                            }

                        }

                        if (count == 1)
                        {
                            pane.XAxis.Scale.Max = meter.OneMinuteReads[count - 1].IntervalEnd.AddMinutes(65).ToOADate();
                            pane.XAxis.Scale.Min = meter.OneMinuteReads[count - 1].IntervalEnd.AddMinutes(-2).ToOADate();
                        }
                        if (meter.DiscoveredTime.AddMinutes(60) < meter.OneMinuteReads[count - 1].IntervalEnd)
                        {
                            pane.XAxis.Scale.Max = meter.OneMinuteReads[count - 1].IntervalEnd.AddMinutes(5).ToOADate();
                            pane.XAxis.Scale.Min = meter.OneMinuteReads[count - 1].IntervalEnd.AddMinutes(-60).ToOADate();
                        }
                    }
                }

                if (showMe) { master.Add(pane); }


            }

            if (showMe)
            {
                // Refigure the axis ranges for the GraphPanes
                zg1.AxisChange();

                // Layout the GraphPanes using a default Pane Layout
                using (Graphics g = this.CreateGraphics())
                {
                    master.SetLayout(g, PaneLayout.SingleColumn);
                }

                zg1.Invalidate();
            }

        }

        // updated on the 15-minute timer
        private void PowerFifteenMinuteChart(bool showMe)
        {
            int count;
            bool foundPaneMeter;
            bool meterIsNew;
            LineItem curve;
            RollingPointPairList list;
            IPointListEdit editList;

            // Get a reference to the GraphPane instance in the ZedGraphControl
            MasterPane master = zg1.MasterPane;

            if (showMe)
            {
                master.PaneList.Clear();
                master.Title.IsVisible = false;
                master.Title.Text = "Charts";
                master.Margin.All = 5;
                master.Border.IsVisible = false;
            }

            foreach (xbeeMeter meter in xbeeMeters)
            {
                // create new or grab existing pane per meter
                meterIsNew = false;
                foundPaneMeter = false;
                foreach (GraphPaneMeter p in pane15minPowerList)
                {
                    if (p.MeterID == meter.ID)
                    {
                        pane = p.Pane;
                        foundPaneMeter = true;
                        break;
                    }
                }
                if (!foundPaneMeter)
                {
                    pane = new GraphPane();
                    GraphPaneMeter newPane = new GraphPaneMeter();
                    newPane.MeterID = meter.ID;
                    newPane.Pane = pane;
                    pane15minPowerList.Add(newPane);
                    meterIsNew = true;
                }

                count = meter.FifteenMinuteReads.Count;


                if (meterIsNew)
                {
                    // Set the titles and axis labels
                    pane.Title.Text = meter.Name + "\n\r" + "Power (15 minute interval)";
                    pane.XAxis.Title.Text = "hour:min";
                    pane.YAxis.Title.Text = "Power (W)";
                    pane.XAxis.Scale.FontSpec.Angle = 45;

                    // 15 minute power; rolling point pair, add with no points to start; 
                    list = new RollingPointPairList(48);    // 12 hours * 4 per hour
                    curve = pane.AddCurve("Power", list, Color.CadetBlue, SymbolType.Diamond);
                    editList = list;
                    curve.Symbol.Fill = new Fill(Color.White);
                    pane.XAxis.MajorGrid.IsVisible = true;
                    pane.YAxis.Scale.FontSpec.FontColor = Color.Purple;
                    pane.YAxis.Title.FontSpec.FontColor = Color.Purple;
                    pane.YAxis.MajorGrid.IsZeroLine = false;
                    pane.YAxis.Scale.Align = AlignP.Inside;

                    pane.YAxis.Scale.Min = 0;

                    //new try date
                    pane.XAxis.Type = AxisType.Date;
                    pane.XAxis.Scale.Format = "HH:mm";
                    pane.XAxis.Scale.MajorUnit = DateUnit.Hour;
                    pane.XAxis.Scale.MinorUnit = DateUnit.Minute;
                    pane.XAxis.Scale.MinorStep = 15;
                    pane.XAxis.Scale.MajorStep = 1;

                    pane.XAxis.Scale.Max = meter.DiscoveredTime.AddHours(12).ToOADate(); //12 hours = 720 minutes
                    pane.XAxis.Scale.Min = meter.DiscoveredTime.AddMinutes(0).ToOADate();

                    pane.Chart.Fill = new Fill(Color.Ivory, Color.LightCyan, 45.0f);

                }
                else
                {
                    if (count > 0)
                    {
                        curve = pane.CurveList[0] as LineItem;
                        if (curve != null)
                        {
                            editList = curve.Points as IPointListEdit;
                            if (editList != null)
                            {
                                if (editList.Count > 0)
                                {
                                    if (editList[editList.Count - 1].X != meter.FifteenMinuteReads[count - 1].IntervalEnd.ToOADate())
                                    {
                                        editList.Add(meter.FifteenMinuteReads[count - 1].IntervalEnd.ToOADate(), meter.FifteenMinuteReads[count - 1].Quantity);
                                    }
                                }
                                else
                                {
                                    editList.Add(meter.FifteenMinuteReads[count - 1].IntervalEnd.ToOADate(), meter.FifteenMinuteReads[count - 1].Quantity);
                                }
                            }

                        }

                        if (count == 1)
                        {
                            pane.XAxis.Scale.Max = meter.FifteenMinuteReads[count - 1].IntervalEnd.AddHours(12).ToOADate();
                            pane.XAxis.Scale.Min = meter.FifteenMinuteReads[count - 1].IntervalEnd.AddMinutes(-15).ToOADate();
                        }

                        if (meter.DiscoveredTime.AddMinutes(720) < meter.FifteenMinuteReads[count - 1].IntervalEnd)
                        {
                            pane.XAxis.Scale.Max = meter.FifteenMinuteReads[count - 1].IntervalEnd.AddMinutes(15).ToOADate();
                            pane.XAxis.Scale.Min = meter.FifteenMinuteReads[count - 1].IntervalEnd.AddHours(-12).ToOADate();
                        }
                    }
                }

                if (showMe) { master.Add(pane); }


            }

            if (showMe)
            {
                // Refigure the axis ranges for the GraphPanes
                zg1.AxisChange();

                // Layout the GraphPanes using a default Pane Layout
                using (Graphics g = this.CreateGraphics())
                {
                    master.SetLayout(g, PaneLayout.SingleColumn);
                }

                zg1.Invalidate();
            }

        }

        // updated on the hourly timer
        private void ConsumptionHourlyChart(bool showMe)
        {
            int count;
            bool foundPaneMeter;
            bool meterIsNew;
            BarItem curve;
            RollingPointPairList list;
            IPointListEdit editList;

            // Get a reference to the GraphPane instance in the ZedGraphControl
            MasterPane master = zg1.MasterPane;

            if (showMe)
            {
                master.PaneList.Clear();
                master.Title.IsVisible = false;
                master.Title.Text = "Charts";
                master.Margin.All = 5;
                master.Border.IsVisible = false;
            }

            foreach (xbeeMeter meter in xbeeMeters)
            {
                // create new or grab existing pane per meter
                meterIsNew = false;
                foundPaneMeter = false;
                foreach (GraphPaneMeter p in pane60minConsumptionList)
                {
                    if (p.MeterID == meter.ID)
                    {
                        pane = p.Pane;
                        foundPaneMeter = true;
                        break;
                    }
                }
                if (!foundPaneMeter)
                {
                    pane = new GraphPane();
                    GraphPaneMeter newPane = new GraphPaneMeter();
                    newPane.MeterID = meter.ID;
                    newPane.Pane = pane;
                    pane60minConsumptionList.Add(newPane);
                    meterIsNew = true;
                }

                count = meter.HourlyReads.Count;


                if (meterIsNew)
                {
                    // Set the titles and axis labels
                    pane.Title.Text = meter.Name + "\n\r" + "Energy Consumption (Hourly)";
                    pane.XAxis.Title.Text = "Hour";
                    pane.YAxis.Title.Text = "Energy (kWh)";
                    pane.XAxis.Scale.FontSpec.Angle = 90;

                    // Hourly Consumption; rolling point pair, add with no points to start; 
                    list = new RollingPointPairList(24);    // 24 hours
                    curve = pane.AddBar("Energy", list, Color.Blue);

                    editList = list;
                    curve.Bar.Fill = new Fill(Color.LightGreen);
                    curve.Bar.Fill.Type = FillType.Solid;

                    //X-axis hourlyFill = new Fill(Color.Ivory, Color.LightCyan, 45.0f);
                    pane.XAxis.Type = AxisType.Date;
                    pane.XAxis.Scale.Format = "M/dd HH:mm";
                    pane.XAxis.Scale.MajorUnit = DateUnit.Day;
                    pane.XAxis.Scale.MinorUnit = DateUnit.Hour;
                    pane.XAxis.Scale.MinorStep = 1;
                    pane.XAxis.Scale.MajorStep = 1;

                    pane.XAxis.Scale.Max = meter.DiscoveredTime.AddHours(24).ToOADate();
                    pane.XAxis.Scale.Min = meter.DiscoveredTime.AddHours(-1).ToOADate();

                    pane.Chart.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 225), 45);

                }
                else
                {
                    if (count > 0)
                    {

                        editList = pane.CurveList[0].Points as IPointListEdit;
                        if (editList != null)
                        {
                            if (editList.Count > 0)
                            {
                                if (editList[editList.Count - 1].X != meter.HourlyReads[count - 1].IntervalEnd.ToOADate())
                                {
                                    editList.Add(meter.HourlyReads[count - 1].IntervalEnd.ToOADate(), meter.HourlyReads[count - 1].EnergyConsumption);
                                }
                            }
                            else
                            {
                                editList.Add(meter.HourlyReads[count - 1].IntervalEnd.ToOADate(), meter.HourlyReads[count - 1].EnergyConsumption);
                            }
                        }


                        if (count == 1)
                        {
                            pane.XAxis.Scale.Max = meter.HourlyReads[count - 1].IntervalEnd.AddHours(24).ToOADate();
                            pane.XAxis.Scale.Min = meter.HourlyReads[count - 1].IntervalEnd.AddHours(-1).ToOADate();
                        }

                        if (meter.DiscoveredTime.AddHours(24) < meter.HourlyReads[count - 1].IntervalEnd)
                        {
                            pane.XAxis.Scale.Max = meter.HourlyReads[count - 1].IntervalEnd.AddHours(1).ToOADate();
                            pane.XAxis.Scale.Min = meter.HourlyReads[count - 1].IntervalEnd.AddHours(-24).ToOADate();
                        }
                    }
                }

                if (showMe) { master.Add(pane); }


            }

            if (showMe)
            {
                // Refigure the axis ranges for the GraphPanes
                zg1.AxisChange();

                // Layout the GraphPanes using a default Pane Layout
                using (Graphics g = this.CreateGraphics())
                {
                    master.SetLayout(g, PaneLayout.SingleColumn);
                }

                zg1.Invalidate();
            }

        }


        #region "ZedGraph Helpers"

        private void SetSize()
        {
            zg1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zg1.Size = new Size(this.ClientRectangle.Width - 10,
                    this.ClientRectangle.Height - 10);
        }


        /// <summary>
        /// Display customized tooltips when the mouse hovers over a point
        /// </summary>
        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane,
                        CurveItem curve, int iPt)
        {
            // Get the PointPair that is under the mouse
            PointPair pt = curve[iPt];

            return curve.Label.Text + " is " + pt.Y.ToString("f2") + " units at " + pt.X.ToString("f1") + " days";
        }

        /// <summary>
        /// Customize the context menu by adding a new item to the end of the menu
        /// </summary>
        private void MyContextMenuBuilder(ZedGraphControl control, ContextMenuStrip menuStrip,
                        Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Name = "add-beta";
            item.Tag = "add-beta";
            item.Text = "Add a new Beta Point";
            item.Click += new System.EventHandler(AddBetaPoint);

            menuStrip.Items.Add(item);
        }

        /// <summary>
        /// Handle the "Add New Beta Point" context menu item.  This finds the curve with
        /// the CurveItem.Label = "Beta", and adds a new point to it.
        /// </summary>
        private void AddBetaPoint(object sender, EventArgs args)
        {
            // Get a reference to the "Beta" curve IPointListEdit
            IPointListEdit ip = zg1.GraphPane.CurveList["Beta"].Points as IPointListEdit;
            if (ip != null)
            {
                double x = ip.Count * 5.0;
                double y = Math.Sin(ip.Count * Math.PI / 15.0) * 16.0 * 13.5;
                ip.Add(x, y);
                zg1.AxisChange();
                zg1.Refresh();
            }
        }

        // Respond to a Zoom Event
        private void MyZoomEvent(ZedGraphControl control, ZoomState oldState,
                    ZoomState newState)
        {
            // Here we get notification everytime the user zooms
        }

        #endregion

    }

}
