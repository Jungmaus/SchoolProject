using SchoolProject.Data.Entities;
using SchoolProject.Model.Types.Enum;
using SchoolProject.Model.VM.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Business.OperationLibrary
{
    public class ReportOperation : BaseOperation
    {
        public List<LessonMeetingVM> GetLessonMeetingReport(int lessonID)
        {
            Lesson lesson = Services.Lesson.FirstOrDefault(x => x.ID == lessonID);
            if (lesson != null)
            {
                return Services.LessonStudentMeeting.GetAllWithQuery(x => x.LessonID == lesson.ID).Select(x => new LessonMeetingVM { Name = x.Student.Name, Surname = x.Student.Surname }).OrderBy(x => x.Name).ToList();
            }
            else
                return new List<LessonMeetingVM>();
        }

        public List<SharePostVM> GetTeachersSharePostReport(int teacherID)
        {
            User user = Services.User.FirstOrDefault(x => x.ID == teacherID && x.AccountType == (int)EnumUserType.Teacher);
            if (user != null)
            {
                return Services.LessonTeacherPost.GetAllWithQuery(x => x.Lesson.TeacherID == user.ID).Select(x => new SharePostVM { AddDate = x.AddDate, Description = x.Description, Title = x.Title }).ToList();
            }
            else
                return new List<SharePostVM>();
        }
    }
}
