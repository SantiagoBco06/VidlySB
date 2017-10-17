namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUninitializedChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: true));
        }

        public override void Down()
        {
        }
    }
}
