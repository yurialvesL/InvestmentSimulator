using InvestmentSimulator.Domain.Enum;
using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.Application.Services;

public class InvestStrategyResolver(IEnumerable<IInvestmentStrategy> strategies)
{
    private readonly Dictionary<InvestmentType, IInvestmentStrategy> _strategies = strategies.ToDictionary(s => s.Type, s => s);

    public IInvestmentStrategy Resolve(InvestmentType type)
    {
        if (_strategies.TryGetValue(type, out var strategy))
            return strategy;
        
        throw new ArgumentException($"No investment strategy found for type {type}", nameof(type));
    }
}
