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

        public static bool WarpScrambled = false;
        public static Attacker FocusedRat;
        
        static f_Targeting()
        {

        }

        public static void GetWarpScramblingMe()
        {
            attackers = VNI.Me.GetAttackers();
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
            FocusedRat = WarpScramblingMe.First();

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
                if (!FocusedRat.IsLockedTarget)
                {
                    FocusedRat.LockTarget();
                }
                if (FocusedRat.IsLockedTarget && !FocusedRat.IsActiveTarget)
                {
                    
                    FocusedRat.MakeActiveTarget();
                    VNI.DebugUI.NewConsoleMessage(FocusedRat.IsLockedTarget.ToString() + FocusedRat.IsActiveTarget.ToString() + "Focusing: " + FocusedRat.Name);
                }

            }

        }
        public static void FocusWarpScrambler()
        {
            
            if(WarpScramblingMe.Count > 0)
            {
                FocusedRat = WarpScramblingMe.First();
                if (!FocusedRat.IsLockedTarget)
                {
                    FocusedRat.LockTarget();
                }
                if(FocusedRat.IsLockedTarget && !FocusedRat.IsActiveTarget)
                {
                    FocusedRat.MakeActiveTarget();
                    VNI.DebugUI.NewConsoleMessage(FocusedRat.IsLockedTarget.ToString() + FocusedRat.IsActiveTarget.ToString() + "Focusing: " + FocusedRat.Name);
                }
   
            }
            
        }
        public static int TargetCount()
        {
            return VNI.Me.TargetCount;
        }
    }

}
