using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagementApp.Models.Domain;
using RestaurantManagementApp.Models.Dto;
using RestaurantManagementApp.Services.Interfaces;

namespace RestaurantManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IRepository<MenuItem> _menuItemRepository;

        public MenuItemController(IRepository<MenuItem> menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            var menuItems = await _menuItemRepository.GetAllAsync();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuItem(MenuItemDto menuItemDto)
        {
            var menuItem = new MenuItem
            {
                ItemName = menuItemDto.ItemName,
                Description = menuItemDto.Description,
                Price = menuItemDto.Price,
                Availability = menuItemDto.Availability,
                ExpectedCookingTime = menuItemDto.ExpectedCookingTime
            };

            await _menuItemRepository.AddAsync(menuItem);
            return CreatedAtAction(nameof(GetMenuItemById), new { id = menuItem.MenuItemID }, menuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItemDto menuItemDto)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            menuItem.ItemName = menuItemDto.ItemName;
            menuItem.Description = menuItemDto.Description;
            menuItem.Price = menuItemDto.Price;
            menuItem.Availability = menuItemDto.Availability;
            menuItem.ExpectedCookingTime = menuItemDto.ExpectedCookingTime;

            await _menuItemRepository.UpdateAsync(menuItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            await _menuItemRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
