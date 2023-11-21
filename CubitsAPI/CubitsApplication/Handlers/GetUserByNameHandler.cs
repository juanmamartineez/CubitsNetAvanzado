using AutoMapper;
using CubitsApplication.Contracts;
using CubitsApplication.Models;
using CubitsDomain.Interfaces;
using FluentValidation;
using MediatR;

namespace CubitsApplication.Handlers
{
    public class GetUserByNameHandler : IRequestHandler<GetUserByNameRequest, GetUserByNameResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetUserByNameRequest> _validator;

        public GetUserByNameHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IValidator<GetUserByNameRequest> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetUserByNameResponse> Handle(
            GetUserByNameRequest request, CancellationToken cancellationToken)
        {
            var response = new GetUserByNameResponse();

            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                throw new Exception();
            }

            await Task.Delay(0, cancellationToken);

            var user = _userRepository.GetByName(request.Name);

            response.User = user
                .Select(x => _mapper.Map<UserDto>(x))
                .ToList();

            return response;
        }
    }
}