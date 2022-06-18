using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OnlineTodo.Models;

namespace OnlineTodo.ViewModels
{
    public class TodoListViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength( 50 )]
        public string Name { get; set; }

        [MaxLength( 100 )]
        public string ShortDescription { get; set; }

        [Required]
        public List<Todo> Todos { get; set; }
    }
}