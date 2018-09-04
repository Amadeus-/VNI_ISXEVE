﻿using EVE.ISXEVE;
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
        public static bool currentAnomComplete = false;
        public static bool lastAnomaly = false;
        public static bool anomOccupied = false;

        static f_Anomalies()
        {

            //init
        }
        public static void GetAnomalies()
        {
            sortedSysAnoms.Clear();
            VNI.DebugUI.ClearAnomalies();

            List<SystemAnomaly> sysAnoms = f_Entities.GetAnomalies();

            foreach (SystemAnomaly a in sysAnoms)
            {


                if (a.DungeonName.Contains("Forsaken Hub")) VNI.DebugUI.addAnomaly(a.Name);
                if (a.DungeonName.Contains("Forsaken Hub") && !bannedAnoms.Any(b => b.Name == a.Name)) sortedSysAnoms.Add(a);


            }
            sortedSysAnoms = sortedSysAnoms.OrderBy(a => Guid.NewGuid()).ToList();

        }
        public static bool CheckForPlayers(SystemAnomaly e)
        {

            List<Entity> queryEntites = f_Entities.GetShipsOnGrid();
            bool anomOccupied = false;

            foreach (Entity p in queryEntites)
            {
                if (p.Name != VNI.Me.Name) anomOccupied = true;
            }
            if (anomOccupied)
            {
                bannedAnoms.Add(e);
                VNI.DebugUI.AddOccupiedAnomaly(e.Name);

            }
            else if (!anomOccupied)
            {
                //GOTO COMBAT
            }
            return anomOccupied;
        }
        public static void RemoveAnomaly(SystemAnomaly e)
        {
            sortedSysAnoms.Remove(e);
        }
    }



}
