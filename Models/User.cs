using System.ComponentModel.DataAnnotations;

namespace PocketBook.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }
}