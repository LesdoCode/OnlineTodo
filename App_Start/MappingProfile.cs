using AutoMapper;
using OnlineTodo.Models;
using OnlineTodo.ViewModels;

namespace OnlineTodo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<TodoList, TodoListFormViewModel>();
            Mapper.CreateMap<TodoListFormViewModel, TodoList>();

            Mapper.CreateMap<TodoList, TodoListViewModel>();
            Mapper.CreateMap<TodoListViewModel, TodoList>();

        }
    }
}