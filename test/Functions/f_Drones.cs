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
        public static bool checkIfAllReturning(List<int> ActiveDronesStates)
        {
            bool returning = true;
            foreach (int a in ActiveDronesStates) if (a != 4) returning = false;
            return returning;
        }
        public static bool checkIfEngaged()
        {
            bool reengage = false;
            List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();
            foreach (ActiveDrone a in activeDrones) if (a.State == 0) reengage = true;
            return reengage;
        }
        public static bool CheckIfDronesAreLaunched()
        {
            List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();
            if (activeDrones.Count == 0) return false;
            else return true;
        }

    }

}
