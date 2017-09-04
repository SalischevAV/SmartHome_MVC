using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeMVC.Model.LowLevelInterfaces
{
    public interface ILowLevelVolumeable
    {
        int VolLevel { set; get; }
        int AdjustVolume(bool increase);
    }
}
