using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Core.Entities.Common;

namespace UdemyApp.Core.Entities
{
    public class Course:BaseAudiTableEntity
    {
        public string Title {get; set;}
        public string Description {get; set;}
        public int? TeacherId { get; set;}   
        public List<StudentsCourses>? StudentsCourses {get; set;}

    }
}
