using VNI.Routines;
using VNI.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Modules
{
    public static class m_RoutineController
    {
        public static Routine PreviousRoutine;

        static m_RoutineController()
        {
            f_Entities.CheckForNPC();
        }

        public static void Pulse()
        {
            if (ActiveRoutine == Routine.Station) r_Station.Pulse();
            else if (ActiveRoutine == Routine.IdleAtAnom) r_IdleAtAnom.Pulse();
            else if (ActiveRoutine == Routine.TravelToAnomaly) r_TravelToAnomaly.Pulse();
            else if (ActiveRoutine == Routine.Combat) r_Combat.Pulse();
            else if (ActiveRoutine == Routine.Flee) r_Flee.Pulse();
            return;
        }

        public static Routine ActiveRoutine;
    }

    public enum Routine { Idle, Station, ReturnToStation, IdleAtAnom, TravelToAnomaly, Combat, Flee};
}
