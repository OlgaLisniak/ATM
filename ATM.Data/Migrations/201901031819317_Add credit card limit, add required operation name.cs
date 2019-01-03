namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcreditcardlimitaddrequiredoperationname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditCards", "Number", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Operations", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Operations", "Name", c => c.String());
            AlterColumn("dbo.CreditCards", "Number", c => c.String(nullable: false));
        }
    }
}
