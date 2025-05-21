namespace Finament.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }


    public Category Category { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
