namespace Energy.EnergyWatcher
{
    partial class CalibrateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrateForm));
            this.butStart = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.labCalibrateInstructions = new System.Windows.Forms.Label();
            this.ddDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labDone = new System.Windows.Forms.Label();
            this.butOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(81, 252);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(75, 23);
            this.butStart.TabIndex = 0;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(162, 252);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // labCalibrateInstructions
            // 
            this.labCalibrateInstructions.Location = new System.Drawing.Point(12, 9);
            this.labCalibrateInstructions.Name = "labCalibrateInstructions";
            this.labCalibrateInstructions.Size = new System.Drawing.Size(306, 60);
            this.labCalibrateInstructions.TabIndex = 2;
            this.labCalibrateInstructions.Text = resources.GetString("labCalibrateInstructions.Text");
            // 
            // ddDevice
            // 
            this.ddDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDevice.FormattingEnabled = true;
            this.ddDevice.Location = new System.Drawing.Point(107, 81);
            this.ddDevice.MaxDropDownItems = 32;
            this.ddDevice.Name = "ddDevice";
            this.ddDevice.Size = new System.Drawing.Size(130, 21);
            this.ddDevice.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Meter";
            // 
            // labDone
            // 
            this.labDone.AutoSize = true;
            this.labDone.Location = new System.Drawing.Point(104, 149);
            this.labDone.Name = "labDone";
            this.labDone.Size = new System.Drawing.Size(103, 26);
            this.labDone.TabIndex = 5;
            this.labDone.Text = "The device {s}\r\nhas been calibrated.";
            this.labDone.Visible = false;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(123, 252);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 6;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Visible = false;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // CalibrateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(317, 287);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.labDone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddDevice);
            this.Controls.Add(this.labCalibrateInstructions);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butStart);
            this.Name = "CalibrateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calibrate Meters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label labCalibrateInstructions;
        private System.Windows.Forms.ComboBox ddDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labDone;
        private System.Windows.Forms.Button butOK;
    }
}