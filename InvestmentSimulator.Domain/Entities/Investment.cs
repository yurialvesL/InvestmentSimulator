using InvestmentSimulator.Domain.Enum;

namespace InvestmentSimulator.Domain.Entities;

public class Investment : BaseEntitie
{
    public Guid UserId { get; set; } 
    public InvestmentType InvestmentType { get; set; }
    public decimal InitialAmount { get; set; }
    public decimal MonthlyInvestment { get; set; }
    public int InvestmentDurationInMonths { get; set; }
    public User User { get; set; } = null!; 
}
