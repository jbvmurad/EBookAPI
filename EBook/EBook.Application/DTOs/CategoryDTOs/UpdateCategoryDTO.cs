using System.ComponentModel.DataAnnotations;

namespace EBook.Application.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3-100 characters")]
        public string Name { get; set; } = string.Empty;
    }
}
