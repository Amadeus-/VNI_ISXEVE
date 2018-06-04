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
        public static IModule Module(String ModuleSlot)
        {
            return VNI.MyShip.Module(ModuleSlot);
        }
    }
}
