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

    public async Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        _context.Users.Remove(new User { Id = userId });
        return await _context.SaveChangesAsync(cancellationToken).ContinueWith(t => t.Result > 0);
    }

    public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
       var users = await _context.Users.AsNoTracking().Select(u => u).ToListAsync(cancellationToken: cancellationToken);
        return users;
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var user =  await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);
        return user;
    }

    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId, cancellationToken: cancellationToken);
        return user;
    }

    public async Task<User?> UpdateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        _context.Users.Update(user);

        await _context.SaveChangesAsync(cancellationToken);

        return await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken: cancellationToken);
    }
}
