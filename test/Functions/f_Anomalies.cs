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
                
                if (a.DungeonName.Contains("Hub") || a.DungeonName.Contains("Haven") && !bannedAnoms.Contains(a)) sortedSysAnoms.Add(a);

                
            }

        }
        public static bool checkForPlayers(SystemAnomaly e)
        {
            
            List<Pilot> pilots = f_Entities.getLocalPilots();
            bool isEmpty = false;
            foreach (Pilot p in pilots)
            {
                
                if(p.ToEntity.Distance < 10000)
                {
                    isEmpty = false;
                }
            }
            
            if (isEmpty)
            {
                //GOTO COMBAT
            }
            if (!isEmpty)
            {
                
                bannedAnoms.Add(e);
            }
            return isEmpty;
        }
        public static void removeAnomaly(SystemAnomaly e)
        {
            sortedSysAnoms.Remove(e);
        }
    }


    
}
