namespace Finament.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Color { get; set; } = "#FFFFFF"; // Default white
    public decimal? MonthlyLimit { get; set; }

    public User User { get; set; } = null!;
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
