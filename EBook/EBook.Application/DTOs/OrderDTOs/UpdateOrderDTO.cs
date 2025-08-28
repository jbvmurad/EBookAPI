namespace EBook.Application.DTOs.OrderDTOs;

public class UpdateOrderDTO
{
    public int OrderId { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
}
