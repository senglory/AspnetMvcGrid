﻿using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace AspnetMvcGrid.Interfaces
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    [Table("AspNetUsers")]
    public class ApplicationUserIdentity : IdentityUser
    {
        public ApplicationUserIdentity() 
            : base()
        {

        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUserIdentity> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}