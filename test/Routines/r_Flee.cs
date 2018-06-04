using EVE.ISXEVE;
using VNI.Functions;
using VNI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LavishVMAPI;

namespace VNI.Routines
{
    static class r_Flee
    {
        public static bool InitComplete = false;
        public static bool WarpInitiated = false;
        public static bool InSafeSpot = true;
        static r_Flee()
        {
            if (!InitComplete)
            {
                
                if (f_Drones.CheckIfDronesAreLaunched()) f_Drones.ReturnAllDronesToBay(); f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), true);
                if (!f_Drones.CheckIfDronesAreLaunched()) f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), false);
               

                VNI.DebugUI.NewConsoleMessage("Fleeing!");
                InitComplete = true;
            }
        }
        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                if (WarpInitiated == false)
                {
                    if (!f_Drones.CheckIfDronesAreLaunched())
                    {
                        f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), false);
                        WarpInitiated = true;
                    }
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Drones.checkIfAllReturning(f_Drones.GetDroneStates()) && f_Entities.GetEntityMode(VNI.Me.ToEntity) == "Aligned")
                    {


                    }
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Drones.checkIfAllReturning(f_Drones.GetDroneStates()) && f_Entities.GetEntityMode(VNI.Me.ToEntity) != "Aligned")
                    {

                        f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), true);
                    }
                }
                if (WarpInitiated == true)
                {
                    string OurStatus = f_Entities.GetEntityMode(VNI.Me.ToEntity);
                    double Distance = 100000000;
                    if (OurStatus == "Warping" && Distance < 200000) return;
                    else if (OurStatus != "Warping" && Distance < 5000)
                    {

                        InitComplete = false;
                        InSafeSpot = true;
                        m_RoutineController.ActiveRoutine = Routine.IdleAtAnom;
                    }
                }

            }
        }
    }
}
