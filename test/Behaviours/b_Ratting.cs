using EVE.ISXEVE;
using VNI.Functions;
using VNI.Modules;
using VNI.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VNI.Behaviours
{
    class b_Ratting
    {
        public static bool InitComplete = false;

        static b_Ratting()
        {
            if (!InitComplete)
            {
                InitComplete = true;
                
                f_Bookmarks.GetSafeSpots();
                
            }
        }

        public static void Pulse()
        {
            if (VNI.Me.InStation && !f_Anomalies.lastAnomaly)
            {
                if (m_RoutineController.ActiveRoutine != Routine.Station)
                {
                    m_RoutineController.ActiveRoutine = Routine.Station;
                }
            }
            else if (!VNI.Me.InStation && VNI.Me.InSpace && !f_Anomalies.lastAnomaly)
            {
                if (m_RoutineController.ActiveRoutine == Routine.Idle)
                {
                    m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                }
            }
            m_RoutineController.Pulse();
        }
    }
}


