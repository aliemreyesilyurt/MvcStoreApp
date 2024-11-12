using AutoMapper;
using Entities.Dtos.Order;
using Entities.Dtos.Product;
using Entities.Dtos.User;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

            CreateMap<UserDtoForCreation, User>();
            CreateMap<UserDtoForUpdate, User>().ReverseMap();
            CreateMap<RegisterDto, User>();

            CreateMap<OrderDto, Order>().ReverseMap();
        }
    }
}
