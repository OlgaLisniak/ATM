namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditCards", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditCards", "Number", c => c.String());
        }
    }
}
