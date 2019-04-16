using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchool.Models
{
    public class StudentEnrollement
    {
        [Key]
        [Column(Order=1)]
        public int StudentID { get; set; }
        [Key]
        [Column(Order=2)]
        public int CourseID { get; set; }

        public int TuitionFees { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

        public override string ToString()
        {
            return $"Student {StudentID} : Course {CourseID}, Tuition Fees: {TuitionFees}";
        }
    }
}
