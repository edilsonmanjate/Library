using Library.Core.Enums;

namespace Library.Core.Entities;
public class User : BaseEntity
{
    public User(string fullName, string displayName, DateTime birthDate, string email)
    {
        FullName = fullName;
        DisplayName = displayName;
        BirthDate = birthDate;
        Email = email;
        Status = UserStatus.Active;
        //Events.Add(new UserCreated(Email, DisplayName));
    }

    public string FullName { get; private set; }
    public string DisplayName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string? Header { get; private set; }
    public string? Description { get; private set; }
    public string Email { get; private set; }
    public UserStatus Status { get; private set; }

    public void Update(
        string displayName,
        string header,
        string description
    )
    {
        DisplayName = displayName;
        Header = header;
        Description = description;
    }
}
