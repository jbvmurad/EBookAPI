using AutoMapper;
using EBook.Application.DTOs.UserDTOs;
using EBook.Application.Interfaces;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController(IGenericService<User> _userService , IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public IActionResult GetList()
    {
        var users = _userService.GetList();
        if(users is null)
        {
            return NotFound("No users found");
        }
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var existingUser = _userService.GetById(id);
        if (existingUser is null)
        {
            return NotFound("User not found");
        }
        return Ok(existingUser);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingUser = _userService.GetById(id);
        if (existingUser is null)
        {
            return NotFound("User not found");
        }
        _userService.Delete(id);
        return Ok("User deleted successfully");
    }

    [HttpPost]
    public IActionResult Create(CreateUserDTO createUserDTO)
    {
        var user = _mapper.Map<User>(createUserDTO);
        _userService.Add(user);
        return Ok("User created successfully");
    }

    [HttpPut]
    public IActionResult Update(UpdateUserDTO updateUserDTO)
    {
        var existingBook = _userService.GetById(updateUserDTO.UserId);
        if (existingBook is null)
        {
            return NotFound("User not found");
        }

        _mapper.Map(updateUserDTO, existingBook);
        _userService.Update(existingBook);

        return Ok("User updated successfully");
    }
}
