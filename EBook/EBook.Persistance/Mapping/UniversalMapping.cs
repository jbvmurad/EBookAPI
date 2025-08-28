using AutoMapper;
using EBook.Application.DTOs.BookDTOs;
using EBook.Application.DTOs.CategoryDTOs;
using EBook.Application.DTOs.OrderDTOs;
using EBook.Application.DTOs.PaymentDTOs;
using EBook.Application.DTOs.UserDTOs;
using EBook.Domain.Entities;

namespace EBook.Persistance.Mapping;

public class UniversalMapping:Profile
{
    public UniversalMapping()
    {
        ConfigureBookMapping();
        ConfigureOrderMapping();
        ConfigureUserMapping();
        ConfigureCategoryMapping();
        ConfigurePaymentMapping();
    }
    private void ConfigureBookMapping()
    {
        CreateMap<Book ,CreateBookDTO>().ReverseMap();
        CreateMap<Book ,UpdateBookDTO>().ReverseMap();
        CreateMap<Book ,BookListDTO>().ReverseMap();
    }

    private void ConfigureOrderMapping()
    {
        CreateMap<Order ,CreateOrderDTO>().ReverseMap();
        CreateMap<Order ,UpdateOrderDTO>().ReverseMap();
        CreateMap<Order ,OrderListDTO>().ReverseMap();
    }

    private void ConfigureUserMapping()
    {
        CreateMap<User ,CreateUserDTO>().ReverseMap();
        CreateMap<User ,UpdateUserDTO>().ReverseMap();
        CreateMap<User ,UserListDTO>().ReverseMap();
    }

    private void ConfigureCategoryMapping()
    {
        CreateMap<Category ,CreateCategoryDTO>().ReverseMap();
        CreateMap<Category ,UpdateCategoryDTO>().ReverseMap();
        CreateMap<Category ,CategoryListDTO>().ReverseMap();
    }

    private void ConfigurePaymentMapping()
    {
        CreateMap<Payment ,PaymentListDTO>().ReverseMap();
    }
}
