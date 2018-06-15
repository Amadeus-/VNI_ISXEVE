using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    static class f_Window
    {
        static f_Window()
        {
            //init
        }
        public static List<EVEWindow> GetActiveWindows()
        {
            
            return VNI.Eve.GetEveWindows();

        }
    }
}
