using InvestmentSimulator.Domain.Entities;
using InvestmentSimulator.Domain.Interfaces;
using InvestmentSimulator.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentSimulator.Infrastructure.Repositories;

public class InvestmentRepository(ApplicationDbContext dbContext) : IInvestmentRepository
{

    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Investment> CreateInvestmentAsync(Investment investment)
    {
        await _dbContext.Investments.AddAsync(investment);
        await _dbContext.SaveChangesAsync();

        return investment;

    }

    public async Task<bool> DeleteInvestmentAsync(Guid investmentId)
    {
        var deleted = await _dbContext.Investments
           .Where(i => i.Id == investmentId)
           .ExecuteDeleteAsync();

        return deleted > 1;
    }

    public async Task<List<Investment>> GetAllInvestmentsAsync()
    {
        var investments = await _dbContext.Investments.Select(i => i).ToListAsync();
        return investments;
    }

    public async Task<Investment?> GetInvestmentByIdAsync(Guid investmentId)
    {
        var investment = await _dbContext.Investments
            .FirstOrDefaultAsync(i => i.Id == investmentId);
        return investment;
    }

    public async Task<Investment?> UpdateInvestmentAsync(Investment investment)
    {
       _dbContext.Investments.Update(investment);
       await _dbContext.SaveChangesAsync();

        return await _dbContext.Investments
            .FirstOrDefaultAsync(i => i.Id == investment.Id);
    }
}
