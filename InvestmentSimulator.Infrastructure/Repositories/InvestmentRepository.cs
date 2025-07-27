using InvestmentSimulator.Domain.Entities;
using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Infrastructure.Repositories;

public class InvestmentRepository : IInvestmentRepository
{
    public Task<Investment> CreateInvestmentAsync(Investment investment)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteInvestmentAsync(Guid investmentId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Investment>> GetAllInvestmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Investment?> GetInvestmentByIdAsync(Guid investmentId)
    {
        throw new NotImplementedException();
    }

    public Task<Investment?> UpdateInvestmentAsync(Investment investment)
    {
        throw new NotImplementedException();
    }
}
