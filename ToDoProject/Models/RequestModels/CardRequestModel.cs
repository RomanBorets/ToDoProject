using System.ComponentModel.DataAnnotations;

namespace ToDoProject.Models.RequestModels
{
    public class CardRequestModel
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(45, ErrorMessage = "Title must be from 1 to 45 symbols", MinimumLength = 1)]
        public string Title { get; set; }

        [StringLength(100, ErrorMessage = "Description must be from 1 to 100 symbols", MinimumLength = 1)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Board id is required")]
        public int? BoardId { get; set; }
    }
}
