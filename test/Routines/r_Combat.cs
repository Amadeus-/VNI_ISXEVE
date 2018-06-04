using EVE.ISXEVE;
using VNI.Functions;
using VNI.Modules;
using VNI.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LavishVMAPI;

namespace VNI.Routines
{
    static class r_Combat
    {
        // Variables
        public static List<Entity> rats = new List<Entity>();
        public static Entity OrbitPoint;
        public static Entity priorityRat;
        public static List <Entity> Rats;
        public static bool initComplete = false;
        static r_Combat()
        {
            VNI.DebugUI.NewConsoleMessage("In Combat, Launching Drones!");
        }
        public static void Pulse()
        {
            using (new FrameLock(true))
            {

                List<Attacker> Attackers = VNI.Me.GetAttackers();
                List<ActiveDrone> ActiveDrones = VNI.Me.GetActiveDrones();
                
                rats = f_Entities.getRats();

                if (f_Drones.checkIfEngaged() && VNI.Me.TargetCount > 0)
                {
                    f_Drones.EngageTarget();
                }
                if(rats.Count > 0 && VNI.Me.TargetedByCount == rats.Count ) m_CombatDroneController.Pulse();
               



            }
        }
        public static void OrbitCheck()
        {
            if (f_Entities.DistanceFromPlayerToEntity(OrbitPoint) > 30000)
            {
                r_IdleAtAnom.orbitSomething();
            }
        }

    }
}
