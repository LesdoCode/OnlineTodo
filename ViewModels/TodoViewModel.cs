using System.ComponentModel.DataAnnotations;

namespace OnlineTodo.ViewModels
{
    public class TodoViewModel
    {
        [Required]
        public int ListId { get; set; }

        [Required]
        [MaxLength( 50 )]
        [MinLength( 3 )]
        public string Title { get; set; }

        [MaxLength( 500 )]
        public string Content { get; set; }

    }
}