using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Mapping
{
    public class LessonDetailMap : EntityTypeConfiguration<LessonDetail>
    {
        public LessonDetailMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.Minitues).IsRequired();
            this.Property(x => x.Subject).HasMaxLength(40).IsRequired(); ;
            this.Property(x => x.Description).HasMaxLength(300).IsRequired();
            this.HasIndex(x => x.ID);
        }
    }
}
