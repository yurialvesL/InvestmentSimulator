using InvestmentSimulator.Domain.Entities;

namespace InvestmentSimulator.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<User?> GetUserByEmailAsync(string email);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<User?> UpdateUserAsync(User user);
    Task<IEnumerable<User>> GetAllUsersAsync();
}
