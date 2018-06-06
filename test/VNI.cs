using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LavishScriptAPI;
using LavishVMAPI;
using System.IO;

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

        // Pulse Variables
        private static DateTime NextPulse;
        private static int PulseRate = 1;

        // Misc Variables
        public static bool Paused = false;
        public static bool refreshCompleted = false;
        public static Form1 DebugUI;

        public VNI(Form1 Arg)
        {
            DebugUI = Arg;
            // One time only constructor.
            Frame += new EventHandler<LSEventArgs>(Pulse);
            DebugUI.NewConsoleMessage("Daedalus 06/06/2016");
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
            //Paused = true;
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
                    NextPulse = DateTime.Now.AddSeconds(PulseRate);
                    Eve = new EVE.ISXEVE.EVE();
                    Me = new EVE.ISXEVE.Me();
                    MyShip = new EVE.ISXEVE.Ship();
                    if (!refreshCompleted)
                    {
                        VNI.Eve.RefreshStandings();
                        refreshCompleted = true;
                        Wait(30);
                    }

                    
                    DebugUI.Text = "Daedalus - " + Me.Name + " " + m_RoutineController.ActiveRoutine;

                    
                   if (!f_Social.isSafe()) m_RoutineController.ActiveRoutine = Routine.Flee;

                    f_Entities.PrintLocal();
                    
                   
                    
                   if (!Paused) b_Ratting.Pulse();
                }
                return;
            }
        }
    }
}

