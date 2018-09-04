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

                Initialise();
                
            }
        }
        public static void Initialise()
        {
            f_Anomalies.GetAnomalies();
            f_Anomalies.currentAnom = f_Anomalies.sortedSysAnoms.First();

            if (f_Drones.CheckIfDronesAreLaunched()) f_Drones.ReturnAllDronesToBay();

            VNI.DebugUI.NewConsoleMessage("Finding and warping to new anom");
            f_WarpTo.Anomaly(f_Anomalies.currentAnom, 0);
            f_Anomalies.anomOccupied = false;

            VNI.Wait(5);
            
            VNI.Eve.CloseAllMessageBoxes();
            timeOut = DateTime.Now.AddSeconds(10);
            
            initComplete = true;
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                
                if (!initComplete && f_Anomalies.anomOccupied || f_Anomalies.currentAnomComplete) Initialise();
                else if (initComplete)
                {
                    string OurStatus = f_Entities.GetEntityMode(VNI.Me.ToEntity);
                   
                    if (OurStatus == "Warping" && !f_Entities.CheckForNPC()) return;
                    else if (OurStatus != "Warping" && f_Entities.CheckForNPC())
                    {

                        initComplete = false;
                        f_Anomalies.currentAnomComplete = false;

                        VNI.DebugUI.NewConsoleMessage("Arrived at anomaly, checking for players!");

                        m_RoutineController.ActiveRoutine = Routine.IdleAtAnom;
                    }
                    else if (OurStatus != "Warping" && !f_Entities.CheckForNPC() && f_Anomalies.currentAnomComplete)
                    {
                        VNI.DebugUI.NewConsoleMessage("Trying to warp again");

                        Initialise();
                    }
                }

            }
        }
    }
}
