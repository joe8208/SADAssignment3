namespace SADAssignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNoiseWords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoiseWord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NoiseWord");
        }
    }
}
