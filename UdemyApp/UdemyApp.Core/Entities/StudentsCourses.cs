using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities.Common;

namespace UdemyApp.Core.Entities
{
    public class StudentsCourses:BaseAudiTableEntity
    {
        public int? StudentId { get; set; }
        public Student student { get; set; }
        public int? CourseId { get; set; }
        public Course course { get; set; }
    }
}
