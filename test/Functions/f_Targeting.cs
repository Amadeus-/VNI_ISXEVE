using System;
using EVE.ISXEVE;
using VNI.Functions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_Targeting
    {
        public static List<Attacker> attackers = new List<Attacker>();
        public static List<Attacker> WarpScramblingMe = new List<Attacker>();
        public static List<Attacker> priorityRats = new List<Attacker>();
        //bool focusedRatEngaged = false;

        public static bool WarpScrambled = false;
        public static Attacker FocusedRat;
        
        static f_Targeting()
        {

        }

        public static void GetWarpScramblingMe()
        {
            attackers = VNI.Me.GetAttackers();
            WarpScramblingMe.Clear();
            foreach(Attacker a in attackers)
            {
                if (a.IsWarpScramblingMe && !WarpScramblingMe.Contains(a))
                {
                    WarpScramblingMe.Add(a);
                    WarpScrambled = true;
                }
            }
            foreach(Attacker a in WarpScramblingMe)
            {
                VNI.DebugUI.NewConsoleMessage(a.Name + "Is Warp Scrambling me");
            }
            if(WarpScramblingMe.Count > 0)
            {
                FocusedRat = WarpScramblingMe.First();
            }
            

        }
        public static void GetPriorityRats()
        {
            attackers = VNI.Me.GetAttackers();
            foreach(Attacker a in attackers)
            {
                if(a.Name == "Dire Pithum Mortifier")
                {
                    priorityRats.Add(a);
                }
            }
            
        }
        public static void FocusPriorityRats()
        {

            if (priorityRats.Count > 0)
            {
                FocusedRat = priorityRats.First();
                if (!priorityRats.First().IsLockedTarget)
                {
                    FocusedRat.LockTarget();
                }
                if (priorityRats.First().IsLockedTarget && !priorityRats.First().IsActiveTarget)
                {
                    
                    FocusedRat.MakeActiveTarget();
                    VNI.DebugUI.NewConsoleMessage(FocusedRat.IsLockedTarget.ToString() + FocusedRat.IsActiveTarget.ToString() + "Focusing: " + FocusedRat.Name);
                }

            }

        }
        public static void FocusWarpScrambler()
        {
            foreach(Entity f in WarpScramblingMe)
            {
                //
            }
            if(WarpScramblingMe.Count > 0)
            {
                FocusedRat = WarpScramblingMe.First();
                if (!WarpScramblingMe.First().IsLockedTarget)
                {
                    WarpScramblingMe.First().LockTarget();
                }
                if(WarpScramblingMe.First().IsLockedTarget)
                {
                    WarpScramblingMe.First().MakeActiveTarget();
                    VNI.DebugUI.NewConsoleMessage(WarpScramblingMe.First().IsLockedTarget.ToString() + WarpScramblingMe.First().IsActiveTarget.ToString() + "Focusing: " + WarpScramblingMe.First().Name);
                    
                }
   
            }
            
        }
        public static int TargetCount()
        {
            return VNI.Me.TargetCount;
        }
    }

}
