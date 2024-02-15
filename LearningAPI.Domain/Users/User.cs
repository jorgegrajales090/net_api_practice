using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningAPI.Domain.Users
{
    public class User
    {
        public Guid Id { get;set; }
        public required string Name { get;set; }
        public required string Email { get;set; }
        public required string Password { get;set; }
        public int? Age { get;set; }
    }
}
