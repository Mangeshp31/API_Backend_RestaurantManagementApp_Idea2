using RestaurantManagementApp.Models.Domain;

namespace RestaurantManagementApp.Services.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<IEnumerable<Restaurant>> GetRestaurantsByOwnerAsync(int ownerId);
    }
}
