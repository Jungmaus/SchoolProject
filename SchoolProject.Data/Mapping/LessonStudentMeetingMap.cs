using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Mapping
{
    public class LessonStudentMeetingMap : EntityTypeConfiguration<LessonStudentMeeting>
    {
        public LessonStudentMeetingMap()
        {
            this.HasKey(x => x.ID);
            this.HasIndex(x => x.ID);
        }
    }
}
