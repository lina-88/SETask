using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspPractise.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
