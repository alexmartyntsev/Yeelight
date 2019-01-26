using System;
using System.Threading.Tasks;

namespace YeelightNET
{
    //Device extensions

    /*available methods fo Yeelight Led Celling Light:

         get_prop 
         set_default 
         set_power 
         toggle 
         set_bright 
         set_scene 
         cron_add / cron_get / cron_del 
         start_cf / stop_cf 
         set_ct_abx (color temp int: 1700 - 6500)
         set_name 
         set_adjust 
         adjust_bright 
         adjust_ct    
         
    */
    public static class YeelightFunctions
    {

        public static Device Toggle(this Device device)
        {
            string newState = "on";
            if (device.IsPowered) newState = "off";

            bool IsSuccesful = Yeelight.SendCommand(device, 0, "toggle", new dynamic[] { });
            if (IsSuccesful) device[DeviceProperty.Power] = newState;
            return device;
        }

        public static Device SetDefault(this Device device)
        {
            Yeelight.SendCommand(device, 0, "set_default", new dynamic[] { });

            return device;
        }

        public static Device Power(this Device device, string state, int mode = 0, string effect = "smooth", int duration = 500)
        {
            // mode: 0 - Normal; 1- Sun mode; 5 - Night mode

            if (mode != 0 && mode != 1 && mode != 5) mode = 0; //checking for available modes

            Yeelight.SendCommand(device, 0, "set_power", new dynamic[] {state, effect, duration, mode });

            return device;
        }

        public static Device Blink(this Device device, int duration = 500, int delay = 4000, int count = 2)
        {
            for (int i = 0; i < count; i++)
            {
                device.Toggle();
                device.WaitCmd(delay);
                device.Toggle();
                device.WaitCmd(delay);
            }

            return device;
        }


        public static Device SetColorTemperature(this Device device, int temperature, int duration = 500)
        {
            if (!(temperature >= 1700 && temperature <= 6500))
                return device;

            if (device.IsPowered)
            {
                bool isSuccesful = Yeelight.SendCommand(device, 0, "set_ct_abx", new dynamic[] { temperature, "smooth", duration });

                if (isSuccesful)
                {
                    device[DeviceProperty.ColorTemperature] = temperature;
                    device[DeviceProperty.ColorMode] = 2;
                }
            }

            return device;
        }

        public static Device SetBrightness(this Device device, int brightness, string effect = "smooth", int duration = 500)
        {
            brightness = Math.Max(1, Math.Min(100, Math.Abs(brightness)));

            if (device.IsPowered)
            {

                var isSuccesful = Yeelight.SendCommand(device, 0, "set_bright", new dynamic[] { brightness, effect, duration });

                if (isSuccesful)
                    device[DeviceProperty.Brightness] = brightness;
            }

            return device;
        }

        public static Device SetName(this Device device, string name)
        {
            var isSuccesful = Yeelight.SendCommand(device, 0, "set_name", new dynamic[] { name });

            if (isSuccesful)
                device[DeviceProperty.Name] = name;

            return device;
        }

        public static Device WaitCmd(this Device device, int duration = 500)
        {
            Task.Delay(duration).Wait();
            return device;
        }
    }
}
