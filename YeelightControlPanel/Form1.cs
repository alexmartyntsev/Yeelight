using System;
using System.Collections.Generic;
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
       
        public Form1()
        {
            InitializeComponent();
        }

        async void btnScan_Click(object sender, EventArgs e)
        {

            Devices = await Yeelight.DiscoverDevices();
            var mDevice = Devices[0];
            var deviceCount = Devices.Count; 
            
            if (deviceCount > 0)
            {
                String info = String.Format("Name: {0} Power: {1} ID: {2}", mDevice[DeviceProperty.Name], mDevice[DeviceProperty.Power], mDevice[DeviceProperty.Id]);
                //textBoxStatus.Text = ("Найдено устройств:" + deviceCount.ToString());
                //textBoxStatus.Text += mDevice[DeviceProperty.Location];
                //info += String.Format("Cache: {0] \n", mDevice[DeviceProperty.Cache]);
                //info += String.Format("Date: {0] \n", mDevice[DeviceProperty.Date]);
                //info += String.Format("Ext: {0] \n", mDevice[DeviceProperty.Ext]);
                //info += String.Format("Location: {0] \n", mDevice[DeviceProperty.Location]);
                //info += String.Format("ID: {0] \n", mDevice[DeviceProperty.Id]);
                //info += String.Format("Model: {0] \n", mDevice[DeviceProperty.Model]);
                //info += String.Format("Ver: {0] \n", mDevice[DeviceProperty.Ver]);
                //info += String.Format("Support: {0] \n", mDevice[DeviceProperty.Support]);
                //info += String.Format("Power: {0] \n", mDevice[DeviceProperty.Power]);
                //info += String.Format("Bright: {0] \n", mDevice[DeviceProperty.Brightness]);
                //info += String.Format("Color_mode: {0] \n", mDevice[DeviceProperty.ColorMode]);
                //info += String.Format("Color_temp: {0] \n", mDevice[DeviceProperty.ColorTemperature]);
                //info += String.Format("RGB: {0] \n", mDevice[DeviceProperty.RGB]);
                //info += String.Format("Hue: {0] \n", mDevice[DeviceProperty.Hue]);
                //info += String.Format("Sat: {0] \n", mDevice[DeviceProperty.Saturation]);
                //info += String.Format("Name: {0] \n", mDevice[DeviceProperty.Name]);
                
                textBoxStatus.Text = info;
                trackBar1.Value = mDevice[DeviceProperty.Brightness];
                btnPower.Text = string.Format("Power({0})", mDevice[DeviceProperty.Power]);
            }
            else
            {
                textBoxStatus.Text = (@"Устройства не найдены...");
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
            Devices[0].SetBrightness(trackBar1.Value);
            Devices[0].WaitCmd(100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Devices[0].MagicSunrise();
        }
    }
}
