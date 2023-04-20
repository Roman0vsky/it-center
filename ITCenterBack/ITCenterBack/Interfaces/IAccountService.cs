using ITCenterBack.Models;
using ITCenterBack.Utilities;
using Microsoft.Extensions.Options;

namespace ITCenterBack.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(User user, string password, bool requirePassword = true);
        Task DeleteAsync(long id);
        Task<string> LoginAsync(string email, string password, IOptions<JwtConfigurationModel> securityConfig);
        //Task ChangeRoleAsync(Guid userId, string role);
        //Task<PagedList<User>> GetAllAsync(PageParametersViewModel pageParams);
    }
}
