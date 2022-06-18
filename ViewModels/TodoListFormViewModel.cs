using System.ComponentModel.DataAnnotations;

namespace OnlineTodo.ViewModels
{
    public class TodoListFormViewModel
    {
        [Required]
        [MaxLength( 50 )]
        [Display( Name = "Todo list name" )]
        public string Name { get; set; }

        [MaxLength( 100 )]
        [Display( Name = "Short description" )]
        public string ShortDescription { get; set; }

    }
}