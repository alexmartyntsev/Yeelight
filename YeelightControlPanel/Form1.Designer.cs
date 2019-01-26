namespace YeelightControlPanel
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonPowerON = new System.Windows.Forms.Button();
            this.buttonPowerOFF = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(686, 9);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnPower
            // 
            this.btnPower.Enabled = false;
            this.btnPower.Location = new System.Drawing.Point(12, 234);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(75, 23);
            this.btnPower.TabIndex = 2;
            this.btnPower.Tag = "elements";
            this.btnPower.Text = "Toggle";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(668, 156);
            this.richTextBoxStatus.TabIndex = 4;
            this.richTextBoxStatus.Text = "";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(687, 144);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Tag = "elements";
            this.buttonSave.Text = "Save state";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonPowerON
            // 
            this.buttonPowerON.Enabled = false;
            this.buttonPowerON.Location = new System.Drawing.Point(13, 175);
            this.buttonPowerON.Name = "buttonPowerON";
            this.buttonPowerON.Size = new System.Drawing.Size(75, 23);
            this.buttonPowerON.TabIndex = 6;
            this.buttonPowerON.Tag = "elements";
            this.buttonPowerON.Text = "Power ON";
            this.buttonPowerON.UseVisualStyleBackColor = true;
            this.buttonPowerON.Click += new System.EventHandler(this.buttonPowerON_Click);
            // 
            // buttonPowerOFF
            // 
            this.buttonPowerOFF.Enabled = false;
            this.buttonPowerOFF.Location = new System.Drawing.Point(13, 205);
            this.buttonPowerOFF.Name = "buttonPowerOFF";
            this.buttonPowerOFF.Size = new System.Drawing.Size(75, 23);
            this.buttonPowerOFF.TabIndex = 7;
            this.buttonPowerOFF.Tag = "elements";
            this.buttonPowerOFF.Text = "Power OFF";
            this.buttonPowerOFF.UseVisualStyleBackColor = true;
            this.buttonPowerOFF.Click += new System.EventHandler(this.buttonPowerOFF_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Location = new System.Drawing.Point(94, 174);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(137, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Tag = "elements";
            this.comboBox1.Text = "mode";
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(12, 372);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(560, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Tag = "elements";
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 356);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Set brightness";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonPowerOFF);
            this.Controls.Add(this.buttonPowerON);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnScan);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonPowerON;
        private System.Windows.Forms.Button buttonPowerOFF;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
    }
}

