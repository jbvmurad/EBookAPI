using EBook.Application.DTOs.OrderDTOs;
using EBook.Domain.Enums;

namespace EBook.Application.DTOs.PaymentDTOs;

public class PaymentListDTO
{
    public int PaymentId { get; set; }

    public PaymentStatus Status { get; set; }

    public PaymentMethod Method { get; set; }

    public List<OrderListDTO> Orders { get; set; } = new List<OrderListDTO>();
}
