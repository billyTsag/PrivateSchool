using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchool.Models
{
    public class TrainerEnrollment
    {
        [Key]
        [Column(Order =1)]
        public int TrainerID { get; set; }
        [Key]
        [Column(Order =2)]
        public int CourseID { get; set; }
        public string Subject { get; set; }

        public Trainer Trainer { get; set; }
        public Course Course { get; set; }

        public override string ToString()
        {
            return $"Trainer {TrainerID}: Course {CourseID}";
        }
    }
}
