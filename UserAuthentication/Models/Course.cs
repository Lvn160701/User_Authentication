using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAuthentication.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [ForeignKey("CourseCategory")]
        public int CategoryID { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}