using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Models
{
    public class StudentAssignments
    {
        [Key]
        [Column(Order = 1)]
        public int StudentID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AssignmentID { get; set; }

        public Student Student { get; set; }
        public Assignment Assignment { get; set; }

        public int OralMark { get; set; }
        public int TotalMark { get; set; }
        public bool IsSubmitted { get; set; }

        public override string ToString()
        {
            return $"Student {StudentID} : Assignment {AssignmentID}, Submitted: {IsSubmitted}";
        }
    }
}
