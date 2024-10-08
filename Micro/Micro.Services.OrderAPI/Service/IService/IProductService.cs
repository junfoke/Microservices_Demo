﻿using Micro.Services.OrderAPI.Models.Dto;

namespace Micro.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
