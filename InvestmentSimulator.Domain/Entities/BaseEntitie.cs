namespace InvestmentSimulator.Domain.Entities;

public class BaseEntitie
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? DeletedAt { get; set; } = null;

    public BaseEntitie()
    {
        Id = Guid.NewGuid();
        CreatedAt = CreatedAt;
        UpdatedAt = UpdatedAt;
    }
}
