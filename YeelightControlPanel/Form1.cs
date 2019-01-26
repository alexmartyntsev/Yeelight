using System;
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
       
        public Form1()
        {
            InitializeComponent();
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
            var mDevice = Devices[0];
            var deviceCount = Devices.Count; 
            
            if (deviceCount > 0)
            {
                EnableElements();
                String info = String.Format("Name: {0}\n Power: {1}\n ID: {2}\n SUPPORT: {3}", mDevice[DeviceProperty.Name], mDevice[DeviceProperty.Power], mDevice[DeviceProperty.Id], mDevice[DeviceProperty.Support]);
             
                
                richTextBoxStatus.Text = info;
                trackBar1.Value = mDevice[DeviceProperty.Brightness];
                btnPower.Text = string.Format("Power({0})", mDevice[DeviceProperty.Power]);
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
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           Devices[0].SetBrightness(trackBar1.Value, "sudden");
        }

        
    }
}
