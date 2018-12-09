using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Model.VM.Lesson
{
    public class AddPostVM
    {
        [MaxLength(40),Required]
        public string Title { get; set; }

        [MaxLength(300),Required]
        public string Description { get; set; }

        public DateTime AddDate { get; set; }

        [Required]
        public int LessonID { get; set; }

        [Required]
        public int FromID { get; set; }
    }
}
