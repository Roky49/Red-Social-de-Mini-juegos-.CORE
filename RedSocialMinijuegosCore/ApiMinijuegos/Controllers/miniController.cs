using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiMinijuegos.Model;
using ApiMinijuegos.Models;
using ApiMinijuegos.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiMinijuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class miniController : ControllerBase
    {
        IRepositoryMinijuegos repo;
        public miniController(IRepositoryMinijuegos repo)
        {
            this.repo = repo;
        }
        // GET api/values
        //[HttpGet]
        //public ActionResult<List<Doctores>> Get()
        //{
        //    return this.repo.GetDoctores();
        //}

        //[HttpGet]
        //[Route("[action]")]
        //public ActionResult<List<String>> GetEspecialidades()
        //{
        //    return this.repo.GetEspecialidad();
        //}




        [HttpGet]
        [Route("[action]")]
        ///api/mini/GetJuego
        public ActionResult<List<Juego>> GetJuego()
        {
            return this.repo.GetJuegos();
        }

        [HttpGet]
        [Route("[action]")]
        //api/mini/GetCategoria

        public ActionResult<List<Categoria>> GetCategoria()
        {
            return this.repo.Categorias();
        }

        [HttpGet]
        [Route("[action]")]
        //api/mini/GetUsuarios

        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return this.repo.GetUsuarios();
        }

        [HttpGet("{Nombrejuegos}")]
        [Route("[action]")]
        //api/mini/NombreJuegos
        public ActionResult<List<String>> NombreJuegos()
        {
            return this.repo.Nombrejuego();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        //api/mini/BuscarCategoria/1
        public ActionResult<Categoria> BuscarCategoria(int id)
        {
            return this.repo.BuscarCategoria(id);
        }

        [HttpGet]
        [Route("[action]/{tipo}")]
        //api/mini/BuscarJuegoCategoria/2
        public ActionResult<List<Juego>> BuscarJuegoCategoria(int tipo)
        {
            return this.repo.BuscarJuegoCategoria(tipo);
        }
     
        [HttpGet]
        [Route("[action]/{usuario}")]
        //api/mini/ExisteUsuario/r@gmail.com
        public ActionResult<Usuario> ExisteUsuario(string usuario)
        {
            return this.repo.ExisteUsuario(usuario);
        }

        [HttpGet]
        [Route("[action]/{idusuario}")]
        //api/mini/BuscarUsuario/4
        public ActionResult<Usuario> BuscarUsuario(int idusuario)
        {
            return this.repo.BuscarUsuario(idusuario);
        }



        [HttpGet]
        [Route("[action]/{nombre}")]
        //api/mini/BuscarJuego/2048
        public ActionResult<Juego> BuscarJuego(String nombre)
        {
            return this.repo.BuscarJuego(nombre);
        }

        [HttpGet("")]
        [Route("[action]/{Email}")]
        //api/mini/BuscarUsuarioEmail/r@gmail.com
        public ActionResult<Usuario> BuscarUsuarioEmail(String Email)
        {
            return this.repo.BuscarUsuarioEmail(Email);
        }

        [HttpGet]
        [Route("[action]/{usuario}")]
        //api/mini/BuscarUsuarioMote/roa
        public ActionResult<Usuario> BuscarUsuarioMote(String usuario)
        {
            return this.repo.BuscarUsuarioMote(usuario);
        }

        [HttpGet]
        [Route("[action]/{username}/{password}")]
        //api/mini/ComprobarUsuario/r@gmail.com/admin
        public ActionResult<Usuario> ComprobarUsuario(String username
               , String password)
        {
            return this.repo.ComprobarUsuario(username, password);
        }

        [HttpGet]
        [Route("[action]")]
        //api/mini/GetTodos/0/20 clave totalregistros
        public ActionResult<List<Ranking>> GetTodos()
        {
            return this.repo.GetTodos();
        }

        [HttpGet]
        [Route("[action]/{Usuario}")]
        //api/mini/GetMostrarPerfils/ro
        public ActionResult<List<MostrarPerfil>> GetMostrarPerfils(String Usuario)
        {
            return this.repo.GetMostrarPerfils(Usuario);
        }


        [HttpGet]
        [Route("[action]/{juego}")]
        //api/mini/GetTodosRanking/0/12/2048 clave total
        public ActionResult<List<Ranking>> GetTodosRanking( String juego)
        {
            return this.repo.GetTodosJuego(juego);
        }

        [HttpPost]
        [Route("[action]/{usuario}/{email}/{password}")]
        //api/mini/NuevoUsuario/aaaaaaaa/aaaaaaa@gmail/123
        public void NuevoUsuario(String usuario, String email, String password)
        {
            this.repo.NuevoUsuario(usuario, email, password);
        }

        [HttpDelete]
        [Route("[action]/{nombre}")]
        [Authorize]
        //api/mini/EliminarJuego/prubea
        public void EliminarJuego(String nombre)
        {
            this.repo.EliminarJuego(nombre);
        }

        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        //api/mini/CrearJuego  + json
        public void CrearJuego(Juego juego)
        {
            this.repo.CrearJuego(juego);
        }

        [HttpPost]
        [Route("[action]/{Puntuacion}/{nombre}")]
        //api/mini/puntuacion  
        public void puntuacion(int Puntuacion, string nombre)
        {
            this.repo.Puntuacion(Puntuacion,nombre);
        }

        [HttpPost]
        [Route("[action]/{puntos}/{nombre}/{id}")]

        //api/mini/InsertarPuntuacion/100/prubea
        public void InsertarPuntuacion(int puntos, String nombre,int id)
        {
           
           
            this.repo.InsertarPuntuacion(puntos, nombre,id);
        }

        [HttpDelete]
        [Route("[action]/{id}")]
       
        //api/mini/BorrarUsuarios/6
        public void BorrarUsuarios(int id)
        {
            this.repo.BorrarUsuarios(id);
        }


        [HttpDelete]
        [Route("[action]/{id}")]
     
        //api/mini/EliminarCategoria/6
        public void EliminarCategoria(int id)
        {
            this.repo.EliminarCategoria(id);
        }



        [HttpPost]
        [Route("[action]")]
        //[Authorize]
        ///api/mini/CrearCategoria +json
        public void CrearCategoria(Categoria categoria)
        {
            this.repo.CrearCategoria(categoria);
        }

        [HttpPut]
        [Route("[action]")]
        //[Authorize]
        //api/mini/ModificarCategoria +json
        public void ModificarCategoria(Categoria categoria)
        {
            this.repo.ModificarCategoria(categoria);
        }

        [HttpPut]
        [Route("[action]")]
        //[Authorize]
        //api/mini/EditarUsuarios
        public void EditarUsuarios(Usuario usuario)
        {
            this.repo.EditarUsuarios(usuario);
        }

        [HttpPut]
        [Route("[action]")]
        //[Authorize]
        //api/mini/ModificarJuego + Json 
        public void ModificarJuego(Juego juego)
        {
            this.repo.ModificarJuego(juego);
        }
        [HttpGet]
        [Route("[action]")]
     
        public ActionResult<List<Noticia>> Noticias(int id)
        {
            return this.repo.GetNoticias(); 
        }



        [HttpGet]
        [Route("[action]")]
       
        //api/mini/MaxRanking
        public ActionResult<List<Ranking>> MaxRanking()
        {
            return this.repo.MaxRanking();
        }
    }
}