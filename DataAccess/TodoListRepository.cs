using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineTodo.Models;

namespace OnlineTodo.DataAccess
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly ApplicationDbContext _db;

        public TodoListRepository()
        {
            _db = new ApplicationDbContext();
        }

        public void Add( TodoList todoList )
        {
            _db.TodoLists.Add( todoList );
            _db.SaveChanges();
        }

        public void Delete( int Id )
        {
            _db.TodoLists.Remove( GetById( Id ) );
            _db.SaveChanges();
        }

        public IEnumerable<TodoList> GetAll()
        {
            return _db.TodoLists.Include( l => l.Todos ).ToList();
        }

        public TodoList GetById( int Id )
        {
            return _db.TodoLists.Include( l => l.Todos ).SingleOrDefault( l => l.Id == Id );
        }

        public void Update( int Id, TodoList newTodoList )
        {
            var todoListFromDb = GetById( Id );
            todoListFromDb.Name = newTodoList.Name;
            todoListFromDb.ShortDescription = newTodoList.ShortDescription;
            todoListFromDb.Todos = newTodoList.Todos;

            _db.SaveChanges();
        }

    }
}