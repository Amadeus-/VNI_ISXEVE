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


                f_WarpTo.anomaly(f_Anomalies.currentAnom,30000);
               
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

                        initComplete = false;
                        m_RoutineController.ActiveRoutine = Routine.IdleAtAnom;
                    }
                }
            }
        }
    }
}
