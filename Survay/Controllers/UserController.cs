using System.Data;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Survay.Models.database;
using Survay.Models.DTO;

namespace Survay.Controllers
{
    public class UserController : Controller
    {
        SignInManager<User> SignInManager;
        UserManager<User> UserManager;
        ILogger<UserController> _logger;
        public RoleManager<IdentityRole> RoleManager { get; }

		public UserController(UserManager<User> UserManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, ILogger<UserController> logger)
		{
			this.UserManager = UserManager;
			SignInManager = signInManager;
			RoleManager = roleManager;
			_logger = logger;
		}

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }





        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(UserRegestertionDTO viewUser)
        {
            if (ModelState.IsValid)
            {



                var IsEmailUsed = await UserManager.FindByEmailAsync(viewUser.Email);
                var IsUsernameUser = await UserManager.FindByEmailAsync(viewUser.UserName);
                if (IsEmailUsed == null && IsUsernameUser == null)

                {
                    User RegUser = new User();
                    RegUser.Email = viewUser.Email;
                    RegUser.UserName = viewUser.UserName;
                    RegUser.PasswordHash = viewUser.Password;
                    await UserManager.CreateAsync(RegUser, viewUser.Password);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    if (IsUsernameUser == null)
                    {
                        ModelState.AddModelError("Password", "user name must be uniqe");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Email name must be uniqe");
                    }
                }
            }
            return View("Register");
        }

        #endregion

        #region Login

        [HttpGet]
        public async Task<IActionResult> login()
        {
            var login = new UserLoginDTO()
            {
                Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync(),
            };
            return View(login);


        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> login(UserLoginDTO login)
        {


            _logger.LogInformation("{user}  is logining", login.Username);

            if (ModelState.IsValid)
            {
                User user = await UserManager.FindByNameAsync(login.Username);
                if (user != null)
                {
                    bool isOK = await UserManager.CheckPasswordAsync(user, login.Password);
                    if (isOK)
                    {
                        await SignInManager.SignInAsync(user, login.RememberMe);
                        _logger.LogInformation("{user} succsesful", login.Username);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        _logger.LogError("{username} invild passwoerd", login.Username);
                        ModelState.AddModelError("", "invild passwoerd");
                    }
                }
                else
                {
                    _logger.LogError("invild username");
                    ModelState.AddModelError("", "invild username");

                }
            }
            login.Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync();


            return View(login);

        }
        #endregion

        #region Logout
        public IActionResult logout()
        {
            SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Extenal Login
        public IActionResult ExternalLogin(string provider, string returnUrl = "")
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "User", new { ReturnUrl = returnUrl });

            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }
        #endregion

        #region ExternalLoginCallback
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "", string remoteError = "")
        {

            var loginVM = new UserLoginDTO()
            {
                Schemes = await SignInManager.GetExternalAuthenticationSchemesAsync()
            };

            if (!string.IsNullOrEmpty(remoteError))
            {
                ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
                return View("Login", loginVM);
            }

            //Get login info
            var info = await SignInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
                return View("Login", loginVM);
            }

            var signInResult = await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var user = await UserManager.FindByEmailAsync(userEmail);

                    if (user == null)
                    {
                        user = new User()
                        {
                            UserName = userEmail,
                            Email = userEmail,
                            EmailConfirmed = true
                        };

                        await UserManager.CreateAsync(user);
                    }

                    await SignInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", $"Something went wrong");
            return View("Login", loginVM);
        }
        #endregion

    }

}

