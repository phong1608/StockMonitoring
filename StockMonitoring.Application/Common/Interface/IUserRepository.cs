using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Common.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
    }
}
