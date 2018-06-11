using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_WarpTo
    {
        static f_WarpTo()
        {
            // Init
        }

        public static void Station(Entity Station)
        {
            Station.WarpTo();
            VNI.DebugUI.NewConsoleMessage("Warping to " + Station.Name);
        }
        public static void Citadel(Entity Citadel, bool Align)
        {
            if (!Align) Citadel.WarpTo();
            if (Align) Citadel.AlignTo();
            VNI.DebugUI.NewConsoleMessage("Warping to " + Citadel.Name);
        }
        public static void anomaly(SystemAnomaly anom, int Distance)
        {
            VNI.DebugUI.NewConsoleMessage("Warping To: " + anom.Name + " " + anom.ID + " @ 30km");
            anom.WarpTo(Distance, false);
        }
        public static void SafeSpot(BookMark SafeSpotBkmk, bool Align)
        {
            VNI.DebugUI.NewConsoleMessage("Warping To Safespot: " + SafeSpotBkmk.Label);
            if(!Align)SafeSpotBkmk.WarpTo();
            if (Align) SafeSpotBkmk.AlignTo();

        }
        
    }
}
