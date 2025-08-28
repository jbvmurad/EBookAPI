using EBook.Application.DTOs.BookDTOs;

namespace EBook.Application.DTOs.CategoryDTOs
{
    public class CategoryListDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BookListDTO> Books { get; set; } = new List<BookListDTO>();
    }
}
