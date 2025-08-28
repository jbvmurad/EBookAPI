using EBook.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EBook.Application.DTOs.UserDTOs;

public class UserListDTO
{
    public int UserId { get; set; }

    [Required(ErrorMessage ="Username is required")]
    [StringLength(100,MinimumLength =3,ErrorMessage =("Username must be between 3-100 characters"))]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage ="Email is invalid")]
    public string Email { get; set; } = string.Empty;

    public List<Payment> Payments { get; set; } = new List<Payment>();
}
