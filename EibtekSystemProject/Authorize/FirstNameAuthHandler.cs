
using BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EibtekSystemProject.Authorize
{
    public class FirstNameAuthHandler : AuthorizationHandler<FirstNameAuthRequirement>
    {
        public UserManager<ApplicationUser> _userManager { get; set; }
        public EibtekSystemDbContext _db { get; set; }

        public FirstNameAuthHandler(UserManager<ApplicationUser> userManager, EibtekSystemDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FirstNameAuthRequirement requirement)
        {
            string userid = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _db.Users.FirstOrDefault(u => u.Id == userid);
            var claims = Task.Run(async () => await _userManager.GetClaimsAsync(user)).Result;
            var claim = claims.FirstOrDefault(c => c.Type == "Name");
            if (claim != null)
            {
                if (claim.Value.ToLower().Contains(requirement.Name.ToLower()))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }
    }
}
