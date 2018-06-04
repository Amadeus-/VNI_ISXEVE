
using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace VNI.Functions
{
    public static class f_Entities
    {
        static f_Entities()
        {
            // Init
        }

        public static string GetEntityMode(Entity e)
        {
            int Mode = e.Mode;
            if (Mode == 0) /* Aligned */
            {
                return "Aligned";
            }
            else if (Mode == 1) /* Approaching */
            {
                return "Approaching";
            }
            else if (Mode == 2) /* Stopped */
            {
                return "Stopped";
            }
            else if (Mode == 3) /* Warping (In Warp) */
            {
                return "Warping";
            }
            else if (Mode == 4) /* Orbiting */
            {
                return "Orbiting";
            }
            else if (Mode == 5)
            {
                return "AFKVNI";
            }
            else
            {
                return "NULL";
            }
        }

        public static List<Entity> GetStations()
        {
            return VNI.Eve.QueryEntities("GroupID = 15");
        }
        public static List<Entity> GetCollidables()
        {
            List<Entity> collidables = new List<Entity>();
            //Modify categories
            List<Entity> Entities = VNI.Eve.QueryEntities("CategoryID = 25");
            foreach (Entity e in Entities)
            {
                collidables.Add(e);
            }
            return collidables;
        }
        public static List<Pilot> getLocalPilots()
        {
            return VNI.Eve.GetLocalPilots();
        }
        public static List<SystemAnomaly> getAnomalies()
        {
            return VNI.MyShip.Scanners.System.GetAnomalies();
        }
        /*public static List<Entity> playerCheck()
        {
            List<Entity> Entities = Daedalus.Eve.QueryEntities("CategoryID = 25");
            foreach (Entity e in Entities)
            {
                Asteroids.Add(e);
            }
            return Asteroids;
        }*/
        public static double DistanceFromPlayerToEntity(Entity e)
        {
            return VNI.Eve.DistanceBetween(VNI.Me.ToEntity.ID, e.ID);
        }
        public static double DistanceFromPlayerToAnom(SystemAnomaly e)
        {
            return VNI.Eve.DistanceBetween(VNI.Me.ToEntity.ID, e.ID);
        }

        public static double DistanceBetween(Entity e1, Entity e2)
        {
            return VNI.Eve.DistanceBetween(e1.ID, e2.ID);
        }
        public static bool checkForNPC()
        {
            bool npc = false;
            List<Entity> queryEntities = VNI.Eve.QueryEntities();
            foreach (Entity e in queryEntities)
            {
                if (e.CategoryID == 11)
                {
                    npc = true;
                }
            }
            return npc;
        }
        public static List<Entity> getRats()
        {
            List<Entity> queryEntities = VNI.Eve.QueryEntities();
            List<Entity> rats = new List<Entity>();
            foreach (Entity e in queryEntities)
            {
                if (e.CategoryID == 11)
                {
                    rats.Add(e);
                }
            }
            return rats;
        }
    }

}


