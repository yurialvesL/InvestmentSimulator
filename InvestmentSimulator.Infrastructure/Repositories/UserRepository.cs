using InvestmentSimulator.Domain.Entities;
using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{



    public Task<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<User?> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}
