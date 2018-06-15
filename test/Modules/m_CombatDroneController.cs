using EVE.ISXEVE;
using VNI.Functions;
using VNI.Routines;
using VNI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LavishVMAPI;
using System.Diagnostics;

namespace VNI.Modules
{
    static class m_CombatDroneController
    {
        // Variables
        private static bool DronesLaunched = false;
        public static bool DronesEngaged = false;
        private static bool TargetLocked = false;

        private static Nullable<DateTime> lostAggroTime = null;
        private static bool lostAggro = false;
        private static bool RecallDrones = false;

        private static Entity Target;

        private static List<Attacker> CurrentAttackers = new List<Attacker>();


        static m_CombatDroneController()
        {
            // Init
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                List<Attacker> Attackers = VNI.Me.GetAttackers();
                List<ActiveDrone> activeDrones = VNI.Me.GetActiveDrones();

                int NumAttackers = Attackers.Count;
                if (VNI.Me.TargetingCount > 0)
                {
                    TargetLocked = true;
                }

                Entity PriorityRat = Attackers.Find(a => a.Name == ("Dire Pithum Mortifier"));
                if(!f_Entities.CheckIfExists(f_Targeting.FocusedRat))
                {
                    f_Targeting.FocusedRat = null;
                }
                if (f_Targeting.FocusedRat != null && f_Targeting.FocusedRat.IsActiveTarget && !f_Drones.CheckIfDronesAreOnTarget(f_Targeting.FocusedRat))
                {
                    VNI.DebugUI.NewConsoleMessage("Engaging: " + f_Targeting.FocusedRat.Name);
                        f_Drones.EngageTarget();
                }

                if (NumAttackers < f_Entities.getRats().Count && lostAggroTime == null)
                {
                    lostAggroTime = DateTime.Now;
                }
                if(lostAggroTime != null && !lostAggro && lostAggroTime.Value.AddSeconds(15) < DateTime.Now)
                {
                    lostAggro = true;
                    RecallDrones = true;
                }
                //Anomaly completed or we're between waves
                if (!f_Entities.checkForNPC())
                {
                    VNI.Wait(10);
                    //TODO - RAT PRIORTISING!
                    //
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Entities.checkForNPC())
                    {
                        VNI.Eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
                        VNI.DebugUI.NewConsoleMessage("Site ID: " + f_Anomalies.currentAnom.ID + " Completed moving to next anom");



                        m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;

                    }
                }
                // We're under attack!
                else if (f_Entities.checkForNPC())
                {
                    //VNI.DebugUI.updateDroneTargetLabel(f_Drones.checkDroneTarget());
                    List<Entity> targetedby = VNI.Me.GetTargetedBy();

                    //If drones are NOT launched and we are targeted by all rats, launch drones
                    if (!f_Drones.CheckIfDronesAreLaunched() && NumAttackers == f_Entities.getRats().Count)
                    {
                        VNI.MyShip.LaunchAllDrones();
                        VNI.Wait(3);
                        //System.Media.SystemSounds.Hand.Play();
                        VNI.DebugUI.NewConsoleMessage("NPCs spawned, we have aggro, Launching drones");
                        //f_Drones.EngageTarget();
                        DronesLaunched = true;
                        DronesEngaged = false;

                        lostAggro = false;
                        lostAggroTime = null;
                    }
                    //If drones are launched and we are not targeting any rats and drones are not engaged, lock a target
                    else if (f_Drones.CheckIfDronesAreLaunched() && f_Targeting.TargetCount() == 0 && !f_Drones.checkIfEngaged())
                    {
                        //Target = Attackers[0];
                        //Target.LockTarget();
                        VNI.DebugUI.NewConsoleMessage("Waiting for autotargeter to lock a target");
                        TargetLocked = true;
                    }
                    //If drones are launched, we are targeting atleast one rat and drones are NOT engaged, engage a target
                    else if (f_Drones.CheckIfDronesAreLaunched() && f_Targeting.TargetCount() > 0 && !f_Drones.checkIfEngaged() && !DronesEngaged)
                    {
                        //Target.MakeActiveTarget();
                        VNI.Wait(2);
                        DronesEngaged = true;

                        if (!f_Drones.checkIfEngaged())
                        {
                            VNI.DebugUI.NewConsoleMessage("Engaging a target");
                            f_Drones.EngageTarget();
                        }


                    }
                    if (f_Drones.CheckIfDronesAreLaunched() && NumAttackers < f_Entities.getRats().Count && RecallDrones == true)
                    {
                        VNI.DebugUI.NewConsoleMessage("Lost aggro recalling drones");
                        f_Drones.ReturnAllDronesToBay();
                        
                        RecallDrones = false;

                        
                    }
                    f_Targeting.GetWarpScramblingMe();
                    
                    if (f_Targeting.WarpScramblingMe.Count > 0)
                    {
                        
                        f_Targeting.FocusWarpScrambler();
                        f_Drones.EngageTarget();
                        VNI.DebugUI.NewConsoleMessage("Engaging warp scrambler");
                        
                    }
                }
            }
        }

        public static bool IsTargetLocked(Entity e)
        {
            List<Entity> LockedTargets = VNI.Me.GetTargets();
            foreach (Entity LockedTarget in LockedTargets)
            {
                if (LockedTarget.ID == Target.ID) return true;
            }
            return false;
        }
    }
}

