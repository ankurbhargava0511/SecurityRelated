using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
           
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string user="";
        }
    }
}
