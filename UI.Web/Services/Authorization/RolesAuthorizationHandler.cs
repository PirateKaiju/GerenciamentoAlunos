using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Web.Services.Authorization
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        private IUsuarioAppService _usuarioAppService;
        public RolesAuthorizationHandler(IUsuarioAppService usuarioAppService): base() {
            this._usuarioAppService = usuarioAppService; //if we use the role from context, i dont think this is needed...
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated) {

                context.Fail();
                return Task.CompletedTask;

            }

            bool validRole = false;

            if (requirement.AllowedRoles == null || requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else 
            {
                var claims = context.User.Claims; //TODO: MAKE VAR INTO TYPED 
                var userName = claims.FirstOrDefault(c => c.Type == "UserName").Value;
                var roles = requirement.AllowedRoles;

                Console.WriteLine(this._usuarioAppService);

                validRole = roles.Contains(this._usuarioAppService.ReadByName(userName).role); //this might change
                
            }

            if (validRole)
            {

                context.Succeed(requirement);

            }
            else 
            {
                context.Fail();
            }

            return Task.CompletedTask;

        }
    }
}
