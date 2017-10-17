namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (4, 'Rommance')");
            Sql("INSERT INTO GenreTypes (Id, Name) VALUES (5, 'Drama')");

        }
        
        public override void Down()
        {
        }
    }
}
