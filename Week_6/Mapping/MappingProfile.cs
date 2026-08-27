using AutoMapper;
using MyWebProject.Models;
using MyWebProject.DTOs;

namespace MyWebProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // 👤 User
            CreateMap<User, UserResponse>();
            CreateMap<UpdateUserRequest, User>();

            // 🏷️ Category
            CreateMap<Category, CategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();

            // 🍕 Product
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();

            // 📋 Order
            CreateMap<Order, OrderItemResponse>();
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<OrderItem, OrderItemResponse>();
            CreateMap<CreateOrderItemRequest, OrderItem>();
        }
    }
}
