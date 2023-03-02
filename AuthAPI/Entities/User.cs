using System.Text.Json.Serialization;

namespace AuthAPI.Entities;
public class User
{
    public int Id { get; set; }    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    [JsonIgnore]  // stops password from being serialised
    public string Password { get; set; }
}

