using SmartHomeMVC.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeMVC.Model.LowLevelInterfaces
{
    public interface IFanable
    {
        FanMode SpeedFan { set; get; }
        FanMode SetSpeedFan(string setting);

    }
}
