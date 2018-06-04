using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    class f_Social
    {
        public static int lowestStanding = 5;
        public static int allianceID = VNI.Me.AllianceID;
        static f_Social()
        {
            //Init
        }

        public static bool isSafe()
        {
            bool isSafe = true;
            List<Pilot> localPilots = f_Entities.getLocalPilots();
            List<Pilot> friendlyPilots = f_Entities.getLocalPilots();

            foreach (Pilot p in localPilots)
            {

                if (p.Standing.AllianceToAlliance < 5.0 && allianceID != p.AllianceID)
                {
                    isSafe = false;
                }

            }
            return isSafe;
        }
    }
}
