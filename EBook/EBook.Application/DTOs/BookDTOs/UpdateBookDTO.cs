using System.ComponentModel.DataAnnotations;

namespace EBook.Application.DTOs.BookDTOs
{
    public class UpdateBookDTO
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3-100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Author must be between 3-100 characters")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 99999.99, ErrorMessage = "Price must be between 0.01 and 99999.99.")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
