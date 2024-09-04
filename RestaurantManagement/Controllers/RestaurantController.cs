using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementApp.Models.Domain;
using RestaurantManagementApp.Models.Dto;
using RestaurantManagementApp.Services.Interfaces;

namespace RestaurantManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantController(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(RestaurantDto restaurantDto)
        {
            var restaurant = new Restaurant
            {
                RestaurantName = restaurantDto.RestaurantName,
                Address = restaurantDto.Address,
                PhoneNumber = restaurantDto.PhoneNumber,
                Email = restaurantDto.Email,
                TotalTables = restaurantDto.TotalTables
            };

            await _restaurantRepository.AddAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurant.RestaurantID }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, RestaurantDto restaurantDto)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            restaurant.RestaurantName = restaurantDto.RestaurantName;
            restaurant.Address = restaurantDto.Address;
            restaurant.PhoneNumber = restaurantDto.PhoneNumber;
            restaurant.Email = restaurantDto.Email;
            restaurant.TotalTables = restaurantDto.TotalTables;

            await _restaurantRepository.UpdateAsync(restaurant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            await _restaurantRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
