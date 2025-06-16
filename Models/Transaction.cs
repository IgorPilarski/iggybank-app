public class Transaction
{
    public Guid TransactionId { get; set; } = Guid.NewGuid();
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string Username { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string TransactionType { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }

}