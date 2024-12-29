using TechnicalAPI.DTO;

namespace TechnicalAPI.Repo.User
{
    public interface IUserRepository
    {
       Task<List<UserDto>> GetUserInfo();
    }
}
