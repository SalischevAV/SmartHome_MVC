using SmartHomeMVC.Model.Enums;
using SmartHomeMVC.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeMVC.Model.DeviceClasses
{
    [Serializable]
    public class Lamp : IBrightnesable
    {
        public Lamp() { } //ctor for XML-serializable
        public Lamp(bool state, LampMode mode) //ctor for injection
        {
            Brightness = mode;
        }


        public LampMode Brightness { set; get; }


        public LampMode SetBrightness(string setting)
        {
            
            switch (setting)
            {
                case "dim":
                    Brightness = LampMode.dim;
                    return Brightness;
                case "medium":
                    Brightness = LampMode.mediumbright;
                    return Brightness;
                case "hight":
                    Brightness = LampMode.bright;
                    return Brightness;
                case "off":
                default:
                    Brightness = LampMode.off;
                    return Brightness;
            }


        }
    }
}
