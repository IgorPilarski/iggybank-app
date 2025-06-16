namespace iggybank_app.Models;

public class UserProfileRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string Address2 { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Zipcode  { get; set; }
}
