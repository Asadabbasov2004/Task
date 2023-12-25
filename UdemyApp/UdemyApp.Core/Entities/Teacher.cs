using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities.Common;

namespace UdemyApp.Core.Entities
{
    public class Teacher:BaseAudiTableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
