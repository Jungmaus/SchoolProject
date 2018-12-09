using SchoolProject.Data.Entities;
using SchoolProject.Model.Types.Enum;
using SchoolProject.Model.VM.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Business.OperationLibrary
{
    public class LessonOperation : BaseOperation
    {
        public Lesson AddLesson(LessonVM model)
        {
            User teacher = Services.User.FirstOrDefault(x => x.ID == model.TeacherID && x.AccountType == (int)EnumUserType.Teacher);
            User admin = Services.User.FirstOrDefault(x => x.ID == model.FromID && x.AccountType == (int)EnumUserType.Admin);
            if (teacher != null && admin != null)
            {
                LessonDetail detail = Services.LessonDetail.Insert(new LessonDetail { Description = model.Description, Minitues = model.Minitues, Subject = model.Subject });

                Lesson _model = new Lesson();
                _model.Name = model.Name;
                _model.StartDate = model.StartDate;
                _model.TeacherID = model.TeacherID;
                _model.LessonDetailID = detail.ID;
                return Services.Lesson.Insert(_model);
            }
            else
                return new Lesson();
        }

        public List<Lesson> GetLessons() => Services.Lesson.GetAll();

        public LessonVM GetLessonwDetail(int lessonID)
        {
            Lesson model = Services.Lesson.FirstOrDefault(x => x.ID == lessonID);
            if (model != null)
            {
                LessonDetail detail = model.LessonDetail;
                LessonVM _model = new LessonVM();
                _model.Description = detail.Description;
                _model.Minitues = detail.Minitues;
                _model.Subject = detail.Subject;
                _model.Name = model.Name;
                _model.StartDate = model.StartDate;
                _model.TeacherID = model.TeacherID;
                return _model;
            }
            else
                return new LessonVM();
        }

        public List<AddPostVM> GetLessonsPosts(int lessonID)
        {
            Lesson lesson = Services.Lesson.FirstOrDefault(x => x.ID == lessonID);
            if (lesson != null)
            {
                return Services.LessonTeacherPost.GetAllWithQuery(x => x.LessonID == lesson.ID).Select(x => new AddPostVM
                {
                    AddDate = x.AddDate,
                    Description = x.Description,
                    Title = x.Title
                }).OrderByDescending(x => x.AddDate).ToList();
            }
            else
                return new List<AddPostVM>();
        }

        public int UserHaveMeeting(UserHaveMeetingVM model)
        {
            if (Services.LessonStudentMeeting.FirstOrDefault(x => x.LessonID == model.LessonID && x.StudentID == model.UserID) != null)
                return 1;
            else
                return 0;
        }

        public int AddMeeting(AddMeetingVM model)
        {
            User fromUser = Services.User.FirstOrDefault(x => x.ID == model.FromID && x.AccountType == (int)EnumUserType.Student);
            Lesson lesson = Services.Lesson.FirstOrDefault(x => x.ID == model.LessonID);
            if (fromUser != null && lesson != null)
            {
                LessonStudentMeeting meeting = Services.LessonStudentMeeting.FirstOrDefault(x => x.StudentID == fromUser.ID && x.LessonID == lesson.ID);

                if(meeting == null)
                    Services.LessonStudentMeeting.Insert(new LessonStudentMeeting { LessonID = lesson.ID, StudentID = fromUser.ID });
                return 1;
            }
            else
                return 0;
        }

        public int AddPost(AddPostVM model)
        {
            User fromUser = Services.User.FirstOrDefault(x => x.ID == model.FromID && x.AccountType == (int)EnumUserType.Teacher);
            Lesson lesson = Services.Lesson.FirstOrDefault(x => x.ID == model.LessonID);
            if (fromUser != null && lesson != null)
            {
                LessonTeacherPost _model = new LessonTeacherPost();
                _model.AddDate = DateTime.Now;
                _model.Description = model.Description;
                _model.LessonID = model.LessonID;
                _model.Title = model.Title;
                Services.LessonTeacherPost.Insert(_model);
                return 1;
            }
            else
                return 0;
        }
    }
}
