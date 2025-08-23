using InvestmentSimulator.Domain.Enum;
using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Application.Strategies;

public class LCIStrategy : IInvestmentStrategy
{
    public static InvestmentType Type => InvestmentType.LCI;

    InvestmentType IInvestmentStrategy.Type { get => Type; }
    public async Task<decimal> SimulateInvestment(decimal initialAmount, decimal monthlyAmount, int months)
    {
        throw new NotImplementedException();
    }
}
