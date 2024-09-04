using Microsoft.EntityFrameworkCore;
using RestaurantManagementApp.Data;
using RestaurantManagementApp.Models.Domain;
using RestaurantManagementApp.Services.Interfaces;

namespace RestaurantManagementApp.Services.Implementation
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsByOwnerAsync(int ownerId)
        {
            return await _context.Restaurants
                                 .Where(r => r.OwnerID == ownerId)
                                 .ToListAsync();
        }
    }
}
