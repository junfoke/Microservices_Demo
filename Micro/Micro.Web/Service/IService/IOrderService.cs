﻿using Micro.Web.Models;
namespace Micro.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDto cartDto);
        Task<ResponseDto?> GetOrder(String userId);
		Task<ResponseDto?> GetOrderDetailsById(int orderHeaderId);
	}
}
