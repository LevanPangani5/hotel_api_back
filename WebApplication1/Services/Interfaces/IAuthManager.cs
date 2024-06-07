using WebApplication1.Data.DTO;

namespace WebApplication1.Services.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDto userDto);
        Task<string> CreateToken();
    }
}
