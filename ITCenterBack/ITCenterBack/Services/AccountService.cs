using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ITCenterBack.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        //private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AccountService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        private List<Claim> GetClaims(User user, IList<string> userRoles)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken CreateSecurityToken(IOptions<JwtConfigurationModel> securityConfig, List<Claim> claims)
        {
            var symSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityConfig.Value.Key));
            return new(
                issuer: securityConfig.Value.Issuer,
                audience: securityConfig.Value.Audience,
                notBefore: DateTime.UtcNow,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(securityConfig.Value.LifetimeHours),
                signingCredentials: new SigningCredentials(symSecurityKey, SecurityAlgorithms.HmacSha256));
        }

        public async Task<string> LoginAsync(string userName, string password, IOptions<JwtConfigurationModel> securityConfig)
        {
            var user = await _userManager.FindByNameAsync(userName);
            //if (user is null)
            //{
            //    throw new Exception($"User was not found");
            //}

            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                return "";
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var userClaims = GetClaims(user, userRoles);
            var token = CreateSecurityToken(securityConfig, userClaims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RegisterAsync(User user, string password, bool requirePassword = true)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            //if (existingUser is not null)
            //{
            //    throw new Exception("There is already a user with this email");
            //}

            var result = requirePassword
                ? await _userManager.CreateAsync(user, password)
                : await _userManager.CreateAsync(user);

            //if (!result.Succeeded)
            //{
            //    throw new Exception(result.Errors.First<IdentityError>().Description);
            //}

            result = await _userManager.AddToRoleAsync(user, AccountRoles.Administrator);
        }

        public async Task DeleteAsync(long id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            //if (user is null)
            //{
            //    throw new Exception($"User with provided id [{id}] was not found");
            //}

            IList<UserLoginInfo> loginInfos;
            if ((loginInfos = await _userManager.GetLoginsAsync(user)).Any())
            {
                foreach (var item in loginInfos)
                    await _userManager.RemoveLoginAsync(user, item.LoginProvider, item.ProviderKey);
            }

            var result = await _userManager.DeleteAsync(user);
            //if (!result.Succeeded)
            //{
            //    var error = result.Errors.First<IdentityError>().Description;
            //    throw new Exception(error);
            //}
        }
    }
}
