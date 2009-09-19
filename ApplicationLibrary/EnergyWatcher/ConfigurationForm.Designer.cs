namespace Energy.EnergyWatcher
{
    partial class ConfigurationForm
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
            this.butUpdate = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.labDef = new System.Windows.Forms.Label();
            this.txtCOMPort = new System.Windows.Forms.TextBox();
            this.txtBaud = new System.Windows.Forms.TextBox();
            this.txtParity = new System.Windows.Forms.TextBox();
            this.txtDataBits = new System.Windows.Forms.TextBox();
            this.txtStopBits = new System.Windows.Forms.TextBox();
            this.labComPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butUpdate
            // 
            this.butUpdate.Location = new System.Drawing.Point(71, 204);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(75, 23);
            this.butUpdate.TabIndex = 0;
            this.butUpdate.Text = "Update";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.Update_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(152, 204);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "Close";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // labDef
            // 
            this.labDef.AutoSize = true;
            this.labDef.Location = new System.Drawing.Point(101, 9);
            this.labDef.Name = "labDef";
            this.labDef.Size = new System.Drawing.Size(106, 13);
            this.labDef.TabIndex = 2;
            this.labDef.Text = "Default Configuration";
            // 
            // txtCOMPort
            // 
            this.txtCOMPort.Location = new System.Drawing.Point(123, 32);
            this.txtCOMPort.Name = "txtCOMPort";
            this.txtCOMPort.Size = new System.Drawing.Size(100, 20);
            this.txtCOMPort.TabIndex = 3;
            // 
            // txtBaud
            // 
            this.txtBaud.Location = new System.Drawing.Point(123, 58);
            this.txtBaud.Name = "txtBaud";
            this.txtBaud.Size = new System.Drawing.Size(100, 20);
            this.txtBaud.TabIndex = 4;
            // 
            // txtParity
            // 
            this.txtParity.Location = new System.Drawing.Point(123, 84);
            this.txtParity.Name = "txtParity";
            this.txtParity.Size = new System.Drawing.Size(100, 20);
            this.txtParity.TabIndex = 5;
            // 
            // txtDataBits
            // 
            this.txtDataBits.Location = new System.Drawing.Point(123, 110);
            this.txtDataBits.Name = "txtDataBits";
            this.txtDataBits.Size = new System.Drawing.Size(100, 20);
            this.txtDataBits.TabIndex = 6;
            // 
            // txtStopBits
            // 
            this.txtStopBits.Location = new System.Drawing.Point(123, 136);
            this.txtStopBits.Name = "txtStopBits";
            this.txtStopBits.Size = new System.Drawing.Size(100, 20);
            this.txtStopBits.TabIndex = 7;
            // 
            // labComPort
            // 
            this.labComPort.AutoSize = true;
            this.labComPort.Location = new System.Drawing.Point(65, 35);
            this.labComPort.Name = "labComPort";
            this.labComPort.Size = new System.Drawing.Size(53, 13);
            this.labComPort.TabIndex = 8;
            this.labComPort.Text = "COM Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Baud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Stop Bits";
            // 
            // labResult
            // 
            this.labResult.AutoSize = true;
            this.labResult.Location = new System.Drawing.Point(104, 170);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(35, 13);
            this.labResult.TabIndex = 13;
            this.labResult.Text = "label5";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(291, 250);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labComPort);
            this.Controls.Add(this.txtStopBits);
            this.Controls.Add(this.txtDataBits);
            this.Controls.Add(this.txtParity);
            this.Controls.Add(this.txtBaud);
            this.Controls.Add(this.txtCOMPort);
            this.Controls.Add(this.labDef);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butUpdate);
            this.Name = "ConfigurationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "COM Port Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label labDef;
        private System.Windows.Forms.TextBox txtCOMPort;
        private System.Windows.Forms.TextBox txtBaud;
        private System.Windows.Forms.TextBox txtParity;
        private System.Windows.Forms.TextBox txtDataBits;
        private System.Windows.Forms.TextBox txtStopBits;
        private System.Windows.Forms.Label labComPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labResult;
    }
}