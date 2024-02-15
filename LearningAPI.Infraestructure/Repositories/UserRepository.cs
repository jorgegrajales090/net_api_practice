using LearningAPI.Application.RepositoryInterfaces;
using LearningAPI.Data;
using LearningAPI.Domain.Users;
using LearningAPI.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAPI.Infraestructure.Users
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }

        public bool Delete(Guid userId)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (existingUser == null)
            {
                return false;
            }

            _context.Users.Remove(existingUser);
            _context.SaveChanges();

            return true;
        }

        public User? GetByEmailAndPassword(string email, string password)
        {
           var userfromDb = _context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
           return userfromDb;
        }

        public bool Update(User userData, Guid userId)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.Name = userData.Name;
            existingUser.Age = userData.Age;
            existingUser.Email = userData.Email;
            existingUser.Password = userData.Password;

            _context.SaveChanges();

            return true;
        }
    }
}
