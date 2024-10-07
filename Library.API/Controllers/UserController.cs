using Library.Core.Entities;
using Library.Infrastructure.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task CreateUser(User user)
        {
            await _userRepository.CreateAsync(user);
        }
    }
}
