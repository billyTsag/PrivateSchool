using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<StudentEnrollement> StudentEnrollements { get; set; }
        public virtual ICollection<StudentAssignments> StudentAssignments { get; set; }

        public override string ToString()
        {
            return $"Student {ID}: {FirstName} {LastName} DOB: {DateOfBirth.ToShortDateString()}";
        }
    }
}
