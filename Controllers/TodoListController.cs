using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using OnlineTodo.DataAccess;
using OnlineTodo.Models;
using OnlineTodo.ViewModels;

namespace OnlineTodo.Controllers
{
    public class TodoListController : Controller
    {
        TodoListRepository _todoLists;
        TodoRepository _todos;

        public TodoListController()
        {
            _todoLists = new TodoListRepository();
            _todos = new TodoRepository();
        }

        public ActionResult Index()
        {
            var viewModel = _todoLists
                .GetAll()
                .Reverse()
                .Select( Mapper.Map<TodoList, TodoListViewModel> );

            return View( viewModel );
        }

        public ActionResult Create()
        {
            ViewBag.title = "Create a list";
            return View( "TodoListForm", new TodoListFormViewModel() );
        }

        [HttpPost]
        public ActionResult Create( TodoListFormViewModel viewModel )
        {
            if ( !ModelState.IsValid )
            {
                return View( "TodoListForm", viewModel );
            }

            var newTodoList = Mapper.Map<TodoListFormViewModel, TodoList>( viewModel );
            newTodoList.Id = 0;
            newTodoList.Todos = new List<Todo>();

            _todoLists.Add( newTodoList );

            ViewBag.title = "Create a list";
            return RedirectToAction( "Index" );
        }

        public ActionResult Edit( int Id )
        {
            ViewBag.title = "Edit my list";
            var viewModel = Mapper.Map<TodoList, TodoListFormViewModel>( _todoLists.GetById( Id ) );
            return View( "TodoListForm", viewModel );
        }

        [HttpPost]
        public ActionResult Edit( int Id, TodoListFormViewModel viewModel )
        {
            if ( !ModelState.IsValid )
            {
                return View( "TodoListForm", viewModel );
            }

            ViewBag.title = "Edit my list";

            var todoList = Mapper.Map<TodoListFormViewModel, TodoList>( viewModel );
            _todoLists.Update( Id, todoList );

            return RedirectToAction( "Index" );
        }

        public ActionResult ViewList( int Id )
        {
            var listFromDb = _todoLists.GetById( Id );
            if ( listFromDb == null )
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<TodoList, TodoListViewModel>( listFromDb );
            if ( viewModel == null )
            {
                return HttpNotFound();
            }


            return View( viewModel );
        }

        [HttpPost]
        public ActionResult AddTodo( int Id, TodoViewModel todoViewModel )
        {
            var todoListFromDb = _todoLists.GetById( Id );
            if ( todoListFromDb == null )
            {
                return HttpNotFound();
            }

            if ( !ModelState.IsValid )
            {
                return View( todoViewModel );
            }

            var newTodo = new Todo()
            {
                Title = todoViewModel.Title,
                Content = todoViewModel.Content,
                IsCompleted = false,
                TodoListId = todoListFromDb.Id,
            };

            _todos.Add( newTodo );

            return RedirectToAction( $"ViewList/{Id}" );
        }

        [HttpPost]
        public ActionResult DeleteTodoList( int Id )
        {
            var listFromDb = _todoLists.GetById( Id );
            if ( listFromDb == null )
            {
                return HttpNotFound();
            }

            _todoLists.Delete( Id );
            return RedirectToAction( "Index" );
        }
    }
}