using EVE.ISXEVE;
using VNI.Functions;
using VNI.Modules;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Routines
{
    class r_TravelToAnomaly
    {
        public static bool initComplete = false;
        public static DateTime timeOut;

        static r_TravelToAnomaly()
        {
            if (!initComplete)
            {

                f_Anomalies.GetAnoms();
                f_Anomalies.currentAnom = f_Anomalies.sortedSysAnoms.First();
                if (f_Drones.CheckIfDronesAreLaunched()) f_Drones.ReturnAllDronesToBay();
                //VNI.DebugUI.NewConsoleMessage(f_Entities.DistanceBetweenXYZ(VNI.Me.ToEntity, f_Bookmarks.SafeSpots.First().ToEntity).ToString());
                f_WarpTo.anomaly(f_Anomalies.currentAnom,0);
                timeOut = DateTime.Now.AddSeconds(10);
                VNI.Wait(5);
                VNI.Eve.CloseAllMessageBoxes();
                
                initComplete = true;
                
            }
        }
        public static void initialise()
        {
            f_Anomalies.GetAnoms();
            f_Anomalies.currentAnom = f_Anomalies.sortedSysAnoms.First();
            if (f_Drones.CheckIfDronesAreLaunched()) f_Drones.ReturnAllDronesToBay();
            VNI.DebugUI.NewConsoleMessage("Finding and warping to new anom");
            f_WarpTo.anomaly(f_Anomalies.currentAnom, 0);

            VNI.Wait(5);
            
            
            //VNI.Eve.CloseAllMessageBoxes();
            timeOut = DateTime.Now.AddSeconds(10);
            
            initComplete = true;
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                if (initComplete)
                {
                    //VNI.Wait(10);
                    string OurStatus = f_Entities.GetEntityMode(VNI.Me.ToEntity);
                   

                    if (OurStatus == "Warping" && !f_Entities.checkForNPC()) return;
                    else if (OurStatus != "Warping" && f_Entities.checkForNPC())
                    {

                        initComplete = false;
                        f_Anomalies.currentAnomComplete = false;
                        VNI.DebugUI.NewConsoleMessage("Arrived at anomaly, checking for players!");

                        m_RoutineController.ActiveRoutine = Routine.IdleAtAnom;
                        
                        //List<EVEWindow> windows = f_Window.GetActiveWindows();
                        ///foreach (EVEWindow w in windows) VNI.DebugUI.NewConsoleMessage(w.Text);
                    }
                    else if (OurStatus != "Warping" && !f_Entities.checkForNPC() && f_Anomalies.currentAnomComplete)
                    {
                        VNI.DebugUI.NewConsoleMessage("Trying to warp again");
                        initialise();
                    }
                }
                if (!initComplete && f_Anomalies.anomOccupied) initialise();
                if (!initComplete && f_Anomalies.currentAnomComplete) initialise();
            }
        }
    }
}
