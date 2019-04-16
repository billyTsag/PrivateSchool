using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class HeadMasterManager
    {
        public static void CreateHeadMaster(string username, string password)
        {
            HeadMaster headMaster = new HeadMaster()
            {
                Username = username,
                Password = password                
            };
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                db.HeadMasters.Add(headMaster);
                db.SaveChanges();
            }
        }

        public static HeadMaster FindPassword(string username)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                var query = db.HeadMasters.Where(hm => hm.Username == username).FirstOrDefault<HeadMaster>();
                return query;
            }
        }
    }
}
