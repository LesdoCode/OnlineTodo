using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineTodo.Models
{
    public class TodoList
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