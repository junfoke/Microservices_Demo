﻿using AutoMapper;
using Micro.Services.OrderAPI.Data;
using Micro.Services.ShoppingCartAPI.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Micro.Services.OrderAPI.Models;
using Micro.Services.OrderAPI.Models.Dto;
using Micro.Services.OrderAPI.Utility;
using Microsoft.EntityFrameworkCore;

namespace Micro.Services.OrderAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IMapper _mapper;
        private readonly AppDbContext _db;
        private IProductService _productService;
        public OrderAPIController(AppDbContext db,
            IProductService productService, IMapper mapper)
        {
            _db = db;
            this._response = new ResponseDto();
            _productService = productService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("CreateOrder")]
        public async Task<ResponseDto> CreateOrder([FromBody] CartDto cartDto)
        {
            try
            {
                OrderHeaderDto orderHeaderDto = _mapper.Map<OrderHeaderDto>(cartDto.CartHeader);
                orderHeaderDto.OrderTime = DateTime.Now;
                orderHeaderDto.Status = SD.Status_Pending;
                orderHeaderDto.OrderDetails = _mapper.Map<IEnumerable<OrderDetailsDto>>(cartDto.CartDetails);

                OrderHeader orderCreated = _db.OrderHeaders.Add(_mapper.Map<OrderHeader>(orderHeaderDto)).Entity;
                await _db.SaveChangesAsync();

                orderHeaderDto.OrderHeaderId = orderCreated.OrderHeaderId;
                _response.Result = orderHeaderDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [Authorize]
        [HttpGet("GetOrder/{userId}")]
        public async Task<ResponseDto> GetOrder(string userId)
        {
            try
            {
                var orderHeaderDto = _mapper.Map<List<OrderHeaderDto>>(_db.OrderHeaders.Include(u=>u.OrderDetails)
                    .Where(u => u.UserId == userId).ToList());
                

                _response.Result = orderHeaderDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
		[Authorize]
		[HttpGet("GetOrderDetailsById/{orderHeaderId}")]
		public async Task<ResponseDto> GetOrderDetailsById(int orderHeaderId)
		{
			try
			{
                var orderHeader = _db.OrderHeaders.Include(u => u.OrderDetails)
                    .Where(u => u.OrderHeaderId == orderHeaderId).FirstOrDefault();
				OrderHeaderDto orderHeaderDto = _mapper.Map<OrderHeaderDto>(orderHeader);


				_response.Result = orderHeaderDto;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}


	}
}
