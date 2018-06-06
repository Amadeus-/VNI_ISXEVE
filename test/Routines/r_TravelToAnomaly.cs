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
        private static bool initComplete = false;
        
        static r_TravelToAnomaly()
        {
            if (!initComplete)
            {

                f_Anomalies.getAnoms();
                f_Anomalies.currentAnom = f_Anomalies.sortedSysAnoms.First();

                //VNI.DebugUI.NewConsoleMessage(f_Entities.DistanceBetweenXYZ(VNI.Me.ToEntity, f_Bookmarks.SafeSpots.First().ToEntity).ToString());
                f_WarpTo.anomaly(f_Anomalies.currentAnom,0);
                
                VNI.Wait(5);
                VNI.Eve.CloseAllMessageBoxes();
                
                initComplete = true;
                
            }
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

                        initComplete = true;
                        f_Anomalies.currentAnomComplete = false;
                        //r_IdleAtAnom();
                        m_RoutineController.ActiveRoutine = Routine.IdleAtAnom;
                    }
                    else if(OurStatus != "Warping" && f_Anomalies.currentAnomComplete)
                    {
                        f_Anomalies.getAnoms();
                        f_Anomalies.currentAnom = f_Anomalies.sortedSysAnoms.First();

                        //VNI.DebugUI.NewConsoleMessage(f_Entities.DistanceBetweenXYZ(VNI.Me.ToEntity, f_Bookmarks.SafeSpots.First().ToEntity).ToString());
                        f_WarpTo.anomaly(f_Anomalies.currentAnom, 0);

                        VNI.Wait(5);
                        VNI.Eve.CloseAllMessageBoxes();

                        initComplete = true;
                        
                    }
                }
            }
        }
    }
}
