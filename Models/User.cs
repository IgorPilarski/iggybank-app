using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }

    [Column("username")]
    public string Username { get; set; } = null!;

    [Column("password")]
    public string Password { get; set; } = null!;
    [Column("balance")]
    public decimal Balance { get; set; } = 0;
}