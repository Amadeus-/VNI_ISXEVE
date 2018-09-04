using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_Ship
    {
        static f_Ship()
        {

        }
        public static double shieldPct()
        {
            return VNI.MyShip.ShieldPct;
        }
        public static double XPos()
        {
            return VNI.Me.ToEntity.X;
        }
        public static double YPos()
        {
            return VNI.Me.ToEntity.Y;
        }
        public static double ZPos()
        {
            return VNI.Me.ToEntity.Z;
        }
        public static bool CheckIfCapsule()
        {
            if (VNI.Me.ToEntity.Type == "Capsule")
            {
                VNI.DebugUI.NewConsoleMessage("No ship, staying docked!");
                return true;
            }
            return false;
        }
    }
}
