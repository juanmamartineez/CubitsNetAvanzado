using CubitsApplication.Models;

namespace CubitsApplication.Contracts
{
    public class GetUserListResponse
    {
        public List<UserDto>? UsersList { get; set; }
    }
}