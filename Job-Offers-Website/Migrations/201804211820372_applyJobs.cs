namespace Job_Offers_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyJobs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForJobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        jobId = c.Int(nullable: false),
                        userId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jobs", t => t.jobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.jobId)
                .Index(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJobs", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForJobs", "jobId", "dbo.Jobs");
            DropIndex("dbo.ApplyForJobs", new[] { "userId" });
            DropIndex("dbo.ApplyForJobs", new[] { "jobId" });
            DropTable("dbo.ApplyForJobs");
        }
    }
}
