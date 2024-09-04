using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementApp.Models.Domain;
using RestaurantManagementApp.Models.Dto;
using RestaurantManagementApp.Services.Interfaces;

namespace RestaurantManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                RestaurantID = orderDto.RestaurantID,
                CustomerID = orderDto.CustomerID,
                TableID = orderDto.TableID,
                OrderToken = orderDto.OrderToken,
                OrderAmount = orderDto.OrderAmount,
                PaymentStatus = orderDto.PaymentStatus,
                OrderStatus = orderDto.OrderStatus
            };

            await _orderRepository.AddAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderID }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDto orderDto)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.OrderToken = orderDto.OrderToken;
            order.OrderAmount = orderDto.OrderAmount;
            order.PaymentStatus = orderDto.PaymentStatus;
            order.OrderStatus = orderDto.OrderStatus;

            await _orderRepository.UpdateAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
