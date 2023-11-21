using AutoMapper;
using CubitsApplication.Contracts;
using CubitsApplication.Models;
using CubitsDomain.Interfaces;
using MediatR;

namespace CubitsApplication.Handlers
{
    public class GetUserListHandler : IRequestHandler<GetUserListRequest, GetUserListResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListHandler(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserListResponse> Handle(
            GetUserListRequest request, CancellationToken cancellationToken)
        {
            var response = new GetUserListResponse();

            await Task.Delay(0, cancellationToken);

            var userList = _userRepository.GetList();

            response.UsersList = userList
                .Select(x => _mapper.Map<UserDto>(x))
                .ToList();

            return response;
        }
    }
}