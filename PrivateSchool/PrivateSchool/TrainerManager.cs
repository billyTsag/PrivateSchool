using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateSchool.Models;

namespace PrivateSchool
{
    public static class TrainerManager
    {
        public static int CreateTrainer(string firstName, string lastName)
        {
            Trainer trainer = new Trainer()
            {
                FirstName = firstName,
                LastName = lastName
            };

            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                db.Trainers.Add(trainer);
                db.SaveChanges();
            }
            return trainer.ID;
        }

        public static List<Trainer> GetAllTrainers()
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                return db.Trainers.ToList();
            }
        }

        public static void DeleteTrainer(int id)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(id);
                if (trainer == null)
                {
                    return;
                }
                db.Trainers.Remove(trainer);
                db.SaveChanges();
            }
        }

        public static void UpdateTrainer(int id, string firstName, string lastName)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(id);
                if (trainer == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                trainer.FirstName = firstName;
                trainer.LastName = lastName;
                db.SaveChanges();
            }
        }

        public static void CreateAccount(int trainerID, string username, string password)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                Trainer trainer = db.Trainers.Find(trainerID);
                if (trainer == null)
                {
                    Console.WriteLine("Entity not found!\n");
                    return;
                }
                trainer.Username = username;
                trainer.Password = password;
                db.SaveChanges();
            }
        }        

        public static Trainer FindPassword(string username)
        {
            using (PrivateSchoolContext db = new PrivateSchoolContext())
            {
                var query = db.Trainers.Where(t => t.Username == username).FirstOrDefault<Trainer>();
                return query;
            }
        }
        
    }
}
