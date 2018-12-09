using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            this.Lessons = new List<Lesson>();
            this.LessonStudentMeetings = new List<LessonStudentMeeting>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int AccountType { get; set; }

        public virtual List<Lesson> Lessons { get; set; }
        public virtual List<LessonStudentMeeting> LessonStudentMeetings { get; set; }
    }
}
