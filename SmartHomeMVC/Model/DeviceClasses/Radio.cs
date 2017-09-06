using SmartHomeMVC.Model.DeviceInterfaces;
using SmartHomeMVC.Model.LowLevelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeMVC.Model.DeviceClasses
{
    [Serializable]
    public class Radio : Device, IVolumeable, IChannelable
    {
        public ILowLevelVolumeable SoundController { set; get; }
        public int Volume
        {
            private set
            {
                if (State && value <= 100 && value > 0)
                {
                    volume = value;
                }

            }
            get { return volume; }
        }
        private int channel;
        private int volume;
        public int Channel
        {
            private set
            {
                if (State && value <= 100 && value > 0)
                {
                    channel = value;
                }

            }
            get { return channel; }
        }
        public Radio()
        {
            Channel = 0;
        }
        public Radio(ILowLevelVolumeable soundController)
        {
            SoundController = soundController;
        }

        public string SetChannel(int settingChannel)
        {
            Channel = settingChannel;
            return "channel set:" + Channel;
        }
        public string AdjustChannel(bool increase)
        {
            if (increase == true)
            {
                ++Channel;
                return "channel set: " + Channel;
            }
            else
            {
                --Channel;
                return "channel set: " + Channel;
            }
        }

        public string SetVolume(bool increase)
        {
            Volume = SoundController.AdjustVolume(increase);
            return "volume level set: " + Volume;
        }

        public override string ToString()
        {
            return base.ToString() + " Channel №: " + Channel + ", volume level: " + Volume + ".";
        }
    }
}
