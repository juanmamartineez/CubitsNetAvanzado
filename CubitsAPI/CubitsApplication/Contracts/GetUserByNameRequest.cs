using MediatR;

namespace CubitsApplication.Contracts
{
    public class GetUserByNameRequest : IRequest<GetUserByNameResponse>
    {
        public string? Name { get; set; }
    }
}