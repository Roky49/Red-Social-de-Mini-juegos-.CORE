using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RedSocialMinijuegosCore.Models;
using RedSocialMinijuegosCore.Repositories;

namespace RedSocialMinijuegosCore.Controllers
{
    //[AutorizacionUsuarios(Roles = "Admin")]
    public class AdministracionController : Controller
    {
        IRepositoryMinijuegos repo;
        public AdministracionController(IRepositoryMinijuegos repo)
        {
            this.repo = repo;
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
        //public async Task<ActionResult> EditJuegos(String id)
        //{
        //    Juego j = await this.repo.BuscarJuego(id);

        //    return View(j);
        //}
        //[HttpPost]

        //public async Task<ActionResult> EditJuegos(Juego j, HttpPostedFileBase imagen)
        //{

        //    if (imagen != null)
        //    {


        //        imagen.SaveAs(Server.MapPath("~/Imagenes/" + imagen.FileName));
        //    }

        //    this.repo.ModificarJuego(j);
        //    List<Juego> juegos = this.repo.GetJuegos();
        //    return View("Juegos", juegos);


        //}
        public async Task<ActionResult> CreateJuegos()
        {
            ViewBag.cate = await this.repo.Categorias();
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> CreateJuegos(Juego j, IFormFile imagen)
        {
          
            Stream stream = imagen.OpenReadStream();
            String nombre = imagen.FileName;
            this.repo.UploadFile(nombre, stream);
            ViewBag.Mensaje = "Fichero subido";
            
           
            this.repo.CrearJuego(j);
            List<Juego> juegos = await this.repo.GetJuegos();
            return View("Juegos", juegos);
        }

        public async Task<ActionResult> BorrarJuegos(String id)
        {
            this.repo.EliminarJuego(id);
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


            this.repo.ModificarCategoria(j);
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

            this.repo.CrearCategoria(j);
            List<Categoria> categorias = await this.repo.Categorias();
            return View("Categorias", categorias);
        }

        public async Task<ActionResult> BorrarCategoria(int id)
        {
            this.repo.EliminarCategoria(id);
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
            this.repo.BorrarUsuarios(id);
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
            this.repo.EditarUsuarios(u);
            List<Usuario> usu = await this.repo.GetUsuarios();
            return View("Usuarios", usu);
        }

    }
}