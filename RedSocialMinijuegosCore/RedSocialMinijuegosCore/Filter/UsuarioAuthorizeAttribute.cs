﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Filter
{
    public class UsuarioAuthorizeAttribute : AuthorizeAttribute
        , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //SOLO QUEREMOS QUE ENTREN LOS EMPLEADOS
            //NO TENDREMOS VALIDACION CON ROLES
            var usuario = context.HttpContext.User;
            if (usuario.Identity.IsAuthenticated == false)
            {
                //SI NO ESTA VALIDADO, LO ENVIAMOS A LOGIN
                //CONTROLLER, ACTION
                RouteValueDictionary rutalogin =
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Validador"
                            ,
                            action = "Login"
                        });
                RedirectToRouteResult action =
                    new RedirectToRouteResult(rutalogin);
                context.Result = action;
            }
        }

    }
}
