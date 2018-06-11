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
    static class r_Station
    {
        // Variables
        private static bool InitComplete = false;
        private static bool LeavingStation = false;
        private static bool RefreshOreHoldComplete = false;
        private static bool TransferComplete = false;

        private static double MinWaitTime = 20;
        private static double MaxWaitTime = 45;
        private static DateTime RefreshOreHoldTime;
        private static DateTime TransferOreHoldTime;
        private static DateTime ExitStationTime;
        private static DateTime ExitRoutineTime;
        private static bool ExitTimesSet;

        static r_Station()
        {
            if (!InitComplete)
            {
                InitComplete = true;
                RefreshOreHoldComplete = false;
                TransferComplete = false;

                RefreshOreHoldTime = DateTime.Now.AddSeconds(10.0);
                TransferOreHoldTime = DateTime.Now.AddSeconds(15.0);

                ExitTimesSet = false;

                //VNI
                // V.NewConsoleMessage("Leaving " + Daedalus.Me.Station.Name.ToString() + " in " + ExitStationDelay.ToString("F0") + " seconds");
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
                    double ExitStationDelay = RandWaitTime(MinWaitTime, MaxWaitTime);
                    ExitStationTime = DateTime.Now.AddSeconds(ExitStationDelay);
                    ExitRoutineTime = ExitStationTime.AddSeconds(12.0);
                    ExitTimesSet = true;
                }
                if (DateTime.Now > ExitRoutineTime && f_Social.isSafe())
                {
                    ExitTimesSet = false;
                    f_Anomalies.currentAnomComplete = true;
                    m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                }
                else if (DateTime.Now > ExitStationTime && !LeavingStation && f_Social.isSafe())
                {
                    LeavingStation = true;
                    f_EVECommands.ExitStation();
                    //VNI.Wait(10);
                    //m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
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
