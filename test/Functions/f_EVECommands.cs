using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_EVECommands
    {
        static f_EVECommands()
        {
            // Init
        }

        public static void ExitStation()
        {
            VNI.Eve.Execute(ExecuteCommand.CmdExitStation);
        }

        public static void StopShip()
        {
            VNI.Eve.Execute(ExecuteCommand.CmdStopShip);
        }
        
    }
}
