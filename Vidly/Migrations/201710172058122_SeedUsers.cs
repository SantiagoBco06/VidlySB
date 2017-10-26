namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3992750b-c5ac-439c-a456-e11b43ca6d38', N'santiago.bco.juan@gmail.com', 0, N'AMnu4hvRde1KQRofaNwFbXLW2FRuZfMhfU1sIpgLPj6gyDB3W+MUjf5za8BpNU/HIQ==', N'1471f91d-40f4-41b9-9bb5-ed2c9d793ef6', NULL, 0, 0, NULL, 1, 0, N'santiago.bco.juan@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6479cc6a-5904-4fac-9507-97c13a6cc30c', N'admin@white.com', 0, N'AGc066hX6bneQ8lqHw4X+DwBaEJ7jfcd4oB+sOXinTVh2t0G32lk4W2Nt3WzlwRL3g==', N'0870298b-958c-4cbc-97ef-c35943dfeb9a', NULL, 0, 0, NULL, 1, 0, N'admin@white.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'83a64e09-3f3a-4d0b-bb5a-8ac7b9bcff32', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6479cc6a-5904-4fac-9507-97c13a6cc30c', N'83a64e09-3f3a-4d0b-bb5a-8ac7b9bcff32')

                ");

        }
        
        public override void Down()
        {
        }
    }
}
