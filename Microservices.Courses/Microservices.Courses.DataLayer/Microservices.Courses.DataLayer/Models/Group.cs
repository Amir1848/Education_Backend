using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Courses.DataLayer.Models
{
    public class Group
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
        [MaxLength(1500)]
        public string Description { get; set; }

        #region Relations
        public virtual ICollection<Group> Courses { get; set; }
        #endregion
    }
}
