namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetypeWithdrawnAmounttoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OperationResults", "WithdrawnAmount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OperationResults", "WithdrawnAmount", c => c.Double());
        }
    }
}
