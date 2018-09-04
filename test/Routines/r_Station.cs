using VNI.Functions;
using VNI.Modules;
using VNI;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNI.Routines
{
    static class Constants
    {
        public const double MIN_WAIT_TIME = 20;
        public const double MAX_WAIT_TIME = 45;
    }
    static class r_Station
    {
        // Variables
        private static bool InitComplete = false;
        private static bool LeavingStation = false;

        private static DateTime ExitStationTime;
        private static DateTime ExitRoutineTime;
        private static bool ExitTimesSet;

        static r_Station()
        {
            if (!InitComplete)
            {

                InitComplete = true;
                ExitTimesSet = false;

            }
        }

        public static void Pulse()
        {
            if (!f_Social.isSafe())
            {

            }
            else if (f_Social.isSafe())
            {
                if (!ExitTimesSet)
                {
                    double ExitStationDelay = RandWaitTime(Constants.MIN_WAIT_TIME, Constants.MAX_WAIT_TIME);
                    ExitStationTime = DateTime.Now.AddSeconds(ExitStationDelay);
                    ExitRoutineTime = ExitStationTime.AddSeconds(12.0);
                    ExitTimesSet = true;
                }

                if (DateTime.Now > ExitRoutineTime && f_Social.isSafe())
                {
                    ExitTimesSet = false;
                    LeavingStation = false;
                    f_Anomalies.currentAnomComplete = true;
                    m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                }
                else if (DateTime.Now > ExitStationTime && !LeavingStation && f_Social.isSafe())
                {
                    LeavingStation = true;
                    f_EVECommands.ExitStation();
                }
            }

        }

        private static double RandWaitTime(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
