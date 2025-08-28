using AutoMapper;
using EBook.Application.DTOs.OrderDTOs;
using EBook.Application.Interfaces;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrderController(IGenericService<Order> _orderService , IMapper _mapper): ControllerBase
{
    [HttpGet]
    public IActionResult GetList()
    {
        var orders = _orderService.GetList();
        if(orders is null)
        {
            return NotFound("Order not found");
        }
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var existingOrder=_orderService.GetById(id);
        if(existingOrder is null)
        {
            return NotFound("Order not found");
        }
        return Ok(existingOrder);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingOrder=_orderService.GetById(id);
        if(existingOrder is null)
        {
            return NotFound("Order not found");
        }
        _orderService.Delete(id);
        return Ok("Order deleted successfully");
    }

    [HttpPost]
    public IActionResult Create(CreateOrderDTO createOrderDTO)
    {
        var newOrder=_mapper.Map<Order>(createOrderDTO);
        _orderService.Add(newOrder);
        return Ok("Order created successfully");
    }

    [HttpPut]
    public IActionResult Update(UpdateOrderDTO updateOrderDTO)
    {
        var existingBook = _orderService.GetById(updateOrderDTO.OrderId);
        if (existingBook is null)
        {
            return NotFound("Order not found");
        }

        _mapper.Map(updateOrderDTO, existingBook);
        _orderService.Update(existingBook);

        return Ok("Order updated successfully");
    }

}
