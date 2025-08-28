using AutoMapper;
using EBook.Application.DTOs.BookDTOs;
using EBook.Application.Interfaces;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookController(IGenericService<Book> _bookService , IMapper _mapper):ControllerBase
{
    [HttpGet]
    public IActionResult GetList()
    {
        var books = _bookService.GetList();
        if(books is null)
        {
            return NotFound("Book not found");
        }
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var existingBook=_bookService.GetById(id);
        if(existingBook is null)
        {
            return NotFound("Book not found");
        }
        return Ok(existingBook);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingBook=_bookService.GetById(id);
        if(existingBook is null)
        {
            return NotFound("Book not found");
        }
        _bookService.Delete(id);
        return Ok("Book deleted successfully");
    }

    [HttpPost]
    public IActionResult Create(CreateBookDTO createBookDTO)
    {
        var newbook=_mapper.Map<Book>(createBookDTO);
        _bookService.Add(newbook);
        return Ok("Book created successfully");
    }

    [HttpPut]
    public IActionResult Update(UpdateBookDTO updateBookDTO)
    {
        var existingBook = _bookService.GetById(updateBookDTO.BookId);
        if (existingBook is null)
        {
            return NotFound("Book not found");
        }

        _mapper.Map(updateBookDTO, existingBook);
        _bookService.Update(existingBook);

        return Ok("Book updated successfully");
    }
}
