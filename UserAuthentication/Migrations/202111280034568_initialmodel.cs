namespace UserAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        CourseID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserID, t.CourseID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.UserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserCourses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserCourses", new[] { "CourseID" });
            DropTable("dbo.UserCourses");
        }
    }
}
