using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RedSocialMinijuegosCore.Models;
using RedSocialMinijuegosCore.Repositories;

namespace RedSocialMinijuegosCore.Controllers
{
    public class ValidadorController : Controller
    {
        IRepositoryMinijuegos repo;


        public ValidadorController(IRepositoryMinijuegos repo)
        {

            this.repo = repo; ;
        }

        // GET: Validacion

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>
                 Login(String usuario, String password)
        {
            //BUSCAMOS EL TOKEN PARA COMPROBAR LAS CREDENCIALES
            //DEL EMPLEADO
            String token = await this.repo.GetToken(usuario, password);
            //SI EL TOKEN ES NULL, NO TIENE CREDENCIALES
            if (token != null)
            {
                //SI TENEMOS TOKEN, TENEMOS EMPLEADO
                //POR LO QUE PODEMOS RECUPERARLO DEL METODO PERFILEMPLEADO
                Usuario usu = await
                    this.repo.BuscarUsuarioEmail(usuario,token);
                //CREAMOS AL USUARIO PARA EL ENTORNO MVC DE CORE
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                //ALMACENAMOS EL ID DE EMPLEADO
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier
                    , usu.IdUsuario.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, usu.Nombre));
                //GUARDAMOS TAMBIEN EL ROLE DEL EMPLEADO
                identity.AddClaim(new Claim(ClaimTypes.Role, usu.Roles));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme, principal
                    , new AuthenticationProperties
                    {
                        IsPersistent = true
                    ,//DEBERIAMOS DAR EL MISMO TIEMPO DE SESSION QUE TOKEN
                        ExpiresUtc = DateTime.Now.AddMinutes(20)
                    });
                //UNA VEZ QUE TENEMOS A NUESTRO EMPLEADO ALMACENADO
                //DEBEMOS ALMACENAR EL TOKEN EN SESSION PARA PODER REUTILIZARLO
                //EN OTROS METODOS DE LA APP
                HttpContext.Session.SetString("TOKEN", token);

                //REDIRECCIONAMOS A UNA PAGINA DE INICIO PROTEGIDA
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensaje = "Usuario/Password incorrectos";
                return View();
            }
        }





        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);

            if (HttpContext.Session.GetString("TOKEN") != null)
            {

                HttpContext.Session.SetString("TOKEN", "a");
                HttpContext.Session.Clear();
            }

            return RedirectToAction("Index", "Home");
        }


        // get de consulta
        public ActionResult NuevoRegistro()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> NuevoRegistro(String usuario, String email, String password, String password2)
        {
            Usuario ExistEmail =  await this.repo.BuscarUsuarioEmail(email, null);
            Usuario ExisteMote = await this.repo.BuscarUsuarioMote(usuario,null);
            if (password != password2)
            {
                ViewBag.men = "la contraseña no coincide";
                return View();



            }
            else if (ExistEmail != null)
            {
                ViewBag.men = "El email ya existe";
                return View();

            }
            else if (ExisteMote != null)
            {
                ViewBag.men = "El usuario ya existe";
                return View();
            }
            else
            {

                this.repo.NuevoUsuario(usuario, email, password);

                return RedirectToAction("Index", "Home");


            }



        }
    }
}