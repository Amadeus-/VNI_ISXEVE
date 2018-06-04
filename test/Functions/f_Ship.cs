using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_Ship
    {
        public static void ActivateHardeners()
        {
            if (!f_Modules.Module("MedSlot0").IsActive)f_Modules.Module("MedSlot0").Activate();
            if (!f_Modules.Module("MedSlot1").IsActive) f_Modules.Module("MedSlot1").Activate();
        }
        public static void ActivateAutoTargeter()
        {
            if (!f_Modules.Module("HiSlot0").IsActive)f_Modules.Module("HiSlot0").Activate();
        }
        public static void ActivateShieldBooster()
        {
            if (!f_Modules.Module("MedSlot2").IsActive)f_Modules.Module("MedSlot2").Activate();
            
        }
        public static void activateAllModule()
        {
            ActivateAutoTargeter();
            ActivateHardeners();
            ActivateShieldBooster();
        }
    }
}
