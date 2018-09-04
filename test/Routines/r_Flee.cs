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

        

        public static List<Entity> Citadels = new List<Entity>();

        static r_Flee()
        {
            if (!InitComplete)
            {
                f_Drones.ReturnAllDronesToBay();
                
                Citadels = f_Entities.GetCitadels();

                

                VNI.DebugUI.NewConsoleMessage(Citadels.First().Name);
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
                    //If drones are not launched, warp to citadel
                    if (!f_Drones.CheckIfDronesAreLaunched())
                    {
                        f_Drones.ReturnAllDronesToBay();
                        f_WarpTo.Citadel(Citadels.First(),false);

                        WarpInitiated = true;
                        
                    }
                    //If drones are launched and they are returning and our ship is aligning, do nothing
                    if (f_Drones.CheckIfDronesAreLaunched() && 
                        !f_Drones.CheckIfAllReturning(f_Drones.GetDroneStates()) && 
                        f_Entities.GetEntityMode(VNI.Me.ToEntity) == "Aligned")
                    {


                    }
                    //If drones are launched and they are not returning and we are not aligned, return drones and align to station
                    if (f_Drones.CheckIfDronesAreLaunched() && 
                        !f_Drones.CheckIfAllReturning(f_Drones.GetDroneStates()) && 
                        f_Entities.GetEntityMode(VNI.Me.ToEntity) != "Aligned")
                    {
                        f_Drones.ReturnAllDronesToBay();
                        f_WarpTo.Citadel(Citadels[0], true);
                    }
                }
                //if warp initiated
                if (WarpInitiated == true )
                {
                    string OurStatus = f_Entities.GetEntityMode(VNI.Me.ToEntity);
                    double Distance = (double)f_Entities.DistanceFromPlayerToEntity(Citadels[0]);

                    if (OurStatus == "Warping" && Distance < 200000) return;
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
                            f_WarpTo.Anomaly(f_Anomalies.currentAnom, 0);
                            m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                            
                        }
                        VNI.Wait(10);

                    }
                }

            }
        }
    }
}
