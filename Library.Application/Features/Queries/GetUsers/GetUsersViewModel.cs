using Library.Core.Entities;

namespace Library.Application.Features.Queries.GetUsers
{
    public class GetUsersViewModel
    {
        public GetUsersViewModel(User user)
        {
            Email = user.Email;
            Name = user.FullName;
        }
        public string Email { get; private set; }
        public string Name { get; private set; }

    }
}
