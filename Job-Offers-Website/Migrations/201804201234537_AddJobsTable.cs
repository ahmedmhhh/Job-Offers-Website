namespace Job_Offers_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jobTitle = c.String(),
                        jobContent = c.String(),
                        jobImage = c.String(),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "categoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "categoryId" });
            DropTable("dbo.Jobs");
        }
    }
}
