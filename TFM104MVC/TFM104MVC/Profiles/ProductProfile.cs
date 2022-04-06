using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TFM104MVC.Dtos;
using TFM104MVC.Models;

namespace TFM104MVC.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPersent ?? 1)))
                .ForMember(dest => dest.TravelDays, opt => opt.MapFrom(src => src.TravelDays.ToString()))
                .ForMember(dest => dest.TripType, opt => opt.MapFrom(src => src.TripType.ToString()))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region.ToString()));

            CreateMap<ProductCreationDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
