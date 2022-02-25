using Dapper;
using Game.Services.Interface;
using Game.Services.Models;
using Microsoft.Data.Sqlite;

namespace Game.Services.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public UsersRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Insert(User user)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@publicAddress", user.PublicAddress);
            parameters.Add("@nonce", user.PublicAddress);
            await connection.ExecuteAsync("", parameters);

        }

        public async Task<User> Get(string publicAddress)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@publicAddress", publicAddress);
            var user = await connection.QueryAsync<User>("", parameters);
            return (User)user;
        }
    }
}
