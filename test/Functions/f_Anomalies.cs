using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    class f_Anomalies
    {
        public static List<SystemAnomaly> sortedSysAnoms = new List<SystemAnomaly>();
        public static List<SystemAnomaly> bannedAnoms = new List<SystemAnomaly>();
        public static SystemAnomaly currentAnom;

        static f_Anomalies()
        {
            
            //init
        }
        public static void getAnoms()
        {
            List<SystemAnomaly> sysAnoms = f_Entities.getAnomalies();
            
            foreach (SystemAnomaly a in sysAnoms)
            {
                
                if (a.DungeonName.Contains("Forsaken Hub") && !bannedAnoms.Contains(a)) sortedSysAnoms.Add(a);

                
            }

        }
        public static bool checkForPlayers(SystemAnomaly e)
        {

            List<Entity> queryEntites = f_Entities.GetShipsOnGrid();
            bool anomOccupied = false;

                foreach(Entity p in queryEntites)
                {
                    if (p.Name != VNI.Me.Name) anomOccupied = true;
                }
                //VNI.DebugUI.NewConsoleMessage(p.);

            
            if (anomOccupied)
            {
                 bannedAnoms.Add(e);
                VNI.DebugUI.NewConsoleMessage("Anom Occupied");
            }
            if (!anomOccupied)
            {
                //GOTO COMBAT
               
            }
            return anomOccupied;
        }
        public static void removeAnomaly(SystemAnomaly e)
        {
            sortedSysAnoms.Remove(e);
        }
    }


    
}
