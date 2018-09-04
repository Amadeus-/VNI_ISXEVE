using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_Drones
    {
        static f_Drones()
        {
            // Init
        }

        public static void ReturnAllDronesToBay()
        {
            VNI.Eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
        }

        public static void EngageTarget()
        {
            VNI.Eve.Execute(ExecuteCommand.CmdDronesEngage);
        }
        public static List<int> GetDroneStates()
        {
            List<ActiveDrone> ActiveDrones = VNI.Me.GetActiveDrones();
            List<int> ActiveDronesStates = new List<int>();

            if (ActiveDrones.Count > 0)
            {
                foreach (ActiveDrone a in ActiveDrones)
                {
                    ActiveDronesStates.Add(a.State);
                }
            }

            return ActiveDronesStates;
        }
        public static bool CheckIfAllReturning(List<int> ActiveDronesStates)
        {
            bool returning = true;
            foreach (int a in ActiveDronesStates) if (a != 4) returning = false;
            return returning;
        }
        public static bool CheckIfEngaged()
        {
            bool engaged = true;
            List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();
            foreach (ActiveDrone a in activeDrones) if (a.State == 0) engaged = false;
            return engaged;
        }
        public static bool CheckIfDronesAreLaunched()
        {
            List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();
            if (activeDrones.Count == 0) return false;
            else return true;
        }
        public static bool CheckIfSplitAggro()
        {
            List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();

            Entity target = activeDrones[0].Target;
            foreach (ActiveDrone a in activeDrones) if (a.Target != target) return true;
            return false;
        }
        public static Entity CheckDroneTarget()
        {
            Entity DroneTarget = null;
            List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();
            foreach (ActiveDrone a in activeDrones)
            {
                DroneTarget = a.Target;
            }
            return DroneTarget;
        }
        public static bool CheckIfDronesAreOnTarget(Entity rat)
        {
            if(CheckDroneTarget().ID == rat.ID)
            {

                return true;
            }
            else
            {
                return false;
            }
            
        }
    }

}
