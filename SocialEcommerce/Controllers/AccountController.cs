using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SocialEcommerce.Data.Entities;
using SocialEcommerce.Repository.ViewModels;
using SocialEcommerce.Shared.Utilities;

namespace SocialEcommerce.WebAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        //private readonly Utility _utility;
        
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger
            //,Utility utility
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_utility = utility;
        }

        [Route("register")]
        [HttpPost]
        public async Task<bool> Register(RegisterDto input)
        {   
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = input.Email, Email = input.Email , PhoneNumber =input.PhoneNumber};
                var result = await _userManager.CreateAsync(user, input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    if (!string.IsNullOrEmpty(code))
                    {
                        string emailBody = Utility.GetEmailTemplate(@"Registration", @"ConfirmEmailTemplate.html");
                        var callbackUrl = "https://localhost:4200/account/confirm-email?userId=" + user.Id + "&confirmationCode=" + code;
                        emailBody = emailBody.Replace("{UserName}", user.UserName);
                        emailBody = emailBody.Replace("{CallBackUrl}", callbackUrl);
                        EmailService.Send(@"Email confirmation mail from Divide & conquer Social Ecommerce", emailBody, user.Email);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return false;
        }
    }
    
}