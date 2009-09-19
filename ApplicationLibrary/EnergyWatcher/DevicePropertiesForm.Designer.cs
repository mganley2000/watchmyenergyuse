namespace Energy.EnergyWatcher
{
    partial class DevicePropertiesForm
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
            this.butSave = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.ddDevice = new System.Windows.Forms.ComboBox();
            this.labDevices = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labDesc = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupProperties = new System.Windows.Forms.GroupBox();
            this.groupProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(106, 217);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 0;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(205, 217);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 1;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // ddDevice
            // 
            this.ddDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDevice.FormattingEnabled = true;
            this.ddDevice.Location = new System.Drawing.Point(92, 21);
            this.ddDevice.Name = "ddDevice";
            this.ddDevice.Size = new System.Drawing.Size(145, 21);
            this.ddDevice.TabIndex = 2;
            this.ddDevice.SelectionChangeCommitted += new System.EventHandler(this.ddDevice_SelectedIndexCommitted);
            // 
            // labDevices
            // 
            this.labDevices.AutoSize = true;
            this.labDevices.Location = new System.Drawing.Point(52, 24);
            this.labDevices.Name = "labDevices";
            this.labDevices.Size = new System.Drawing.Size(34, 13);
            this.labDevices.TabIndex = 3;
            this.labDevices.Text = "Meter";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(39, 22);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(35, 13);
            this.labName.TabIndex = 4;
            this.labName.Text = "Name";
            // 
            // labDesc
            // 
            this.labDesc.AutoSize = true;
            this.labDesc.Location = new System.Drawing.Point(14, 48);
            this.labDesc.Name = "labDesc";
            this.labDesc.Size = new System.Drawing.Size(60, 13);
            this.labDesc.TabIndex = 5;
            this.labDesc.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 19);
            this.txtName.MaxLength = 32;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(174, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(80, 45);
            this.txtDescription.MaxLength = 256;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(174, 62);
            this.txtDescription.TabIndex = 7;
            // 
            // groupProperties
            // 
            this.groupProperties.Controls.Add(this.txtName);
            this.groupProperties.Controls.Add(this.txtDescription);
            this.groupProperties.Controls.Add(this.labName);
            this.groupProperties.Controls.Add(this.labDesc);
            this.groupProperties.Location = new System.Drawing.Point(12, 59);
            this.groupProperties.Name = "groupProperties";
            this.groupProperties.Size = new System.Drawing.Size(268, 120);
            this.groupProperties.TabIndex = 8;
            this.groupProperties.TabStop = false;
            // 
            // DevicePropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 252);
            this.Controls.Add(this.groupProperties);
            this.Controls.Add(this.labDevices);
            this.Controls.Add(this.ddDevice);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butSave);
            this.Name = "DevicePropertiesForm";
            this.Text = "Rename Meters (Properties)";
            this.groupProperties.ResumeLayout(false);
            this.groupProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.ComboBox ddDevice;
        private System.Windows.Forms.Label labDevices;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labDesc;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupProperties;
    }
}