using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedSocialMinijuegosCore.Filter;
using RedSocialMinijuegosCore.Models;
using RedSocialMinijuegosCore.Providers;
using RedSocialMinijuegosCore.Repositories;

namespace RedSocialMinijuegosCore.Controllers
{
    [UsuarioAuthorizeAttribute(Roles = "Admin")]
    public class AdministracionController : Controller
    {
        PathProvider pathprovider;

        IRepositoryMinijuegos repo;
        public AdministracionController(IRepositoryMinijuegos repo, PathProvider pathprovider)
        {
            this.repo = repo;
            this.pathprovider = pathprovider;
        }

        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Juegos()
        {
            List<Juego> juegos = await this.repo.GetJuegos();
            return View(juegos);
        }
        public async Task<ActionResult> EditJuegos(String id)
        {
            Juego j = await this.repo.BuscarJuego(id, null);

            return View(j);
        }
        [HttpPost]

        public async Task<ActionResult> EditJuegos(Juego j, IFormFile imagen)
        {

            String filename = imagen.FileName;
            String path = this.pathprovider.MapPath(filename, Folders.Uploads);
            if (filename.EndsWith("jpg"))
            {
                path = this.pathprovider.MapPath(filename, Folders.Images);
            }

            //String path =
            //    Path.Combine(rootpath, "uploads" , filename);
            //RENOMBRAR FICHERO
            //System.IO.File.Move("old", "new");
            //SUBIMOS EL FICHERO A DICHA RUTA, SE REALIZA CON
            //STREAM
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }
            ViewData["MENSAJE"] = "Ruta: "
                + path;
            String t = HttpContext.User.FindFirst(ClaimTypes.UserData).Value;
            await this.repo.ModificarJuego(j,t);
            List<Juego> juegos = await this.repo.GetJuegos();
            return View("Juegos", juegos);


        }
        public async Task<ActionResult> CreateJuegos()
        {
            ViewBag.cate = await this.repo.Categorias();
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> CreateJuegos(Juego j, IFormFile imagen)
        {
            String filename = imagen.FileName;
            String path = this.pathprovider.MapPath(filename, Folders.Uploads);
            if (filename.EndsWith("jpg"))
            {
                path = this.pathprovider.MapPath(filename, Folders.Images);
            }

            //String path =
            //    Path.Combine(rootpath, "uploads" , filename);
            //RENOMBRAR FICHERO
            //System.IO.File.Move("old", "new");
            //SUBIMOS EL FICHERO A DICHA RUTA, SE REALIZA CON
            //STREAM
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }
            ViewBag.Mensaje = "Fichero subido";
            String token = HttpContext.Session.GetString("TOKEN");
            j.Imagen = filename;
            await this.repo.CrearJuego(j,token);
            List<Juego> juegos = await this.repo.GetJuegos();
            return View("Juegos", juegos);
        }

        public async Task<ActionResult> BorrarJuegos(String id)
        {
            String token = HttpContext.Session.GetString("TOKEN");
            await   this.repo.EliminarJuego(id,token);
            List<Juego> juegos = await this.repo.GetJuegos();
            return View("Juegos", juegos);
        }

        public async Task<ActionResult> Categorias()
        {
            List<Categoria> categorias = await this.repo.Categorias();

            return View(categorias);
        }
        public async Task<ActionResult> EditCategoria(int id)
        {

            Categoria j =  await this.repo.BuscarCategoria(id);

            return View(j);
        }
        [HttpPost]

        public async Task<ActionResult> EditCategoria(Categoria j)
        {

            String token = HttpContext.Session.GetString("TOKEN");
            await this.repo.ModificarCategoria(j,token);
            List<Categoria> categorias = await this.repo.Categorias();
            return View("Categorias", categorias);


        }
        public ActionResult CreateCategoria()
        {

            return View();
        }
        [HttpPost]

        public async Task<ActionResult> CreateCategoria(Categoria j)
        {
            String token = HttpContext.Session.GetString("TOKEN");
            await this.repo.CrearCategoria(j,token);
            List<Categoria> categorias = await this.repo.Categorias();
            return View("Categorias", categorias);
        }

        public async Task<ActionResult> BorrarCategoria(int id)
        {
            String token = HttpContext.Session.GetString("TOKEN");
            await this.repo.EliminarCategoria(id,token);
            List<Categoria> categorias = await this.repo.Categorias();
            return View("Categorias", categorias);
        }



        public async Task<ActionResult> Usuarios()
        {
            List<Usuario> usu = await this.repo.GetUsuarios();

            return View(usu);
        }

        public async Task<ActionResult> BorrarUsuarios(int id)
        {
            String token = HttpContext.Session.GetString("TOKEN");
            await this.repo.BorrarUsuarios(id,token);
            List<Usuario> usu = await this.repo.GetUsuarios();
            return View("Usuarios", usu);
        }
        public async Task<ActionResult> EditarUsuarios(int id)
        {
            Usuario u = await this.repo.BuscarUsuario(id);

            return View(u);
        }
        [HttpPost]
        public async Task<ActionResult> EditarUsuarios(Usuario u)
        {
            String token = HttpContext.Session.GetString("TOKEN");
            await this.repo.EditarUsuarios(u,token);
            List<Usuario> usu = await this.repo.GetUsuarios();
            return View("Usuarios", usu);
        }

    }
}