using CubitsApplication.Models;

namespace CubitsApplication.Contracts
{
    public class GetUserByNameResponse
    {
        public List<UserDto>? User { get; set; }
    }
}