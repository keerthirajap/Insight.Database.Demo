using FizzWare.NBuilder;
using Insight.Database.Demo.Part2.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insight.Database.Demo.Part2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetUserEmailAddress")]
        public async Task<IActionResult> GetUserEmailAddressAsync(long userId)
        {
            string emailAddress = await this._userRepository.GetUserEmailAddressAsync(userId);

            return Ok(emailAddress);
        }

        [HttpGet]
        [Route("GetUserEmailAddress_V1")]
        public async Task<IActionResult> GetUserEmailAddressAsync_V1(long userId)
        {
            string emailAddress = await this._userRepository.GetUserEmailAddressAsync_V1(userId);

            return Ok(emailAddress);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await this._userRepository.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("GetAllUsers_V1")]
        public async Task<IActionResult> GetAllUsersAsync_V1()
        {
            var users = await this._userRepository.GetAllUsersAsync_V1();

            return Ok(users);
        }
    }
}
