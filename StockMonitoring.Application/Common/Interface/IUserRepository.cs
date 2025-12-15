using StockMonitoring.Application.DTOs;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Application.Common.Interface
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
    }
}
