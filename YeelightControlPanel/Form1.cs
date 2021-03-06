﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
/*using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks; */
using System.Windows.Forms;
using YeelightNET;


namespace YeelightControlPanel
{
    public partial class Form1 : Form
    {
        public List<Device> Devices = new List<Device>();
        public Boolean IsIst = false;

        public class Mode
        {
            public string Name { get; set; }
            public int Value { get; set; }

        }


        public Form1()
        {
            InitializeComponent();

            List<Mode> modes = new List<Mode>
            {
                new Mode {Name = "Normal mode", Value = 0},
                new Mode {Name = "Sun mode", Value = 1},
                new Mode {Name = "Moon mode", Value = 5}
            };
            comboBox1.DataSource = modes;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Value";

        }

        private void EnableElements(string tag = "elements")
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == tag)
                {
                    ctrl.Enabled = true;
                }
            }
        }

 

        async void btnScan_Click(object sender, EventArgs e)
        {

            Devices = await Yeelight.DiscoverDevices();
            
            var deviceCount = Devices.Count; 
            
            if (deviceCount > 0)
            {
                EnableElements();
                String info = String.Format("Name: {0}\n IP: {1}\n ID: {2}", Devices[0][DeviceProperty.Name], Devices[0][DeviceProperty.Location], Devices[0][DeviceProperty.Id]);
             
                
                richTextBoxStatus.Text = info;
                trackBar1.Value = Devices[0][DeviceProperty.Brightness];
                trackBarCT.Value = Devices[0][DeviceProperty.ColorTemperature];
                btnPower.Text = string.Format("Power({0})", Devices[0][DeviceProperty.Power]);

                textBoxBright.Text = Devices[0][DeviceProperty.Brightness].ToString();
                textBoxCT.Text = Devices[0][DeviceProperty.ColorTemperature].ToString();
            }
            else
            {
                richTextBoxStatus.Text = (@"Устройства не найдены...");
            }
            
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            Devices[0].Toggle();
            Device mDevice = Devices[0];
            btnPower.Text = String.Format("Power({0})", mDevice[DeviceProperty.Power]);
            trackBar1.Value = Devices[0][DeviceProperty.Brightness];
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           Devices[0].SetBrightness(trackBar1.Value, "sudden");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Devices[0].SetDefault();
        }

        private void buttonPowerON_Click(object sender, EventArgs e)
        {   
            
            var mode = (int)comboBox1.SelectedValue;
            Devices[0].Power("on", mode,"sudden");
        }

        private void buttonPowerOFF_Click(object sender, EventArgs e)
        {
            Devices[0].Power("off");
        }


        private void trackBarCT_MouseUp(object sender, MouseEventArgs e)
        {
            Devices[0].SetColorTemperature(trackBarCT.Value, "sudden");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Devices[0].setAdjust("increase", "bright");
            textBoxBright.Text = Devices[0][DeviceProperty.Brightness].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Devices[0].setAdjust("decrease", "bright");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Devices[0].setAdjust("circle", "bright");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Devices[0].setAdjust("increase", "ct");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Devices[0].setAdjust("decrease", "ct");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Devices[0].setAdjust("circle", "ct");
        }

        private void textBoxBright_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxCT_TextChanged(object sender, EventArgs e)
        {
            trackBarCT.Value = int.Parse(textBoxCT.Text);
        }

        private void textBoxBright_Leave(object sender, EventArgs e)
        {
            trackBar1.Value = int.Parse(textBoxBright.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Devices[0].Blink(250, 3);
        }
    }
}
