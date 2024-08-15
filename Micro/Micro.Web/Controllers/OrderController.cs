using Micro.Web.Models;
using Micro.Web.Service;
using Micro.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Micro.Web.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

		[Authorize]
		public async Task<IActionResult> OrderIndex()
        {
            
            return View(await LoadOrderDtoBasedOnLoggedInUser());
        }
		[Authorize]
		public async Task<IActionResult> OrderDetails(int orderHeaderId)
		{
            var orderDetails = await LoadOrderDetailsDto(orderHeaderId);
            ViewBag.OrderDetails = orderDetails;
			return View();
		}



		private async Task<List<OrderHeaderDto>> LoadOrderDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?.FirstOrDefault()?.Value;
            ResponseDto? response = await _orderService.GetOrder(userId);
            if (response != null & response.IsSuccess)
            {
                List<OrderHeaderDto> orderDto = JsonConvert.DeserializeObject<List<OrderHeaderDto>>(Convert.ToString(response.Result));
                return orderDto;
            }
            return new List<OrderHeaderDto>();
        }
		private async Task<OrderHeaderDto> LoadOrderDetailsDto(int orderHeaderId)
		{
			ResponseDto? response = await _orderService.GetOrderDetailsById(orderHeaderId);
			if (response != null & response.IsSuccess)
			{
				OrderHeaderDto orderDto = JsonConvert.DeserializeObject<OrderHeaderDto>(Convert.ToString(response.Result));
				return orderDto;
			}
			return new OrderHeaderDto();
		}
	}
}
