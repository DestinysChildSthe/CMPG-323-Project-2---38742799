﻿using Microsoft.AspNetCore.Identity;
namespace ApiProject.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ApplicationDbContext Context { get; set; }
    }
}
