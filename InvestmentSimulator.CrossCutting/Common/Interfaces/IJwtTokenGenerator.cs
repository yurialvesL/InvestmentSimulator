using InvestmentSimulator.Domain.Interfaces;

namespace InvestmentSimulator.CrossCutting.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(IUser user);
}
