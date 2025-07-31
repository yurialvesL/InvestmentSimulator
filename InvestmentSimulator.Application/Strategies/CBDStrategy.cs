using InvestmentSimulator.Domain.Enum;
using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Application.Strategies;

public class CBDStrategy : IInvestmentStrategy
{
    public static InvestmentType Type => InvestmentType.CDB;

    InvestmentType IInvestmentStrategy.Type { get => Type; }

    public async Task<decimal> SimualateInvestment(decimal initialAmount, decimal monthlyAmount, int months)
    {
        throw new NotImplementedException();
    }
}
