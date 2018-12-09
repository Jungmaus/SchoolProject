using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Lesson : BaseEntity
    {
        public Lesson()
        {
            this.LessonStudentMeetings = new List<LessonStudentMeeting>();
            this.LessonTeacherPosts = new List<LessonTeacherPost>();
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }

        public int TeacherID { get; set; }
        public int LessonDetailID { get; set; }

        [ForeignKey("TeacherID")]
        public User Teacher { get; set; }

        [ForeignKey("LessonDetailID")]
        public virtual LessonDetail LessonDetail { get; set; }

        public virtual List<LessonStudentMeeting> LessonStudentMeetings { get; set; }
        public virtual List<LessonTeacherPost> LessonTeacherPosts { get; set; }
    }
}
