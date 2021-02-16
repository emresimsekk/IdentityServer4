using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using UdemyIdentityServer.Client1.Models;
using UdemyIdentityServer.Client1.Services;

namespace UdemyIdentityServer.Client1.Controllers
{
    public class LoginController : Controller
    {
        IConfiguration _configuration;
        private readonly  IApiResourceHttpClient _apiResourceHttpClient;

        public LoginController(IConfiguration configuration, IApiResourceHttpClient apiResourceHttpClient)
        {
            _configuration = configuration;
            _apiResourceHttpClient = apiResourceHttpClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //ClientResourceOwner
        public async  Task< IActionResult> Index(LoginViewModel loginViewModel)
        {
            var client = new HttpClient();
            //request endpoint
            var disco = await client.GetDiscoveryDocumentAsync(_configuration["AuthServerUri"]);
            if(disco.IsError)
            {
                //hata log
            }
            var password = new PasswordTokenRequest();
            password.Address = disco.TokenEndpoint;
            password.UserName = loginViewModel.Email;
            password.Password = loginViewModel.Password;
            password.ClientId = _configuration["ClientResourceOwner:ClientId"];
            password.ClientSecret= _configuration["ClientResourceOwner:ClientSecret"];

            var token = await client.RequestPasswordTokenAsync(password);
            if (token.IsError)
            {
                ModelState.AddModelError("", "Email veya Şifreniz Yanlış");
                return View();
            }

            //Kullanıcı bilgileri
            var userInfoRequest = new UserInfoRequest();
            userInfoRequest.Token = token.AccessToken;
            userInfoRequest.Address = disco.UserInfoEndpoint;
            var userInfo=await client.GetUserInfoAsync(userInfoRequest);
            if(userInfo.IsError)
            {
                // log hata
            }
            //claims
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfo.Claims, CookieAuthenticationDefaults.AuthenticationScheme,"name","role");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            //property
            var authProperties = new AuthenticationProperties();
            authProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = token.AccessToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = token.RefreshToken },
                new AuthenticationToken { Name = OpenIdConnectParameterNames.ExpiresIn, Value = DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("o", CultureInfo.InvariantCulture) },
            });

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,authProperties);


            //HttpContext.SignInAsync(claimsPrincipal);

            return RedirectToAction("Index", "User");
        }

        // Son ıdentityServer
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSaveViewModel userSaveViewModel)
        {
            if (!ModelState.IsValid) return View();

            var result = await _apiResourceHttpClient.SaveUserViewModel(userSaveViewModel);
            if (result!=null)
            {
                result.ForEach(error =>
                {
                    ModelState.AddModelError("", error);
                   
                });
                return View();

            }
           
            return RedirectToAction("Index");
        }
    }
}
