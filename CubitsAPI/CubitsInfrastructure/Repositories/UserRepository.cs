using CubitsDomain.Entities;
using CubitsDomain.Interfaces;
using CubitsInfrastructure.DataBase;

namespace CubitsInfrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {  
        private readonly SqlServerContext _context;

        public UserRepository(
            SqlServerContext context)
        {
            _context = context;
        }

        public List<User> GetList()
        {
            var userList = _context
                .Set<User>()
                .ToList();

            return userList;    
        }

        public List<User> GetByName(string name)
        {
            var user = _context
                .Set<User>()
                .Where(x => x.Name == name)
                .ToList();

            return user;
        }
    }
}