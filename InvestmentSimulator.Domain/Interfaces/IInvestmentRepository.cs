using InvestmentSimulator.Domain.Entities;

namespace InvestmentSimulator.Domain.Interfaces;

public interface IInvestmentRepository
{
    Task<Investment> CreateInvestmentAsync(Investment investment);
    Task<Investment?> GetInvestmentByIdAsync(Guid investmentId);
    Task<IEnumerable<Investment>> GetAllInvestmentsAsync();
    Task<bool> DeleteInvestmentAsync(Guid investmentId);
    Task<Investment?> UpdateInvestmentAsync(Investment investment);                 
}