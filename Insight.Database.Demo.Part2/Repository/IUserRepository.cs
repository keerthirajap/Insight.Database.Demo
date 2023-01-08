using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insight.Database.Demo.Part2.Repository
{
    public interface IUserRepository
    {
        Task<string> GetUserEmailAddressAsync(long userId);

        Task<string> GetUserEmailAddressAsync_V1(long userId);

        Task<List<User>> GetAllUsersAsync();

        Task<List<User>> GetAllUsersAsync_V1();
    }
}
