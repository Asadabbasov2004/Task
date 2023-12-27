using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.BaseDtos;

namespace UdemyApp.Business.DTOs.CourseDtos
{
    public class StudentGetDto:BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
    }
}
