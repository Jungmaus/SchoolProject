using SchoolProject.Business.Services.EntityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Business.Services
{
    public class ServiceProvider : IDisposable
    {

        private LessonDetailService _lessonDetailService;
        private LessonService _lessonService;
        private LessonStudentMeetingService _lessonStudentMeetingService;
        private LessonTeacherPostService _lessonTeacherPostService;
        private UserService _userService;

        public LessonDetailService LessonDetail { get { return _lessonDetailService ?? new LessonDetailService(); } }
        public LessonService Lesson { get { return _lessonService ?? new LessonService(); } }
        public LessonStudentMeetingService LessonStudentMeeting { get { return _lessonStudentMeetingService ?? new LessonStudentMeetingService(); } }
        public LessonTeacherPostService LessonTeacherPost { get { return _lessonTeacherPostService ?? new LessonTeacherPostService(); } }
        public UserService User { get { return _userService ?? new UserService(); } }

        public void Dispose()
        {
            this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
