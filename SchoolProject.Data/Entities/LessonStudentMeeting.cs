using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class LessonStudentMeeting : BaseEntity
    {
        public int LessonID { get; set; }
        public int StudentID { get; set; }

        [ForeignKey("LessonID")]
        public virtual Lesson Lesson { get; set; }

        [ForeignKey("StudentID")]
        public virtual User Student { get; set; }
    }
}
