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
        public static bool anomOccupied = false;
        static r_IdleAtAnom()
        {
            if (!InitComplete)
            {
                //VNI.Eve.Execute(ExecuteCommand.CmdCloseAllWindows);
                CheckAnom();
            }
        }
        public static void CheckAnom()
        {

            f_Anomalies.anomOccupied = f_Anomalies.CheckForPlayers(f_Anomalies.currentAnom);
            if (f_Anomalies.anomOccupied)
            {

                SystemAnomaly anomalyToRemove = f_Anomalies.currentAnom;
                f_Anomalies.RemoveAnomaly(anomalyToRemove);
                VNI.DebugUI.NewConsoleMessage("Anomaly currently occupied");
                InitComplete = false;
                f_Anomalies.currentAnomComplete = true;
                VNI.Wait(3);
                m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
            }
            else
            {

                VNI.DebugUI.NewConsoleMessage("Anomaly not occupied");
                orbitSomething();
                //f_Entities.saveGridEntities();
                InitComplete = false;
                //f_Anomalies.currentAnomComplete = true;
                
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
                //VNI.Eve.Execute(ExecuteCommand.CmdCloseAllWindows);
                CheckAnom();
            }

        }
    }
}
