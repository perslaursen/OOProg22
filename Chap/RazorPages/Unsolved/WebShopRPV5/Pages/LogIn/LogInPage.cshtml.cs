using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
#nullable disable

namespace WebShopRP.Pages.LogIn
{
    public class LogInPageModel : PageModel
    {
        private IUserDataService _userDataService;

        public static User LoggedInUser { get; set; }

        [BindProperty]
        public string UserName { get; set; }


        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public LogInPageModel(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<IActionResult> OnPost()
        {
            LoggedInUser = _userDataService.VerifyUser(UserName, Password);

            if (LoggedInUser == null)
            {
                Message = "Invalid attempt";
                return Page();
            }

            // Log in with identity
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                BuildClaimsPrincipal(LoggedInUser));

            return RedirectToPage("/Index");
        }

        private ClaimsPrincipal BuildClaimsPrincipal(User user)
        {
            // Build Claims
            List<Claim> claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, user.UserName) 
            };

            if (user.UserName == "admin")
                claims.Add(new Claim(ClaimTypes.Role, "admin"));

            // Create claims-based identity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, 
                CookieAuthenticationDefaults.AuthenticationScheme);

            // Create and return principal
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
