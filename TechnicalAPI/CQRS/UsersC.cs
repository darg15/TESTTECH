using Amazon.Runtime.Internal;
using MediatR;
using TechnicalAPI.DTO;
using TechnicalAPI.Repo.User;

namespace TechnicalAPI.CQRS
{
    public class GetUserInfoQuery : IRequest <List<UserDto>> { }

    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserInfo();
        }
    }

}

