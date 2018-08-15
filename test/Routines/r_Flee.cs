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
        public static bool CitadelMode = true;

        public static bool lowShield = false;
        private static DateTime BackToAnomalyTime;

        

        static int r;
        public static List<Entity> Citadels = new List<Entity>();

        static r_Flee()
        {
            if (!InitComplete)
            {
                f_Drones.ReturnAllDronesToBay();
                //if (f_Drones.CheckIfDronesAreLaunched()) f_Drones.ReturnAllDronesToBay(); f_WarpTo.SafeSpot(f_Bookmarks.SafeSpots.First(), true);
                
                Citadels = f_Entities.GetCitadels();
                r = VNI.rnd.Next(Citadels.Count);
                VNI.DebugUI.NewConsoleMessage(Citadels.First().Name);
                VNI.DebugUI.NewConsoleMessage("Fleeing!");
                //if (!f_Drones.CheckIfDronesAreLaunched()) f_WarpTo.Citadel(Citadels.First(),false);
                InitComplete = true;
            }
        }
        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                /*if(VNI.InCapsule == true)
                {
                    if(VNI.Me.InStation)
                    {

                    }
                    else if(!VNI.Me.InStation)
                    {

                    }
                }*/
               
                if (WarpInitiated == false && CitadelMode)
                {
                    
                    if (!f_Drones.CheckIfDronesAreLaunched())
                    {
                        f_Drones.ReturnAllDronesToBay();
                        f_WarpTo.Citadel(Citadels.First(),false);

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
                        f_WarpTo.Citadel(Citadels[0], true);
                    }
                }
                if(WarpInitiated == false && lowShield || VNI.InCapsule)
                {
                    if (!f_Drones.CheckIfDronesAreLaunched())
                    {
                        f_Drones.ReturnAllDronesToBay();
                        f_WarpTo.Citadel(Citadels.First(), false);

                        WarpInitiated = true;
                        BackToAnomalyTime = DateTime.Now.AddSeconds(60);
                        r = VNI.rnd.Next(Citadels.Count);
                    }
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Drones.checkIfAllReturning(f_Drones.GetDroneStates()) && f_Entities.GetEntityMode(VNI.Me.ToEntity) == "Aligned")
                    {


                    }
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Drones.checkIfAllReturning(f_Drones.GetDroneStates()) && f_Entities.GetEntityMode(VNI.Me.ToEntity) != "Aligned")
                    {

                        f_Drones.ReturnAllDronesToBay();
                        f_WarpTo.Citadel(Citadels[0], true);
                        
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
                        VNI.Wait(10);

                    }
                    else if(OurStatus != "Warping" && Distance > 200000)
                    {
                        WarpInitiated = false;
                    }
                    else if (OurStatus != "Warping" && Distance < 10000 && lowShield)
                    {

                        if(DateTime.Now > BackToAnomalyTime)
                        {
                            f_WarpTo.anomaly(f_Anomalies.currentAnom, 0);
                            m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                            
                        }
                        VNI.Wait(10);

                    }
                }

            }
        }
    }
}
