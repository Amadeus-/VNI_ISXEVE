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
        private static bool DronesEngaged = false;
        private static bool TargetLocked = false;

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

                // We're safe!
                if (!f_Entities.checkForNPC())
                {
                    VNI.Wait(10);
                    //TODO - RAT PRIORTISING!
                    //if(Attackers.Contains(Dire Pithum Moritifier))
                    if (DronesLaunched && !f_Entities.checkForNPC())
                    {
                        VNI.Eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
                        VNI.DebugUI.NewConsoleMessage("Site ID: " + f_Anomalies.currentAnom.ID + " Completed moving to next anom");
                        DronesLaunched = false;
                        TargetLocked = false;
                        DronesEngaged = false;
                        m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                    }
                }
                // We're under attack!
                else if (f_Entities.checkForNPC())
                {
                    VNI.Wait(2);
                    List<Entity> targetedby = VNI.Me.GetTargetedBy();
                    if (!f_Drones.CheckIfDronesAreLaunched() && targetedby.Count == f_Entities.getRats().Count)
                    {
                        VNI.MyShip.LaunchAllDrones();
                        VNI.Wait(2);
                        //System.Media.SystemSounds.Hand.Play();
                        VNI.DebugUI.NewConsoleMessage("NPCs spawned, we have aggro, Launching drones");
                        DronesLaunched = true;
                    }
                    
                    else if (DronesLaunched && !TargetLocked && f_Drones.checkIfEngaged())
                    {
                        Target = Attackers[0];
                        Target.LockTarget();
                        TargetLocked = true;
                    }
                    
                    else if (DronesLaunched && TargetLocked && f_Drones.checkIfEngaged() && IsTargetLocked(Target))
                    {
                        Target.MakeActiveTarget();
                        VNI.Wait(2);
                        VNI.DebugUI.NewConsoleMessage("rengaging");
                        f_Drones.EngageTarget();
                        DronesEngaged = true;
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

