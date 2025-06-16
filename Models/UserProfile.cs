using System.ComponentModel.DataAnnotations;

public class UserProfile
{
    [Key]
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Zipcode  { get; set; }    
    public User User { get; set; } = null!;

}