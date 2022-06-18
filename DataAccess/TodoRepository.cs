using System.Collections.Generic;
using System.Linq;
using OnlineTodo.Models;

namespace OnlineTodo.DataAccess
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _db;

        public TodoRepository()
        {
            _db = new ApplicationDbContext();
        }
        public void Add( Todo todo )
        {
            _db.Todos.Add( todo );
            _db.SaveChanges();
        }

        public void Delete( int Id )
        {
            _db.Todos.Remove( GetById( Id ) );
            _db.SaveChanges();
        }

        public IEnumerable<Todo> GetAll()
        {
            return _db.Todos.ToList();
        }

        public Todo GetById( int Id )
        {
            return _db.Todos.SingleOrDefault( t => t.Id == Id );
        }

        public void Update( int Id, Todo newTodo )
        {
            var todoFromDb = GetById( Id );

            todoFromDb.Title = newTodo.Title;
            todoFromDb.Content = newTodo.Content;
            todoFromDb.IsCompleted = newTodo.IsCompleted;
            todoFromDb.TodoListId = newTodo.TodoListId;

            _db.SaveChanges();

        }
    }
}