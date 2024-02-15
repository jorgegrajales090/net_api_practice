using LearningAPI.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAPI.Application.RepositoryInterfaces
{
    public interface IUserRepository
    {
        User? GetByEmailAndPassword(string email, string password);
        bool Create(User user);
        bool Update(User user, Guid userId);
        bool Delete(Guid userId);
    }
}
