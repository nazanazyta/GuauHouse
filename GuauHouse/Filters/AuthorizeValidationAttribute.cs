﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuauHouse.Filters
{
    public class AuthorizeValidationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user.Identity.IsAuthenticated == false)
            {
                context.Result = this.GetRedirectToRoute("Identity", "Login");
            }
            //else
            //{
            //    if (user.IsInRole("1"))
            //    {
            //        context.Result = this.GetRedirectToRoute("Users", "PerfilAdmin");
            //    }else if (user.IsInRole("3"))
            //    {
            //        context.Result = this.GetRedirectToRoute("Users", "PerfilEmpleado");
            //    }
            //}
            //RoleManager<IdentityRole> rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));
        }

        public RedirectToRouteResult GetRedirectToRoute(String controller, String action)
        {
            RouteValueDictionary ruta =
                new RouteValueDictionary(new
                {
                    controller = controller,
                    action = action
                });
            RedirectToRouteResult redirect = new RedirectToRouteResult(ruta);
            return redirect;
        }
    }
}