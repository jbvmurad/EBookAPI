using AutoMapper;
using EBook.Application.DTOs.CategoryDTOs;
using EBook.Application.Interfaces;
using EBook.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBook.Presentation.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CategoryController(IGenericService<Category> _categoryService , IMapper _mapper): ControllerBase
{
    [HttpGet]
    public IActionResult GetList()
    {
        var categories = _categoryService.GetList();
        if(categories is null)
        {
            return NotFound("Category not found");
        }
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var existingCategory=_categoryService.GetById(id);
        if(existingCategory is null)
        {
            return NotFound("Category not found");
        }
        return Ok(existingCategory);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existingCategory=_categoryService.GetById(id);
        if(existingCategory is null)
        {
            return NotFound("Category not found");
        }
        _categoryService.Delete(id);
        return Ok("Category deleted successfully");
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryDTO createCategoryDTO)
    {
        var newCategory=_mapper.Map<Category>(createCategoryDTO);
        _categoryService.Add(newCategory);
        return Ok("Category created successfully");
    }

    [HttpPut]
    public IActionResult Update(UpdateCategoryDTO updateCategoryDTO)
    {
        var existingBook = _categoryService.GetById(updateCategoryDTO.CategoryId);
        if (existingBook is null)
        {
            return NotFound("Category not found");
        }

        _mapper.Map(updateCategoryDTO, existingBook);
        _categoryService.Update(existingBook);

        return Ok("Category updated successfully");
    }
}
