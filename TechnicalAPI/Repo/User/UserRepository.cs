using Microsoft.AspNetCore.Mvc;
using TechnicalAPI.Connection;
using TechnicalAPI.DTO;

namespace TechnicalAPI.Repo.User
{
    public class UserRepository : IUserRepository
    {
        public Task <List<UserDto>> GetUserInfo()
        {
            List<UserDto> user = new List<UserDto>();
            try
            {
                using (ConnectionDB con = new ConnectionDB())
                {
                    user = con.ReadL<UserDto>("GetUserInfo", null);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Task.FromResult(user);
        }

    }
}
