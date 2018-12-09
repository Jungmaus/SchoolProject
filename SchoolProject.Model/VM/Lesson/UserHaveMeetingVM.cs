using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Model.VM.Lesson
{
    public class UserHaveMeetingVM
    {
        [Required]
        public int LessonID { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
