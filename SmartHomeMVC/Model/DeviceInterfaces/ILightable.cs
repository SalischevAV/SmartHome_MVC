using SmartHomeMVC.Model.Enums;

namespace SmartHomeMVC.Model.DeviceInterfaces
{
    public interface ILightable
    {
        LampMode LightBrightnes { set; get; }
        string SetBrightnes(string settingBrightness);
    }
}
