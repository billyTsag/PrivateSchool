using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public virtual ICollection<TrainerEnrollment> TrainerEnrollments { get; set; }

        public override string ToString()
        {
            return $"Trainer {ID}: {FirstName} {LastName}";
        }
    }
}
