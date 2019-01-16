using System;
using System.Collections.Generic;

using YeelightNET;

namespace YeelightTest
{
    class Program
    {
        /* 
            Use async main in C#7.1 and after.
            Devices = await Yeelight.DiscoverDevices()
            instead of
            Devices = Yeelight.DiscoverDevices().Result
        */
        static void Main(string[] args)
        {
            Console.WriteLine("Поиск устройств...");
            Console.WriteLine("\n Список команд: switch, blink, ct, new temp, rgb, bright, test, name, status, quit");
            List<Device> Devices = new List<Device>();

            //Search for devices in the local network
            Devices = Yeelight.DiscoverDevices().Result;

            foreach (var device in Devices)
            {
                Console.WriteLine("Устройство: {0}, Имя: {1}, Состояние: {2}", device[DeviceProperty.Id], device[DeviceProperty.Name], device[DeviceProperty.Power]);

                //Print when a property changes
                device.OnPropertyChanged += (dp) => { Console.WriteLine("Ответ: {0}", dp.ToString()); };
            }

            if (Devices.Count == 0)
            {
                Console.WriteLine("Не могу найти ни одного устройства. Убедитесь, что разрешили управление по сети");
                return;
            }

            /*Command examples
            
            toggle 1 --Toggle light with index 1
            rgb 0 --Set rgb value for light with index 0
            bright 2 --Set brightness for light with index 2

            */
            while (true)
            {
                Console.Write("\nКоманда: ");
                var command = Console.ReadLine();

                string function = command.Split(' ')[0];
                int mIndex = 0;

                try
                {
                    mIndex = int.Parse(command.Split(' ')[1]);

                    if (mIndex < 0 || mIndex >= Devices.Count)
                        mIndex = 0;
                }
                catch
                {
                }

                Device mDevice = Devices[mIndex];


                if (function == "switch")
                {
                    mDevice.Toggle();
                }
                else if (function == "blink")
                {
                    mDevice.Blink();
                }
                else if (function == "ct")
                {
                    Console.Write("\nNew Temp: ");
                    int temp = int.Parse(Console.ReadLine());

                    mDevice.SetColorTemperature(temp);
                }
                /*else if (function == "rgb")
                {
                    Console.Write("\nNew Color(R,G,B): ");
                    string[] rgb = Console.ReadLine().Split(',');

                    mDevice.SetRgbColor(int.Parse(rgb[0]), int.Parse(rgb[1]), int.Parse(rgb[2]));
                }*/
                else if (function == "bright")
                {
                    Console.Write("\nNew Brightness: ");
                    int bright = int.Parse(Console.ReadLine());

                    mDevice.SetBrightness(bright);
                }
                else if (function == "test")
                {
                    Console.Write("\nTesting...");

                    mDevice.Toggle().WaitCmd(2000).SetBrightness(20).WaitCmd(5000).SetBrightness(5).SetColorTemperature(2000).WaitCmd(5000).Toggle();
                }
                else if (function == "name")
                {
                    Console.Write("\nCurrent name:{0}", mDevice[DeviceProperty.Name]);
                    Console.Write("\nNew name: ");
                    var newName = Console.ReadLine();

                    mDevice.SetName(newName);
                }
                else if (function == "status")
                {
                    Console.WriteLine("\nStatus:");

                    Console.WriteLine("Id: {0}", mDevice[DeviceProperty.Id]);
                    Console.WriteLine("Location: {0}", mDevice[DeviceProperty.Location]);
                    Console.WriteLine("Name: {0}", mDevice[DeviceProperty.Name]);
                    Console.WriteLine("State: {0}", mDevice[DeviceProperty.Power]);
                    Console.WriteLine("Brightness: {0}", mDevice[DeviceProperty.Brightness]);
                    Console.WriteLine("Color Mode: {0}", mDevice[DeviceProperty.ColorMode]);
                    //Console.WriteLine("RGB: {0},{1},{2}", mDevice[DeviceProperty.RGB] >> 16, (Devices[0][DeviceProperty.RGB] >> 8) & 255, Devices[0][DeviceProperty.RGB] & 255);
                    Console.WriteLine("Color Temperature: {0} K", mDevice[DeviceProperty.ColorTemperature]);
                    Console.WriteLine("HW_ver: {0}", mDevice[DeviceProperty.Ver]);
                    Console.WriteLine("Support: {0}", mDevice[DeviceProperty.Support]);
                }
                else if (function == "quit")
                {
                    break;
                }
            }

        }
    }
}
