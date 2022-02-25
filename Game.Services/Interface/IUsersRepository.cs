using Game.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Services.Interface
{
    public interface IUsersRepository
    {
        Task<User> Get(string publicAddress);
        Task Insert(User user);       
    }
}
