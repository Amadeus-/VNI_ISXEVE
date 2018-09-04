using EVE.ISXEVE;
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
    static class Constants
    {
        public const string VERSION = "0.0.5";
    }
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

        
        // Pulse Variables
        private static DateTime NextPulse;
        private static DateTime LastPulse;
        private static int PulseRate = 1;

        // Misc Variables
        public static bool Paused = false;
        public static bool refreshCompleted = false;

        public static UI DebugUI;
        public static Random rnd = new Random();

        private static DateTime StartTime;
        private static DateTime EndTime;

        public static bool InCapsule = false;

        public VNI(UI Arg)
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
        static void Initialise()
        {
            f_Entities.RefreshStandings();
            StartTime = DateTime.Now;
            EndTime = StartTime.AddHours(6);
            VNI.DebugUI.updateStartAndEnd(StartTime, EndTime);
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
        private static void Pulse(object sender, LSEventArgs e)
        {
            using (new FrameLock(true))
            {
                if (DateTime.Now > NextPulse)
                {

                    DebugUI.Text = "VNI - " + Me.Name + " " + m_RoutineController.ActiveRoutine + " " + Constants.VERSION + " " + VNI.Me.ToEntity.Type ;

                    NextPulse = DateTime.Now.AddSeconds(PulseRate);
                    Eve = new EVE.ISXEVE.EVE();
                    Me = new EVE.ISXEVE.Me();
                    MyShip = new EVE.ISXEVE.Ship();

                    //Update standings
                    if (!refreshCompleted)
                    {
                        refreshCompleted = true;
                        Initialise();
                    }

                    if(DateTime.Now > EndTime)
                    {
                        f_Anomalies.lastAnomaly = true;
                    }

                   

                    if(f_Ship.CheckIfCapsule())
                    {
                        VNI.DebugUI.NewConsoleMessage("No ship, staying docked!");
                        InCapsule = true;
                    }
                    //Update shield Percentage label every pulse
                    if (VNI.Me.InSpace)
                    {
                        DebugUI.updateShieldPctLabel((int)f_Ship.shieldPct());
                    }

                    //Check if local is clear every pulse
                    if (!f_Social.isSafe())
                    {
                        m_RoutineController.ActiveRoutine = Routine.Flee;
                    }
                    //If shield pct is low flee station
                    if (f_Ship.shieldPct() < 30)
                    {
                        m_RoutineController.ActiveRoutine = Routine.Flee;
                    }

                    //If bot is not paused begin ratting
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

