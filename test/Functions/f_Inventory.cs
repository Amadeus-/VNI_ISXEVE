using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNI.Functions
{
    class f_Inventory
    {
        static f_Inventory()
        {
            // Init
        }

        public static string GetDronesGroup()
        {
            List<IItem> Drones = VNI.MyShip.GetDrones();
            
            if (Drones.Count == 0)
            {
                List<ActiveDrone> ActiveDrones = VNI.Me.GetActiveDrones();
                return ActiveDrones[0].ToEntity.Group.ToString();
            }
            else
            {
                return Drones[0].Group.ToString();
            }
        }
    }
}
