namespace OnlineTodo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTodoListModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todoes", "Title", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Todoes", "Content", c => c.String());
            AddColumn("dbo.Todoes", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Todoes", "IsCompleted");
            DropColumn("dbo.Todoes", "Content");
            DropColumn("dbo.Todoes", "Title");
        }
    }
}
