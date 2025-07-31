namespace InvestmentSimulator.CrossCutting.Common.Interfaces;

public interface ITokenGerneration
{
    string GenerateToken(string userId, string secretKey, DateTime expirationDate);
}
