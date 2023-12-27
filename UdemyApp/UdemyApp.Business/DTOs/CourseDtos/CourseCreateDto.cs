using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyApp.Business.DTOs.CourseDtos
{
    public class StudentCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }

    }
}
