namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addrequiredfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditCards", "PINCode", c => c.String(nullable: false, maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditCards", "PINCode", c => c.String());
        }
    }
}
