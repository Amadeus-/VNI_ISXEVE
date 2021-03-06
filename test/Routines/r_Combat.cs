﻿using EVE.ISXEVE;
using VNI.Functions;
using VNI.Modules;
using VNI.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LavishVMAPI;

namespace VNI.Routines
{
    static class r_Combat
    {
        // Variables
        public static List<Entity> rats = new List<Entity>();
        public static Entity OrbitPoint;
        
        public static bool initComplete = false;

        static r_Combat()
        {
            VNI.DebugUI.NewConsoleMessage("In Combat, Launching Drones!");
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                m_ModuleManagement.activateAllModules();

                List<Attacker> Attackers = VNI.Me.GetAttackers();
                List<ActiveDrone> ActiveDrones = VNI.Me.GetActiveDrones();
                rats = f_Entities.GetRats();

                VNI.Wait(1);

                r_TravelToAnomaly.initComplete = false;

                if (!f_Entities.CheckForNPC())
                {
                    VNI.Wait(10);
                    //TODO - RAT PRIORTISING!

                    //If drones are launched and there are no NPCs return drones and go to next anomaly
                    if (f_Drones.CheckIfDronesAreLaunched() && !f_Entities.CheckForNPC())
                    {
                        VNI.Eve.Execute(ExecuteCommand.CmdDronesReturnToBay);

                        VNI.DebugUI.NewConsoleMessage("Site ID: " + f_Anomalies.currentAnom.ID + " Completed moving to next anom");

                        f_Anomalies.bannedAnoms.Add(f_Anomalies.currentAnom);

                        VNI.Wait(20);

                        m_CombatDroneController.DronesEngaged = false;
                        f_Anomalies.currentAnomComplete = true;

                        if(f_Anomalies.lastAnomaly)
                        {
                            
                            m_RoutineController.ActiveRoutine = Routine.Idle;
                            r_Flee.Citadels.First().WarpTo();
                        }
                        else m_RoutineController.ActiveRoutine = Routine.TravelToAnomaly;
                    }
                }
                if (rats.Count > 0 && VNI.Me.TargetedByCount == rats.Count ) m_CombatDroneController.Pulse();
                
                



            }
        }
        public static void OrbitCheck()
        {
            if (f_Entities.DistanceFromPlayerToEntity(OrbitPoint) > 30000)
            {
                r_IdleAtAnom.orbitSomething();
            }
        }

    }
}
