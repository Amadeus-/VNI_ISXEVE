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
        public static List<IModule> activeModules = new List<IModule>();
        public static List<long> MiningLaserTargetIDs = new List<long>();
        public static IModule afterburner;
        public static IModule autotargeter;
        static m_ModuleManagement()
        {
            activeModules = f_Modules.GetActiveModules();
            foreach (IModule modules in activeModules)
            {
                if (modules.MaxVelocityBonus > 0)
                {
                    afterburner = modules;
                }
                else
                {
                    autotargeter = modules;
                }
            }
            //PopulateMiningLaserTargetIDsList(MiningLasers.Count);
        }
        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                //Targets();
                //Activation();
            }
        }

        public static void Activation()
        {

            if (!afterburner.IsActive)
            {
                afterburner.Activate();

            }
            if (!autotargeter.IsActive)
            {
                //autotargeter.Activate();
            }
        }
        public static void Deactivation()
        {
            if (afterburner.IsActive)
            {
                afterburner.Deactivate();

            }
        }
    }
}
