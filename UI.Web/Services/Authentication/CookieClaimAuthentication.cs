using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UI.Web.Services.Authentication
{
    public static class CookieClaimAuthentication
    {

        public static List<Claim> makeUserClaims(Usuario usuario) {


            return new List<Claim>()
            {

                new Claim("UserName", usuario.username),
                
                new Claim(ClaimTypes.Role, usuario.role),

            };

        }

    }
}
