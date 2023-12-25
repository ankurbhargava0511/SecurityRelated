using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreSecurity.Pages.Account
{
    public class GoogleModel : PageModel
    {
        public IActionResult OnGet(string ReturnUrl)
        {
            // await HttpContext.ChallengeAsync ("Google") -. use below provided by microsoft to involve chanllenge

            if (!Url.IsLocalUrl(ReturnUrl))
            {
                // throw
            }
            var props = new 
                AuthenticationProperties { 
                
                //RedirectUri = ReturnUrl
                RedirectUri = Url.Page("Callback"),
                Items= { {"uru", ReturnUrl} }
            };

            return Challenge(props ,"Google");
        }
    }
}
