using InvestmentSimulator.Domain.Entities;
using InvestmentSimulator.Domain.Interfaces;
using InvestmentSimulator.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentSimulator.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user);    
        await _context.SaveChangesAsync();
        return user;
    }

    public Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        _context.Users.Remove(new User { Id = userId });
        return _context.SaveChangesAsync().ContinueWith(t => t.Result > 0);
    }

    public Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
       var users = _context.Users.Select(u => u).ToListAsync();
        return users;
    }

    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }

    public Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        return user;
    }

    public Task<User?> UpdateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);
        _context.SaveChangesAsync();

        return _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
    }
}
