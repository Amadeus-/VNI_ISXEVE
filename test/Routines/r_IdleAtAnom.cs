using EVE.ISXEVE;
using VNI.Routines;
using VNI.Functions;
using VNI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Routines
{
    static class r_IdleAtAnom
    {
        private static bool InitComplete = false;
        static r_IdleAtAnom()
        {
            if (!InitComplete)
            {

                checkAnom();
            }
        }
        public static void checkAnom()
        {
            bool anomOccupied = f_Anomalies.checkForPlayers(f_Anomalies.currentAnom);
            if (anomOccupied)
            {

                SystemAnomaly anomalyToRemove = f_Anomalies.currentAnom;
                f_Anomalies.removeAnomaly(anomalyToRemove);
                VNI.DebugUI.NewConsoleMessage("Anomaly currently occupied");
                InitComplete = false;
                m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
            }
            else
            {

                VNI.DebugUI.NewConsoleMessage("Anomaly not occupied");
                orbitSomething();
                f_Entities.saveGridEntities();
                InitComplete = false;
                
                m_RoutineController.ActiveRoutine = Routine.Combat;
            }

        }
        public static void orbitSomething()
        {
            List<Entity> collidables = f_Entities.GetCollidables();
            if (collidables != null)
            {
                List<Entity> ClosestCollidable = collidables.OrderBy(o => o.Distance).ToList();
                r_Combat.OrbitPoint = ClosestCollidable.Find(o => o.Name == "Broken Orange Crystal Asteroid");
                r_Combat.OrbitPoint.Orbit(5000);
                
            }

        }
        public static void Pulse()
        {
            if(!InitComplete)
            {
                InitComplete = true;
                checkAnom();
            }

        }
    }
}
