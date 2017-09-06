namespace SmartHomeMVC.Model.DeviceInterfaces
{
    public interface IChannelable
    {
        int Channel { get; }//По хорошему его нельзя сетать
        string SetChannel(int settingChannel);
        string AdjustChannel(bool increase);
}
}
