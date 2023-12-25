using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AspNetCoreSecurity.Pages.Account
{
    [AllowAnonymous]
    public class CallbackModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // read the outcome
            var result = await HttpContext.AuthenticateAsync("temp");

            if (!result.Succeeded)
            {

            }

            var extUser = result.Principal;
            var sub = extUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            // run the logic

            // sign in users 
            // change clain from extremal claim
            var claims = new List<Claim>
                {
                    new Claim("sub", "123"),
                    new Claim("name", "TEST"),
                     new Claim("role", "Admin")
                };
            var ci = new ClaimsIdentity(claims, authenticationType: "pwd", nameType: "name", roleType: "Admin");
            var cp = new ClaimsPrincipal(ci);

            await HttpContext.SignInAsync(cp);
            var uru = result.Properties.Items["uru"];

            return Redirect(uru);



        }
    }
}
