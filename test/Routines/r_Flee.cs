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
        public static bool CitadelMode = false;
        static int r;
        public static List<Entity> Citadels = new List<Entity>();

        static r_Flee()
        {
            if (!InitComplete)
            {
                f_Drones.ReturnAllDronesToBay();
                if (f_Drones.CheckIfDronesAreLaunched()) f_Drones.ReturnAllDronesToBay(); f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), true);
                if (!f_Drones.CheckIfDronesAreLaunched()) f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), false);
                Citadels = f_Entities.GetCitadels();
                r = VNI.rnd.Next(Citadels.Count);

                VNI.DebugUI.NewConsoleMessage("Fleeing!");
                InitComplete = true;
            }
        }
        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                if (WarpInitiated == false && !CitadelMode)
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
                if (WarpInitiated == false && CitadelMode)
                {
                    
                    if (!f_Drones.CheckIfDronesAreLaunched())
                    {
                        
                        f_WarpTo.Citadel(Citadels[0],false);

                        WarpInitiated = true;
                        r = VNI.rnd.Next(Citadels.Count);
                    }
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Drones.checkIfAllReturning(f_Drones.GetDroneStates()) && f_Entities.GetEntityMode(VNI.Me.ToEntity) == "Aligned")
                    {


                    }
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Drones.checkIfAllReturning(f_Drones.GetDroneStates()) && f_Entities.GetEntityMode(VNI.Me.ToEntity) != "Aligned")
                    {

                        //f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), true);
                        //VNI.DebugUI.NewConsoleMessage(Citadels[0].Name);
                        f_Drones.ReturnAllDronesToBay();
                        f_WarpTo.Citadel(Citadels[0], false);
                    }
                }
                if (WarpInitiated == true)
                {
                    string OurStatus = f_Entities.GetEntityMode(VNI.Me.ToEntity);
                    double Distance = (double)f_Entities.DistanceFromPlayerToEntity(Citadels[0]);
                    if (OurStatus == "Warping" && Distance < 200000) return;
                    /*else if(VNI.Me.InStation && !VNI.Me.InSpace)
                    {
                        InitComplete = false;
                        InSafeSpot = true;
                        VNI.DebugUI.NewConsoleMessage("Docked in citadel");
                        //if(f_Social.isSafe())m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                    }*/
                    else if (OurStatus != "Warping" && Distance < 10000)
                    {

                        Citadels[0].Dock();
                    }
                }

            }
        }
    }
}
