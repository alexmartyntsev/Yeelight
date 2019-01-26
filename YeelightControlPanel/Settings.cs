using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using YeelightNET;

namespace YeelightControlPanel
{
    public partial class Settings : Form
    {
        public List<Device> Devices = new List<Device>();
        String filepath = @"properties.xml";

        public Settings()
        {
            InitializeComponent();
           
        }

        async void button1_Click(object sender, EventArgs e)
        {
            /*
            sDevice[] devices = new[]
            {
               new sDevice{id = 0, Name = "Main", IPadress = "192.168.13.201"},
 
            };
            


            XElement propertiesFile = 
                new XElement("Devices",
                    devices.Select(dev =>
                        new XElement("device",
                            new XAttribute("id", dev.id),
                            new XElement("Name", dev.Name),
                            new XElement("IPadress", dev.IPadress))));
            propertiesFile.Save(filepath);
            */

            Devices = await Yeelight.DiscoverDevices();

            var deviceCount = Devices.Count;

            if (deviceCount > 0)
            {
                

                

                foreach (var dev in Devices)
                {
                    XElement settingsFile = new XElement("Devices",
                        new XElement("Device",
                            new XAttribute("id", dev[DeviceProperty.Id]),
                            new XElement("Name", dev[DeviceProperty.Name]),
                            new XElement("IPadress", dev[DeviceProperty.Location])
                        )
                    );
                    settingsFile.Save(filepath);
                };

                
            }
            else
            {
                
            }
        }
    }

    public class sDevice
    {
        public int id;
        public string Name;
        public string IPadress;
    }

}
