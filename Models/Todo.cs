using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTodo.Models
{
    public class Todo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength( 50 )]
        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public int TodoListId { get; set; }

        public List<Todo> TodoList { get; set; }
    }
}