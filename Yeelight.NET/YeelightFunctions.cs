using System;
using System.Threading.Tasks;

namespace YeelightNET
{
    //Device extensions

    /*available methods fo Yeelight Led Celling Light:

     "+" means that this method implemented

         get_prop 
       + set_default 
       + set_power 
       + toggle 
       + set_bright 
         set_scene 
         cron_add / cron_get / cron_del 
         start_cf / stop_cf 
       + set_ct_abx (color temp int: 1700 - 6500)
       + set_name 
       + set_adjust 
       + adjust_bright 
       + adjust_ct    
         
    */
    public static class YeelightFunctions
    {


        //toggle
        public static Device Toggle(this Device device)
        {
            

            Yeelight.SendCommand(device, 0, "toggle", new dynamic[] { });
            
            return device;
        }

        //set_default
        public static Device SetDefault(this Device device)
        {
            Yeelight.SendCommand(device, 0, "set_default", new dynamic[] { });

            return device;
        }
        /// <summary>
        /// Изменяем цветовую температуру на процент от 0 до -100% или от 0 до 100%
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <param name="percantage">Процент изменения </param>
        /// <param name="duration">Время в мс, за которое применится эффект</param>
        /// <returns></returns>
        public static Device adjustCT(this Device device, int percantage, int duration = 500)
        {
            if (percantage < -100) percantage = -100;
            if (percantage > 100) percantage = 100;

            Yeelight.SendCommand(device, 0, "adjust_ct", new dynamic[]{percantage, duration});

            return device;
        }
        /// <summary>
        /// Изменяем яркость на процент от 0 до -100% или от 0 до 100%
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <param name="percantage">Процент измненения</param>
        /// <param name="duration">Время в мс, за которое применится эффект</param>
        /// <returns></returns>
        public static Device adjustBright(this Device device, int percantage, int duration = 500)
        {
            if (percantage < -100) percantage = -100;
            if (percantage > 100) percantage = 100;

            Yeelight.SendCommand(device, 0, "adjust_bright", new dynamic[] { percantage, duration });

            return device;
        }
        /// <summary>
        /// Изменение яркости и температуры как делает это пульт.
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <param name="action">"increase", "decrease", "circle" - действия (прибавить, убавить, прибавление по кругу</param>
        /// <param name="property">"bright", "ct" - изменяемое свойство</param>
        /// <returns></returns>
        public static Device setAdjust(this Device device, string action, string property)
        {
            Yeelight.SendCommand(device, 0, "set_adjust", new dynamic[]{ action, property});
            return device;
        }

        //set_power
        public static Device Power(this Device device, string state, int mode = 0, string effect = "smooth", int duration = 500)
        {
            // mode: 0 - Normal; 1- Sun mode; 5 - Night mode

            if (mode != 0 && mode != 1 && mode != 5) mode = 0; //checking for available modes

            Yeelight.SendCommand(device, 0, "set_power", new dynamic[] {state, effect, duration, mode });

            return device;
        }

        public static Device Blink(this Device device, int delay = 500, int count = 2)
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


        /// <summary>
        /// set_ct_abx
        /// Этот метод изменяет температуру света в диапазоне 1700-6500K
        /// </summary>
        /// <param name="temperature">Цветовая температура</param>
        /// <param name="effect">Эффект применения: "sudden" - немедленное применение, параметр "duration" не важен: "smooth" - плавное применение, регулируется параметром "duration"</param>
        /// <param name="duration">Время в мс, за которое применяется эффект. Актуально, только для effect="smooth"</param>
        public static Device SetColorTemperature(this Device device, int temperature, string effect = "smooth" ,int duration = 500)
        {
            if (!(temperature >= 1700 && temperature <= 6500))
                return device;

            if (device.IsPowered)
            {
                bool isSuccesful = Yeelight.SendCommand(device, 0, "set_ct_abx", new dynamic[] { temperature, effect, duration });

                if (isSuccesful)
                {
                    device[DeviceProperty.ColorTemperature] = temperature;
                    device[DeviceProperty.ColorMode] = 2;
                }
            }

            return device;
        }
        //set_bright
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
        //set_name
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
