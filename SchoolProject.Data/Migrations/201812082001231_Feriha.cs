namespace SchoolProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feriha : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LessonDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 300),
                        Minitues = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        StartDate = c.DateTime(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        LessonDetailID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LessonDetails", t => t.LessonDetailID)
                .ForeignKey("dbo.Users", t => t.TeacherID)
                .Index(t => t.ID)
                .Index(t => t.TeacherID)
                .Index(t => t.LessonDetailID);
            
            CreateTable(
                "dbo.LessonStudentMeetings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LessonID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lessons", t => t.LessonID)
                .ForeignKey("dbo.Users", t => t.StudentID)
                .Index(t => t.ID)
                .Index(t => t.LessonID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Surname = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 25),
                        AccountType = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LessonTeacherPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 300),
                        AddDate = c.DateTime(nullable: false),
                        LessonID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lessons", t => t.LessonID)
                .Index(t => t.ID)
                .Index(t => t.LessonID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonTeacherPosts", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.LessonStudentMeetings", "StudentID", "dbo.Users");
            DropForeignKey("dbo.Lessons", "TeacherID", "dbo.Users");
            DropForeignKey("dbo.LessonStudentMeetings", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "LessonDetailID", "dbo.LessonDetails");
            DropIndex("dbo.LessonTeacherPosts", new[] { "LessonID" });
            DropIndex("dbo.LessonTeacherPosts", new[] { "ID" });
            DropIndex("dbo.LessonStudentMeetings", new[] { "StudentID" });
            DropIndex("dbo.LessonStudentMeetings", new[] { "LessonID" });
            DropIndex("dbo.LessonStudentMeetings", new[] { "ID" });
            DropIndex("dbo.Lessons", new[] { "LessonDetailID" });
            DropIndex("dbo.Lessons", new[] { "TeacherID" });
            DropIndex("dbo.Lessons", new[] { "ID" });
            DropIndex("dbo.LessonDetails", new[] { "ID" });
            DropTable("dbo.LessonTeacherPosts");
            DropTable("dbo.Users");
            DropTable("dbo.LessonStudentMeetings");
            DropTable("dbo.Lessons");
            DropTable("dbo.LessonDetails");
        }
    }
}
