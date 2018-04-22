namespace Job_Offers_Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditJobModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropColumn("dbo.Jobs", "UserId");
        }
    }
}
