using EVE.ISXEVE.Interfaces;
using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_Modules
    {

        static f_Modules()
        {
            // Init
        }
        public static List<IModule> GetActiveModules()
        {
            List<IModule> activeModules = new List<IModule>();
            List<IModule> ModulesFitted = VNI.MyShip.GetModules();

            IModule afterburner;
            IModule autotargeter;
            foreach (IModule module in ModulesFitted)
            {
                if (module.IsActivatable) activeModules.Add(module);

            }

            //redo this
            foreach (IModule module in activeModules)
            {
                if (module.MaxVelocityBonus > 0)
                {
                    afterburner = module;
                }
                else
                {
                    autotargeter = module;
                }
            }
            return activeModules;
        }
    }
}
