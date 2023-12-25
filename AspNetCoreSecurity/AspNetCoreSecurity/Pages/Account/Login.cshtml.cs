using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AspNetCoreSecurity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public LoginModel()
        {
           
        }

        [BindProperty]
        public string UserName { get; set; }


        [BindProperty]
        public string Password { get; set; }


        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            //ReturnUrl = Request.QueryString.Value;


            if (!string.IsNullOrWhiteSpace(UserName) && UserName== Password)
            {
                var claims = new List<Claim>
                {
                    new Claim("sub", "123"),
                    new Claim("name", "TEST"),
                     new Claim("role", "Admin")
                };
                var ci = new ClaimsIdentity(claims, authenticationType: "pwd", nameType: "name", roleType: "Admin");
                var cp = new ClaimsPrincipal(ci);

                await HttpContext.SignInAsync(cp);
                return Redirect(ReturnUrl);
            }

            return Page();
        }
    }
}
