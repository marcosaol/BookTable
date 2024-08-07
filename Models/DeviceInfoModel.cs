using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTable.Models
{
    public class DeviceInfoModel
    {
        public static double ScreenHeight
        {
            get
            {
                var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                return mainDisplayInfo.Height / mainDisplayInfo.Density;
            }
        }

        public static double ScreenWidth
        {
            get
            {
                var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                return mainDisplayInfo.Width / mainDisplayInfo.Density;
            }
        }
    }
}
