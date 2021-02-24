using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.DataLayer.Models
{
    public class TeacherCourse
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        public long CourseId { get; set; }

        [Required]
        public Course Course { get; set; }
    }
}
