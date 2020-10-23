using CorporateArena.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CorporateArena.Infrastructure
{
    //Extenting from AuthorizeAttribute or Attribute is upto user choice.
    //You can consider using AuthorizeAttribute if you want to use the predefined properties and functions from Authorize Attribute.
    public class AuthorizePermission : AuthorizeAttribute,IAuthorizationFilter
    {
        public string Permissions { get; set; } //Permission string to get from controller

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Validate if any permissions are passed when using attribute at controller or action level
            if (string.IsNullOrEmpty(Permissions))
            {
                //Validation cannot take place without any permissions so returning unauthorized
                context.Result = new UnauthorizedResult();
                return;
            }


            //Read claim from token
           

            var emailFromToken = context.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var _context = context.HttpContext.RequestServices.GetRequiredService<TContext>();


            // Get user,role and privileges with email from token
            var user = _context.AppUsers.Where(x => x.Email == emailFromToken).SingleOrDefault();

            
            var userRole =  _context.UserRoles.Where(x => x.UserID == user.ID).SingleOrDefault();

            if (userRole != null)
            {
                user.Role =  _context.Roles.Where(x => x.ID == userRole.RoleID).Single();
                var rolePrivileges = _context.RolePrivileges.Where(x => x.RoleID == user.RoleID).ToList();
                if (rolePrivileges != null)
                {
                    
                    foreach (var rp in rolePrivileges)
                    {
                        var priv = _context.Privileges.Where(x => x.ID == rp.PrivilegeID).Single();

                        if (priv.Name == Permissions)
                            return;

                    }
                }
            }


            // check if permission in attribute matches privilege value in db

            //if (user.Role.Privileges != null)
            //{
            //    foreach (var privilege in user.Role.Privileges)
            //    {
            //        if (privilege.Name == Permissions)
            //            return;
            //    }
            //}


            context.Result = new UnauthorizedResult();
            return;


            
        }
    }
}



