using Micro.Web.Models;
using Micro.Web.Service.IService;
using Micro.Web.Services.IServices;
using Micro.Web.Utility;

namespace Micro.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }



        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<ResponseDto?> GetOrder(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/order/GetOrder/" + userId
            });
        }

		public async Task<ResponseDto?> GetOrderDetailsById(int orderHeaderId)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.OrderAPIBase + "/api/order/GetOrderDetailsById/" + orderHeaderId
			});
		}
	}
}
