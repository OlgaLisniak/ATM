namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWithdrawnAmounttooperationResulttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OperationResults", "WithdrawnAmount", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OperationResults", "WithdrawnAmount");
        }
    }
}
