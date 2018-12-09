using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Mapping
{
    public class LessonTeacherPostMap : EntityTypeConfiguration<LessonTeacherPost>
    {
        public LessonTeacherPostMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.Title).HasMaxLength(40).IsRequired();
            this.Property(x => x.Description).HasMaxLength(300).IsRequired();
            this.HasIndex(x => x.ID);
        }
    }
}
