using SchoolProject.Business.OperationLibrary;
using SchoolProject.Data.Entities;
using SchoolProject.Model.VM;
using SchoolProject.Model.VM.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolProject.API.Controllers
{
    public class LessonController : BaseController
    {
        private LessonOperation lessonOperation;

        public LessonController()
        {
            this.lessonOperation = new LessonOperation();
        }

        [Route("api/lesson/addlesson")]
        public Lesson AddLesson(LessonVM model)
        {
            if (ModelState.IsValid)
                return lessonOperation.AddLesson(model);
            else
                return new Lesson();
        }

        [Route("api/lesson/getlessons")]
        public List<Lesson> GetLessons() => lessonOperation.GetLessons();

        [Route("api/lesson/getlessonsdetail")]
        public LessonVM GetLessonsDetail(int lessonID) => lessonOperation.GetLessonwDetail(lessonID);

        [Route("api/lesson/getlessonsposts")]
        public List<AddPostVM> GetLessonsPosts(int lessonID) => lessonOperation.GetLessonsPosts(lessonID);

        [Route("api/lesson/userhavemeeting")]
        public int UserHaveMeeting(UserHaveMeetingVM model)
        {
            if (ModelState.IsValid)
                return lessonOperation.UserHaveMeeting(model);
            else
                return 0;
        }

        [Route("api/lesson/addmeeting")]
        public int AddMeeting(AddMeetingVM model)
        {
            if (ModelState.IsValid)
                return lessonOperation.AddMeeting(model);
            else
                return 0;
        }

        [Route("api/lesson/addpost")]
        public int AddPost(AddPostVM model)
        {
            if (ModelState.IsValid)
                return lessonOperation.AddPost(model);
            else
                return 0;
        }

    }
}
