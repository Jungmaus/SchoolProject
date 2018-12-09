using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class LessonDetail : BaseEntity
    {
        public LessonDetail()
        {
            this.Lessons = new List<Lesson>();
        }

        public string Subject { get; set; }
        public string Description { get; set; }
        public int Minitues { get; set; }

        public virtual List<Lesson> Lessons { get; set; }
    }
}
