﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Web.Services.Authorization
{
    public class CustomUserRequireClaim: IAuthorizationRequirement
    {
        public string ClaimType { get; }

        public CustomUserRequireClaim(string claimType) {

            this.ClaimType = claimType;
        
        }

    }
}
