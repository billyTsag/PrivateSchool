using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<StudentEnrollement> StudentEnrollements { get; set; }
        public virtual ICollection<TrainerEnrollment> TrainerEnrollments { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }

        public override string ToString()
        {
            return $"Course {ID}: {Title} {Stream} {Type} Start Date: {StartDate.ToShortDateString()} End Date: {EndDate.ToShortDateString()}";
        }
    }
}
