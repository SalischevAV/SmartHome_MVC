namespace SmartHomeMVC.Model.DeviceInterfaces
{
    public interface IFridgeable
    {
        int Temp { set; get; }
        string SetTemp(int settingTemp);
        string IncrTemp();
        string DecrTemp();
    }
}
