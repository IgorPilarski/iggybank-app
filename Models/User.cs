public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public decimal Balance { get; set; }
    public UserProfile? Profile { get; set; }
}