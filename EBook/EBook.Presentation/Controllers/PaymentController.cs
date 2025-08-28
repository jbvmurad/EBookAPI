using EBook.Application.Interfaces;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PaymentController(IGenericService<Payment> paymentService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetList()
    {
        var payments = paymentService.GetList();
        if(payments is null)
        {
            return NotFound("No payments found");
        }
        return Ok(payments);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var existingpayment = paymentService.GetById(id);
        if (existingpayment is null)
        {
            return NotFound("Payment not found");
        }
        return Ok(existingpayment);
    }
}
