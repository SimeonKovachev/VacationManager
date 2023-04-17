using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using VacationManager.Entity;

namespace VacationManager.Services
{
    public class HMSSignInManager : SignInManager<VacationUser, string>
    {
        public HMSSignInManager(HMSUserManager userManager, IAuthenticationManager authenticationManager)
           : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(VacationUser user)
        {
            return user.GenerateUserIdentityAsync((HMSUserManager)UserManager);
        }

        public static HMSSignInManager Create(IdentityFactoryOptions<HMSSignInManager> options, IOwinContext context)
        {
            return new HMSSignInManager(context.GetUserManager<HMSUserManager>(), context.Authentication);
        }
    }
}
