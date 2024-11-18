using System.Reflection;

namespace DAL.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Email { get; set; }
    public string HashPassword { get; set; }
    public string PhoneNumber { get; set; }
    public string AvatarImage { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public Guid GenderId { get; set; }
    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Patient? Patient { get; set; }
    public Doctor? Doctor { get; set; }
}
