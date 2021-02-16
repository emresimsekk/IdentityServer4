using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyIdentityServer_IdentityApi.AuthServer.Models;
using UdemyIdentityServerIdentityApi.AuthServer.Models;
using static IdentityServer4.IdentityServerConstants;

namespace UdemyIdentityServerIdentityApi.AuthServer.Controller
{
    [Route("api/[controller]/[action]")]
    [Authorize(LocalApi.PolicyName)]
    [ApiController]
  
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
     
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSaveViewModel userSaveViewModel)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.UserName = userSaveViewModel.Username;
            applicationUser.Email = userSaveViewModel.Email;
            applicationUser.City = userSaveViewModel.City;

            var result = await _userManager.CreateAsync(applicationUser, userSaveViewModel.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description)); ;
            }

            return Ok("Üye Başarıyla Kaydedildi");
        }

    }
}
