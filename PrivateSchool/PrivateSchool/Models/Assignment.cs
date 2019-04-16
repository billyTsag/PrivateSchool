using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Submission { get; set; }
       
        public virtual Course Course { get; set; }
        public virtual ICollection<StudentAssignments> StudentAssignments { get; set; }

        public override string ToString()
        {
            return $"Assignment {ID}: {Title} Due Date: {Submission.ToShortDateString()}";
        }
    }
}
