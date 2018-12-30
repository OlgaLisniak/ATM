namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaintables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        PINCode = c.String(),
                        Balance = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.OperationResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        OperationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        OperationId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OperationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Operations");
            DropTable("dbo.OperationResults");
            DropTable("dbo.CreditCards");
        }
    }
}
