using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedSocialMinijuegosCore.Models;
using RedSocialMinijuegosCore.Repositories;

namespace RedSocialMinijuegosCore.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryMinijuegos repo;
        public HomeController(IRepositoryMinijuegos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> index()
        {
            List<Juego> juegos = await this.repo.GetJuegos();
            return View(juegos);
        }
        [HttpPost]
        public async Task<ActionResult> index(int estrellas, String nombre)
        {
            this.repo.Puntuacion(estrellas, nombre);
            List<Juego> juegos = await this.repo.GetJuegos();
            return View(juegos);
        }

        public IActionResult categories()
        {
            

            return View();
        }

        public IActionResult contact()
        {
            

            return View();
        }

        public async Task<IActionResult> games(int? id)
        {

            if (id != null)
            {
                List<Juego> j = this.repo.BuscarJuegoCategoria((int)id);
                return View(j);
            }
            else
            {
                List<Juego> j = await this.repo.GetJuegos();
                return View(j);
            }

           
        }

        [HttpPost]
        public async Task<IActionResult> games(int? id, int? estrellas, String nombre)
        {
            if (estrellas != null)
            {
                this.repo.Puntuacion((int)estrellas, nombre);
            }

            if (id != null)
            {
                List<Juego> j = this.repo.BuscarJuegoCategoria((int)id);
                return View(j);
            }
            else
            {
                List<Juego> j = await this.repo.GetJuegos();
                return View(j);
            }



        }

        public IActionResult community()
        {
            return View();
        }
        public IActionResult blog()
        {
            return View();
        }
       
        // GET: Home
       
       
     



       
        public async Task<ActionResult> Categorias()
        {
            List<Categoria> categoria = await this.repo.Categorias();
            return PartialView(categoria);
        }

        //public ActionResult _Navegacion()
        //{
        //    Usuario usu = HttpContext.User.Claims.ToList();
        //    if (HttpContext.User is Usuario usu)
        //    {
        //        Usuario usuario = this.repo.BuscarUsuario(usu.IdUsuario);
        //        return PartialView(usuario);
        //    }

        //    return PartialView(); 
        //}

        //public ActionResult _reslayout()
        //{
        //    String usu = HttpContext.User.Identity.Name;
        //    if (usu != null)
        //    {
        //        Usuario usuario = this.repo.BuscarUsuario(usu.IdUsuario);
        //        return PartialView(usuario);
        //    }

        //    return PartialView(); 
        //}

        public async Task<ActionResult> Ranking(int? clave , String juego)
        {
            if (clave == null)
            {
                clave = 0;
            }
          
            int numregistros = 0;
            List<Ranking> usuarios;
            if (juego != null && juego!= "Elige el juego") { 


             usuarios = await
              this.repo.GetTodosJuego(clave.GetValueOrDefault(), numregistros, juego);
                ViewBag.juego = juego;
            }
            else 
            {
                clave = 0;
                usuarios =  await this.repo.GetTodos(clave.GetValueOrDefault(),  numregistros);
                ViewBag.juego = "a";
            }
            ViewBag.Registros = numregistros;
            List<string> listaJuegos =  await this.repo.Nombrejuego();
            ViewBag.nombrejuegos = listaJuegos;
           
            return View(usuarios);


            
        }
       

    }
}
