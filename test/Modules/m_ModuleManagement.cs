using EVE.ISXEVE;
using VNI.Functions;
using LavishVMAPI;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Modules
{
    static class m_ModuleManagement
    {
        static m_ModuleManagement()
        {
        }
        public static void Pulse()
        {
            using (new FrameLock(true))
            {
               activateAllModules();
            }
        }

        public static void ActivateHardeners()
        {
            if (!f_Modules.Module("MedSlot0").IsActive) f_Modules.Module("MedSlot0").Activate();
            if (!f_Modules.Module("MedSlot1").IsActive) f_Modules.Module("MedSlot1").Activate();
            if (!f_Modules.Module("MedSlot3").IsActive) f_Modules.Module("MedSlot3").Activate();
        }
        public static void ActivateAutoTargeter()
        {
            if (!f_Modules.Module("HiSlot0").IsActive) f_Modules.Module("HiSlot0").Activate();
        }
        public static void ActivateShieldBooster()
        {
            if (!f_Modules.Module("MedSlot2").IsActive) f_Modules.Module("MedSlot2").Activate();

        }
        public static void activateAllModules()
        {
            ActivateAutoTargeter();
            ActivateHardeners();
            ActivateShieldBooster();
        }
    }
}
