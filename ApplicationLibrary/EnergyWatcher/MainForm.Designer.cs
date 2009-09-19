namespace Energy.EnergyWatcher
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAcquiringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAcquiringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingPowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.samplesPlainTextMenuItemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voltageCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartPower2SecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartPower1MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartPower15MinuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartConsumptionhourlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCalibrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devicePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreChartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutEnergyWatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.comTextBox = new System.Windows.Forms.TextBox();
            this.ewNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.startAcquiringToolStripMenuItem,
            this.stopAcquiringToolStripMenuItem,
            this.loggingPowerToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(42, 20);
            this.toolStripMenuItem1.Text = "Data";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // startAcquiringToolStripMenuItem
            // 
            this.startAcquiringToolStripMenuItem.Name = "startAcquiringToolStripMenuItem";
            this.startAcquiringToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.startAcquiringToolStripMenuItem.Text = "Start Acquiring";
            this.startAcquiringToolStripMenuItem.Click += new System.EventHandler(this.startAcquiringToolStripMenuItem_Click);
            // 
            // stopAcquiringToolStripMenuItem
            // 
            this.stopAcquiringToolStripMenuItem.Name = "stopAcquiringToolStripMenuItem";
            this.stopAcquiringToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.stopAcquiringToolStripMenuItem.Text = "Stop Acquiring";
            this.stopAcquiringToolStripMenuItem.Click += new System.EventHandler(this.stopAcquiringToolStripMenuItem_Click);
            // 
            // loggingPowerToolStripMenuItem
            // 
            this.loggingPowerToolStripMenuItem.Name = "loggingPowerToolStripMenuItem";
            this.loggingPowerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.loggingPowerToolStripMenuItem.Text = "Log to Database";
            this.loggingPowerToolStripMenuItem.Click += new System.EventHandler(this.loggingPowerToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.samplesPlainTextMenuItemMenuItem,
            this.voltageCurrentToolStripMenuItem,
            this.chartPower2SecToolStripMenuItem,
            this.chartPower1MinToolStripMenuItem,
            this.chartPower15MinuteToolStripMenuItem,
            this.chartConsumptionhourlyToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // samplesPlainTextMenuItemMenuItem
            // 
            this.samplesPlainTextMenuItemMenuItem.CheckOnClick = true;
            this.samplesPlainTextMenuItemMenuItem.Name = "samplesPlainTextMenuItemMenuItem";
            this.samplesPlainTextMenuItemMenuItem.Size = new System.Drawing.Size(270, 22);
            this.samplesPlainTextMenuItemMenuItem.Text = "Live Samples in Plain Text";
            this.samplesPlainTextMenuItemMenuItem.Click += new System.EventHandler(this.samplesPlainTextMenuItemMenuItem_Click);
            // 
            // voltageCurrentToolStripMenuItem
            // 
            this.voltageCurrentToolStripMenuItem.CheckOnClick = true;
            this.voltageCurrentToolStripMenuItem.Name = "voltageCurrentToolStripMenuItem";
            this.voltageCurrentToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.voltageCurrentToolStripMenuItem.Text = "Live Voltage/Current Chart";
            this.voltageCurrentToolStripMenuItem.Click += new System.EventHandler(this.voltageCurrentToolStripMenuItem_Click);
            // 
            // chartPower2SecToolStripMenuItem
            // 
            this.chartPower2SecToolStripMenuItem.CheckOnClick = true;
            this.chartPower2SecToolStripMenuItem.Name = "chartPower2SecToolStripMenuItem";
            this.chartPower2SecToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.chartPower2SecToolStripMenuItem.Text = "Live 2-second Power Chart";
            this.chartPower2SecToolStripMenuItem.Click += new System.EventHandler(this.chartPower2SecToolStripMenuItem_Click);
            // 
            // chartPower1MinToolStripMenuItem
            // 
            this.chartPower1MinToolStripMenuItem.Name = "chartPower1MinToolStripMenuItem";
            this.chartPower1MinToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.chartPower1MinToolStripMenuItem.Text = "Live 1-minute Power Chart";
            this.chartPower1MinToolStripMenuItem.Click += new System.EventHandler(this.chartPower1MinToolStripMenuItem_Click);
            // 
            // chartPower15MinuteToolStripMenuItem
            // 
            this.chartPower15MinuteToolStripMenuItem.Name = "chartPower15MinuteToolStripMenuItem";
            this.chartPower15MinuteToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.chartPower15MinuteToolStripMenuItem.Text = "Live 15-minute Power Chart";
            this.chartPower15MinuteToolStripMenuItem.Click += new System.EventHandler(this.chartPower15MinuteToolStripMenuItem_Click);
            // 
            // chartConsumptionhourlyToolStripMenuItem
            // 
            this.chartConsumptionhourlyToolStripMenuItem.Name = "chartConsumptionhourlyToolStripMenuItem";
            this.chartConsumptionhourlyToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.chartConsumptionhourlyToolStripMenuItem.Text = "Live Hourly Energy Consumption Chart";
            this.chartConsumptionhourlyToolStripMenuItem.Click += new System.EventHandler(this.chartConsumptionhourlyToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.autoCalibrateToolStripMenuItem,
            this.devicePropertiesToolStripMenuItem,
            this.ratesToolStripMenuItem,
            this.moreChartsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.optionsToolStripMenuItem.Text = "COM Port Configuration...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // autoCalibrateToolStripMenuItem
            // 
            this.autoCalibrateToolStripMenuItem.Name = "autoCalibrateToolStripMenuItem";
            this.autoCalibrateToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.autoCalibrateToolStripMenuItem.Text = "Calibrate Meters...";
            this.autoCalibrateToolStripMenuItem.Click += new System.EventHandler(this.autoCalibrateToolStripMenuItem_Click);
            // 
            // devicePropertiesToolStripMenuItem
            // 
            this.devicePropertiesToolStripMenuItem.Name = "devicePropertiesToolStripMenuItem";
            this.devicePropertiesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.devicePropertiesToolStripMenuItem.Text = "Rename Meters...";
            this.devicePropertiesToolStripMenuItem.Click += new System.EventHandler(this.devicePropertiesToolStripMenuItem_Click);
            // 
            // ratesToolStripMenuItem
            // 
            this.ratesToolStripMenuItem.Name = "ratesToolStripMenuItem";
            this.ratesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.ratesToolStripMenuItem.Text = "Rates...";
            this.ratesToolStripMenuItem.Click += new System.EventHandler(this.ratesToolStripMenuItem_Click);
            // 
            // moreChartsToolStripMenuItem
            // 
            this.moreChartsToolStripMenuItem.Name = "moreChartsToolStripMenuItem";
            this.moreChartsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.moreChartsToolStripMenuItem.Text = "Historical Charts...";
            this.moreChartsToolStripMenuItem.Click += new System.EventHandler(this.moreChartsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutEnergyWatcherToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem3.Text = "Help";
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.checkToolStripMenuItem.Text = "Contact";
            this.checkToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // aboutEnergyWatcherToolStripMenuItem
            // 
            this.aboutEnergyWatcherToolStripMenuItem.Name = "aboutEnergyWatcherToolStripMenuItem";
            this.aboutEnergyWatcherToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.aboutEnergyWatcherToolStripMenuItem.Text = "About Energy Watcher";
            this.aboutEnergyWatcherToolStripMenuItem.Click += new System.EventHandler(this.aboutEnergyWatcherToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1Collapsed = true;
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this.zg1);
            this.splitContainer1.Panel2.Controls.Add(this.comTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(734, 460);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 3;
            // 
            // zg1
            // 
            this.zg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zg1.AutoScroll = true;
            this.zg1.AutoSize = true;
            this.zg1.Location = new System.Drawing.Point(17, 13);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0;
            this.zg1.ScrollMaxX = 0;
            this.zg1.ScrollMaxY = 0;
            this.zg1.ScrollMaxY2 = 0;
            this.zg1.ScrollMinX = 0;
            this.zg1.ScrollMinY = 0;
            this.zg1.ScrollMinY2 = 0;
            this.zg1.Size = new System.Drawing.Size(691, 435);
            this.zg1.TabIndex = 2;
            this.zg1.Visible = false;
            // 
            // comTextBox
            // 
            this.comTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comTextBox.Location = new System.Drawing.Point(0, 0);
            this.comTextBox.Multiline = true;
            this.comTextBox.Name = "comTextBox";
            this.comTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.comTextBox.Size = new System.Drawing.Size(734, 460);
            this.comTextBox.TabIndex = 1;
            this.comTextBox.Visible = false;
            // 
            // ewNotify
            // 
            this.ewNotify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ewNotify.BalloonTipText = "Watching your energy consumption.";
            this.ewNotify.BalloonTipTitle = "Energy Watcher";
            this.ewNotify.Text = "Energy Watcher";
            this.ewNotify.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 484);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Energy Watcher";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutEnergyWatcherToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voltageCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem samplesPlainTextMenuItemMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoCalibrateToolStripMenuItem;
        private System.Windows.Forms.TextBox comTextBox;
        private System.Windows.Forms.ToolStripMenuItem startAcquiringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAcquiringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggingPowerToolStripMenuItem;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.ToolStripMenuItem chartPower2SecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartPower1MinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartPower15MinuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartConsumptionhourlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreChartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratesToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon ewNotify;
        private System.Windows.Forms.ToolStripMenuItem devicePropertiesToolStripMenuItem;

    }
}

