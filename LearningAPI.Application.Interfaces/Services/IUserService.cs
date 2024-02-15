using LearningAPI.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAPI.Application.Interfaces.Services
{
    public interface IUserService
    {
        User? GetUserByEmailAndPassword(string email, string password);

        bool CreateUser(User user);

        bool UpdateUser(User user, Guid id);

        bool DeleteUser(Guid id);
    }
}
