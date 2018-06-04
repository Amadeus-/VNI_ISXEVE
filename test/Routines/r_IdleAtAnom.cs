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
                    //m_ModuleManagement.Activation();
                    m_RoutineController.ActiveRoutine = Routine.Combat;
                }
            }
        }
        public static void orbitSomething()
        {
            //List<Entity> collidables = f_Entities.GetCollidables();
            //if(collidables != null)
            //{
              //collidables.First().Orbit(25000);
                //r_Combat.OrbitPoint = collidables.First();
           //}
                List<Entity> Rats = f_Entities.getRats();
                foreach(Entity r in Rats)
                {
                    VNI.DebugUI.NewConsoleMessage(r.Name);
                }
                Rats.First().Orbit(25000);
                //m_ModuleManagement.Activation();
                r_Combat.priorityRat = Rats.First();

            
           
        }
        public static void Pulse()
        {
            // Pulse
            
        }
    }
}
