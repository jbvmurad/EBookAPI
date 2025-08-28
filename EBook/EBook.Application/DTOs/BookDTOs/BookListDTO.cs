using EBook.Application.DTOs.CategoryDTOs;
using System.ComponentModel.DataAnnotations;

namespace EBook.Application.DTOs.BookDTOs
{
    public class BookListDTO
    {
        public int BookId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryListDTO Category { get; set; } = new CategoryListDTO();
    }
}
