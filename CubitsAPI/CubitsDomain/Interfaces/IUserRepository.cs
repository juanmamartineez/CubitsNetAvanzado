using CubitsDomain.Entities;

namespace CubitsDomain.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetList();

        List<User> GetByName(string name);
    }
}