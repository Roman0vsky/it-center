using ITCenterBack.Constants;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Utilities;
using ITCenterBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ITCenterBack.Controllers
{
    //to do
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountsService;
        private readonly IOptions<JwtConfigurationModel> _jwtConfig;

        public AccountController(IAccountService accountsService, IOptions<JwtConfigurationModel> jwtConfig)
        {
            _accountsService = accountsService;
            _jwtConfig = jwtConfig;
        }


        //[AllowAnonymous]
        //[HttpPost("[action]")]
        //public async Task<IActionResult> RegisterAsync([FromBody] RegistrationViewModel viewModel)
        //{
        //    var user = _mapper.Map<User>(viewModel);
        //    await _accountService.RegisterAsync(user, viewModel.Password);

        //    return Ok();
        //}

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel viewModel)
        {
            var token = await _accountsService.LoginAsync(viewModel.UserName, viewModel.Password, _jwtConfig);

            return Ok(token);
        }

        //[Authorize(Policy = AccountPolicies.DefaultRights, AuthenticationSchemes = "Identity.Application,Bearer")]
        //[HttpDelete("[action]")]
        //public async Task<IActionResult> DeleteAsync()
        //{
        //    await _accountService.DeleteAsync(Guid.Parse(_userId));

        //    return Ok();
        //}
    }
}
