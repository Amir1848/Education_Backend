using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.DataLayer.Models
{
    public class Course
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public long GroupId { get; set; }


        #region Relations
        public virtual ICollection<StudentCourse> Students { get; set; }
        public virtual ICollection<TeacherCourse> Teachers { get; set; }
        [Required]
        public virtual Group Group { get; set; }
        #endregion
    }
}
