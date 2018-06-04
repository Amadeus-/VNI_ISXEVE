using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    public static class f_Bookmarks
    {
        public static List<BookMark> SafeSpots = new List<BookMark>();

        public static void GetSafeSpots()
        {
            
            List<BookMark> AllBookMarks = VNI.Eve.GetBookmarks();
            foreach (BookMark Bkmk in AllBookMarks)
            {
                if (Bkmk.Label.ToLower().Contains("safe") && Bkmk.SolarSystemID == VNI.Me.SolarSystemID)
                {
                    SafeSpots.Add(Bkmk);

                }
            }
            VNI.DebugUI.NewConsoleMessage(SafeSpots.First().Label);
        }
    }
}
