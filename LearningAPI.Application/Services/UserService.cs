using LearningAPI.Application.Interfaces.Services;
using LearningAPI.Application.RepositoryInterfaces;
using LearningAPI.Domain.Users;

namespace LearningAPI.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        private bool ValidateUserData(User user)
        {
            string[] prohibitedNames = [
                "Hitler",
                "Lenin",
                "Batman"
            ];

            const short ageLimit = 120;

            if (user.Age > ageLimit) return false;
            if (prohibitedNames.Where(x => user.Name.Contains(x)).Any()) return false;

            return true;
        }

        public bool CreateUser(User user)
        {
            var userIsValid = ValidateUserData(user);
            if (!userIsValid) return false;

            var userExists = GetUserByEmailAndPassword(user.Email, user.Password) != null;
            if (userExists) return false;

            return _repository.Create(user);
        }

        public bool DeleteUser(Guid id)
        {
            return _repository.Delete(id);
        }

        public User? GetUserByEmailAndPassword(string email, string password)
        {
            if (password.Length == 0) return null;

            return _repository.GetByEmailAndPassword(email, password);
        }

        public bool UpdateUser(User user, Guid id)
        {
            var userIsValid = ValidateUserData(user);
            if (!userIsValid) return false;

            return _repository.Update(user, id);
        }
    }
}
