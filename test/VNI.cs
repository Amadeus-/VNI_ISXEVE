﻿using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LavishScriptAPI;
using LavishVMAPI;
using System.IO;

/*
 ToDO: Improve code cleanliness of flee class
 */

namespace VNI
{
    using Behaviours;
    using Functions;
    using Modules;
    public class VNI
    {

        // EventHandler for Pulse
        private static event EventHandler<LSEventArgs> Frame;

        // ISXEVE Variables
        public static EVE.ISXEVE.EVE Eve;
        public static EVE.ISXEVE.Me Me;
        public static EVE.ISXEVE.Pilot Pilot;
        public static EVE.ISXEVE.Ship MyShip;
        public static EVE.ISXEVE.Station Station;
        public static EVE.ISXEVE.SystemScanner systemScanner;
        public static EVE.ISXEVE.SystemAnomaly systemAnomaly;

        public static string version = "0.0.5";
        // Pulse Variables
        private static DateTime NextPulse;
        private static DateTime LastPulse;
        private static int PulseRate = 1;

        // Misc Variables
        public static bool Paused = false;
        public static bool refreshCompleted = false;
        public static Form1 DebugUI;
        public static Random rnd = new Random();

        private static DateTime StartTime;
        private static DateTime EndTime;
        public static bool InCapsule = false;

        public VNI(Form1 Arg)
        {
            DebugUI = Arg;
            // One time only constructor.
            Frame += new EventHandler<LSEventArgs>(Pulse);
            DebugUI.NewConsoleMessage("VNI 08/06/2018");
            System.Media.SystemSounds.Asterisk.Play();
            Start();

        }

        public static void Start()
        {
            AttachEvent();
            NextPulse = DateTime.Now.AddSeconds(PulseRate);
        }
        public static void Wait(int pauseTime)
        {
            DateTime ContinueAt = DateTime.Now.AddSeconds((Double)pauseTime);
            NextPulse = ContinueAt;
        }
        static internal void AttachEvent()
        {
            LavishScript.Events.AttachEventTarget("ISXEVE_OnFrame", Frame);
            DebugUI.NewConsoleMessage("Attaching to ISXEVE");
        }

        static internal void AttachEvent(object sender, EventArgs e)
        {
            AttachEvent();
        }

        static internal void DetachEvent()
        {
            LavishScript.Events.DetachEventTarget("ISXEVE_OnFrame", Frame);
        }

        private static void Pulse(object sender, LSEventArgs e)
        {
            using (new FrameLock(true))
            {


                if (DateTime.Now > NextPulse)
                {
                    DebugUI.Text = "VNI - " + Me.Name + " " + m_RoutineController.ActiveRoutine + " " + version + " " + VNI.Me.ToEntity.Type ;
                    NextPulse = DateTime.Now.AddSeconds(PulseRate);
                    Eve = new EVE.ISXEVE.EVE();
                    Me = new EVE.ISXEVE.Me();
                    MyShip = new EVE.ISXEVE.Ship();
                    
                    if (!refreshCompleted)
                    {
                        VNI.Eve.RefreshStandings();
                        refreshCompleted = true;
                        StartTime = DateTime.Now;
                        EndTime = StartTime.AddHours(6);
                        VNI.DebugUI.updateStartAndEnd(StartTime,EndTime);
                        if (!VNI.Eve.Is3DDisplayOn)
                        {
                            VNI.Eve.Toggle3DDisplay();
                        }
                        if (!VNI.Eve.IsTextureLoadingOn)
                        {
                            VNI.Eve.ToggleTextureLoading();
                        }
                        if (!VNI.Eve.IsUIDisplayOn)
                        {
                            VNI.Eve.ToggleUIDisplay();
                        }
                        

                    }

                    if(DateTime.Now > EndTime)
                    {
                        f_Anomalies.lastAnomaly = true;
                    }

                   

                    if(VNI.Me.ToEntity.Type == "Capsule")
                    {
                        VNI.DebugUI.NewConsoleMessage("No ship, staying docked!");
                        InCapsule = true;
                    }
                    if (VNI.Me.InSpace)
                    {

                        List<IItem> drones = VNI.MyShip.GetDrones();
                        List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();

                        DebugUI.updateShieldPctLabel((int)f_Ship.shieldPct());
                    }

                    if (!f_Social.isSafe())
                    {
                        m_RoutineController.ActiveRoutine = Routine.Flee;
                    }
                    
                    if (f_Ship.shieldPct() < 30)
                    {
                        m_RoutineController.ActiveRoutine = Routine.Flee;
                    }


                    if (!Paused)
                    {
                        b_Ratting.Pulse();
                        DebugUI.updateTimeAndDateLabel(NextPulse);
                    }

                }
                return;
            }
        }
    }
}

