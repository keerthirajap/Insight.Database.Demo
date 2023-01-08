using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace Insight.Database.Demo.Part2.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnection _sqlConnection;

        public UserRepository()
        {
            SqlInsightDbProvider.RegisterProvider(); // Always better to have while using Insight.Database
            _sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Insight.Database.Demo.Part2;Persist Security Info=true;Integrated Security=true;");
        }

        public async Task<string> GetUserEmailAddressAsync(long userId)
        {
            string emailAddress = await _sqlConnection.ExecuteScalarAsync<string>("[dbo].[P_GetUserEmailAddress]", new { UserId = userId });

            return emailAddress;
        }
        public async Task<string> GetUserEmailAddressAsync_V1(long userId)
        {
            string emailAddress = await _sqlConnection
                                        .ExecuteScalarSqlAsync<string>(@"SELECT [EmailAddress] FROM [dbo].[User]
	                                                                    WHERE UserId = @UserId", 
                                                                new { UserId = userId });

            return emailAddress;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _sqlConnection.QueryAsync<User>("[dbo].[P_GetAllUsers]");
            return users.ToList();
        }

        public async Task<List<User>> GetAllUsersAsync_V1()
        {
            var users = await _sqlConnection.QuerySqlAsync<User>("SELECT * FROM [dbo].[User]");
            return users.ToList();
        }
    }
}
