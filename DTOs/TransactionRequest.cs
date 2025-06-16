namespace iggybank_app.Models;

public class TransactionRequest
{
    public string Title { get; set; } = null!;
    public decimal Amount { get; set; }
}