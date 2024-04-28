using AutoMapper;
using Entities.Models;
using Shared.DataTransferObject_DTO_;

namespace ProductifyBackend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Product, ProductDto>();
            //product Mapping
            CreateMap<Product, ProductDto>() ;
            
            CreateMap<ProductForCreationDto, Product>();

            CreateMap<ProductforUpdateDto, Product>();


            //Seller Mapping
            CreateMap<Seller, SellerDto>()
             .ConstructUsing((src, ctx) => new SellerDto(src.Id, src.Name, src.Description, src.ContactInformation));
            CreateMap<SellerForCreationDto, Seller>();

           CreateMap<SellerForUpdateDto, Seller>();



            //user Mapping
            CreateMap<UserForRegistrationDto, User>();

            CreateMap<User, UserDto>();
        }
    }
}
