using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedSocialMinijuegosCore.Filter;

using RedSocialMinijuegosCore.Models;
using RedSocialMinijuegosCore.Repositories;

namespace RedSocialMinijuegosCore.Controllers
{
    [UsuarioAuthorizeAttribute]
    public class JuegosController : Controller
    {


        IRepositoryMinijuegos repo;


        public JuegosController(IRepositoryMinijuegos repo)
        {
            
            this.repo = repo; ;
        }
        // GET: Juegos
        public async Task<ActionResult> Index(String nombre)
        {
            String token = HttpContext.Session.GetString("TOKEN");
            Juego j = await this.repo.BuscarJuego(nombre,token);
            return View(j);
        }
        [HttpPost]
        public async Task<ActionResult> Index(int puntos, String nombre)
        {
            String token = HttpContext.Session.GetString("TOKEN");
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            this.repo.InsertarPuntuacion(puntos, nombre, id, token);
            Juego j = await this.repo.BuscarJuego(nombre,token);
            return View(j);

        }

        public ActionResult Chat()
        {
          
            return View();
        }


        public async Task<ActionResult> Perfil()
        {
            String token = HttpContext.Session.GetString("TOKEN");
            String user = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            Usuario usu = await this.repo.BuscarUsuarioMote(user, token);
            List<MostrarPerfil> perfil = await this.repo.GetMostrarPerfils(user, token);
            ViewBag.usario = usu;
            return View(perfil);
        }

    }
}