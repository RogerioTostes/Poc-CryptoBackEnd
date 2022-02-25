using Game.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Services.Repository
{
    public static class UserRepository
    {
        public static User Get(string username)
        {
            var users = new List<User>
            {
                new User { Nonce = 6666, PublicAddress = "2E6F9B0D5885B6010F9167787445617F553A735F", Role = "gamer", Username = "test" }
            };

            return users.FirstOrDefault(x => x.Username.Equals(username));
        }
    }
}
