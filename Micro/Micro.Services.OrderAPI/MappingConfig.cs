﻿using AutoMapper;
using Micro.Services.OrderAPI.Models;
using Micro.Services.OrderAPI.Models.Dto;

namespace Micro.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderHeaderDto, CartHeaderDto>()
                .ForMember(dest => dest.CartTotal, u => u.MapFrom(src => src.OrderTotal)).ReverseMap();

                config.CreateMap<CartDetailsDto, OrderDetailsDto>()
                .ForMember(dest => dest.ProductName, u => u.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Price, u => u.MapFrom(src => src.Product.Price));

                config.CreateMap<OrderDetailsDto, CartDetailsDto>();

                config.CreateMap<OrderHeader, OrderHeaderDto>()
                .ForMember(o => o.OrderDetails, o => o.MapFrom(src => src.OrderDetails.Select(od => new OrderDetailsDto{

					OrderDetailsId = od.OrderDetailsId,
		            OrderHeaderId = od.OrderHeaderId,                        
		             ProductId =od.ProductId,
		            Count=od.Count,
		            ProductName=od.ProductName, Price=od.Price,
	            })))
                .ReverseMap();
                config.CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
