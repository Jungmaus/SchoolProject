using SchoolProject.Business.OperationLibrary;
using SchoolProject.Model.VM.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolProject.API.Controllers
{
    public class ReportController : BaseController
    {
        private ReportOperation reportOperation;

        public ReportController()
        {
            this.reportOperation = new ReportOperation();
        }

        [Route("api/report/getlessonmeetingreport")]
        public List<LessonMeetingVM> GetLessonMeetingReport(int lessonID) => reportOperation.GetLessonMeetingReport(lessonID);

        [Route("api/report/getteacherssharepostreport")]
        public List<SharePostVM> GetTeachersSharePostReport(int teacherID) => reportOperation.GetTeachersSharePostReport(teacherID);

    }
}
