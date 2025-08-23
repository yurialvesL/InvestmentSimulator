using InvestmentSimulator.Domain.Enum;
using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Application.Strategies;

public class SavingsAccountStrategy : IInvestmentStrategy
{

    public static InvestmentType Type => InvestmentType.SavingsAccount;

    InvestmentType IInvestmentStrategy.Type { get => Type; }

    public async Task<decimal> SimulateInvestment(decimal initialAmount, decimal monthlyAmount, int months)
    {
        throw new NotImplementedException();
    }
}
