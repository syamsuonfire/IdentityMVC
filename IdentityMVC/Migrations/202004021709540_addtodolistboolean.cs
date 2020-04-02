namespace IdentityMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtodolistboolean : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoLists", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoLists", "IsCompleted");
        }
    }
}
