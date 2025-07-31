using InvestmentSimulator.Domain.Enum;
using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Application.Strategies;

public class TesouroDiretoStrategy : IInvestmentStrategy
{
    public static InvestmentType Type => InvestmentType.TesouroDireto;

    InvestmentType IInvestmentStrategy.Type { get => Type; }

    public Task<decimal> SimualateInvestment(decimal initialAmount, decimal monthlyAmount, int months)
    {
        throw new NotImplementedException();
    }
}
