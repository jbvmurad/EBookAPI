using EBook.Application.DTOs.UserDTOs;
using EBook.Domain.Entities;
using EBook.Domain.Enums;

namespace EBook.Application.DTOs.OrderDTOs;

public class OrderListDTO
{
    public int OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public int BookId { get; set; }
    public Book Book { get; set; } = new Book();
    public int UserId { get; set; }
    public UserListDTO User { get; set; } = new UserListDTO();
}
