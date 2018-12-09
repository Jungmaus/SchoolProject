using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Model.VM.Lesson
{
    public class LessonVM
    {
        [MaxLength(40),Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int TeacherID { get; set; }

        [Required]
        public int FromID { get; set; }

        [MaxLength(40),Required]
        public string Subject { get; set; }

        [MaxLength(300),Required]
        public string Description { get; set; }

        [Required]
        public int Minitues { get; set; }
    }
}
