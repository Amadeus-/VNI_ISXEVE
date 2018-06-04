﻿using VNI.Functions;
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

        static r_Station()
        {
            if (!InitComplete)
            {
                InitComplete = true;
                RefreshOreHoldComplete = false;
                TransferComplete = false;

                RefreshOreHoldTime = DateTime.Now.AddSeconds(10.0);
                TransferOreHoldTime = DateTime.Now.AddSeconds(15.0);
                double ExitStationDelay = RandWaitTime(MinWaitTime, MaxWaitTime);
                ExitStationTime = DateTime.Now.AddSeconds(ExitStationDelay);
                ExitRoutineTime = ExitStationTime.AddSeconds(12.0);
                //VNI
               // V.NewConsoleMessage("Leaving " + Daedalus.Me.Station.Name.ToString() + " in " + ExitStationDelay.ToString("F0") + " seconds");
            }
        }

        public static void Pulse()
        {

        }

        private static double RandWaitTime(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}