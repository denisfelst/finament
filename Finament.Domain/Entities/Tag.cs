namespace Finament.Domain.Entities;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
