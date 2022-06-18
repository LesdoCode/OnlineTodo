namespace OnlineTodo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddTodoListModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoLists",
                c => new
                {
                    Id = c.Int( nullable: false, identity: true ),
                    Name = c.String( nullable: false, maxLength: 50 ),
                    ShortDescription = c.String( maxLength: 100 ),
                } )
                .PrimaryKey( t => t.Id );

            CreateTable(
                "dbo.Todos",
                c => new
                {
                    Id = c.Int( nullable: false, identity: true ),
                    TodoListId = c.Int( nullable: false ),
                    Todo_Id = c.Int(),
                } )
                .PrimaryKey( t => t.Id )
                .ForeignKey( "dbo.Todos", t => t.Todo_Id )
                .ForeignKey( "dbo.TodoLists", t => t.TodoListId, cascadeDelete: true )
                .Index( t => t.TodoListId )
                .Index( t => t.Todo_Id );

        }

        public override void Down()
        {
            DropForeignKey( "dbo.Todos", "TodoListId", "dbo.TodoLists" );
            DropForeignKey( "dbo.Todos", "Todo_Id", "dbo.Todos" );
            DropIndex( "dbo.Todos", new[] { "Todo_Id" } );
            DropIndex( "dbo.Todos", new[] { "TodoListId" } );
            DropTable( "dbo.Todos" );
            DropTable( "dbo.TodoLists" );
        }
    }
}
