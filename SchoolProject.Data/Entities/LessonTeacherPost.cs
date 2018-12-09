using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class LessonTeacherPost : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }

        public int LessonID { get; set; }

        [ForeignKey("LessonID")]
        public virtual Lesson Lesson { get; set; }
    }
}
