using AutoMapper;
using CubitsApplication.Contracts;
using CubitsApplication.Handlers;
using CubitsApplication.Models;
using CubitsDomain.Entities;
using CubitsDomain.Interfaces;
using Moq;
using Xunit;

namespace CubitsTests
{
    public class GetUserListHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IMapper> _mapper;

        private GetUserListHandler _handler;

        public GetUserListHandlerTests()
        {
            var userList = new List<User>
            {
                new User
                {
                    Name = "User1",
                    LastName = "User1",
                    Dni = 1,
                    Age = 1
                },
                new User
                {
                    Name = "User2",
                    LastName = "User2",
                    Dni = 2,
                    Age = 2
                }
            };

            var userDto = new UserDto
            {
                Name = "User",
                LastName = "User",
                Dni = 10,
                Age = 10
            };

            _userRepository = new Mock<IUserRepository>();
            _userRepository
                .Setup(r => r.GetList())
                .Returns(userList);

            _mapper = new Mock<IMapper>();
            _mapper
                .Setup(m => m.Map<UserDto>(It.IsAny<User>()))
                .Returns(userDto); ;

            _handler = new GetUserListHandler(_userRepository.Object, _mapper.Object);
        }

        [Fact]
        public async void ObtengoRequestValido_RetornoResponseValido()
        {
            var response = await _handler.Handle(new GetUserListRequest(), CancellationToken.None);

            Assert.NotNull(response);
            Assert.NotNull(response.UsersList);
        }
    }
}