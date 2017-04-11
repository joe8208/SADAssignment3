namespace SADAssignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineInput",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descriptor = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LineInput");
        }
    }
}
