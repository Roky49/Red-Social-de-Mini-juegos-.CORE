using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMinijuegos.Model;
using ApiMinijuegos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiMinijuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinijuegosController : ControllerBase
    {
        IRepositoryMinijuegos repo;
        public MinijuegosController(IRepositoryMinijuegos repo)
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
       

        [HttpGet("{Categorias}")]
        public ActionResult<List<Categoria>> GetCategoria()
        {
            return this.repo.Categorias();
        }

        [HttpGet("{Juegos}")]
        public ActionResult<List<Juego>> GetJuego()
        {
            return this.repo.GetJuegos();
        }
        [HttpGet("{Usuarios}")]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return this.repo.GetUsuarios();
        }
        
        [HttpGet("{Nombrejuegos}")]
        public ActionResult<List<String>> NombreJuegos()
        {
            return this.repo.Nombrejuego();
        }
        [HttpGet("{Categorias}/{id}")]
        public ActionResult<Categoria> BuscarCategoria(int id)
        {
            return this.repo.BuscarCategoria(id);
        }

        [HttpGet("{BuscarJuegoCategoria}/{tipo}")]
        public ActionResult<List<Juego>> BuscarJuegoCategoria(int tipo)
        {
            return this.repo.BuscarJuegoCategoria(tipo);
        }
        [HttpGet("{BuscarJuegoCategoria}/{tipo}")]
        public ActionResult<List<Juego>> BuscarJuegoCateg(int tipo)
        {
            return this.repo.BuscarJuegoCategoria(tipo);
        }
        [HttpGet("{ExisteUsuario}/{usuario}")]
        public ActionResult<Usuario> ExisteUsuario(string usuario)
        {
            return this.repo.ExisteUsuario(usuario);
        }
       
        [HttpGet("{BuscarUsuario}/{idusuario}")]
        public ActionResult<Usuario> BuscarUsuario(int idusuario)
        {
            return this.repo.BuscarUsuario(idusuario);
        }


        
        [HttpGet("{BuscarJuego}/{nombre}")]
        public ActionResult<Juego> BuscarJuego(String nombre)
        {
            return this.repo.BuscarJuego(nombre);
        }

        [HttpGet("{BuscarUsuarioEmail}/{Email}")]
        public ActionResult<Usuario> BuscarUsuarioEmail(String Email)
        {
            return this.repo.BuscarUsuarioEmail(Email);
        }
        
        [HttpGet("{BuscarUsuarioMote}/{usuario}")]
        public ActionResult<Usuario> BuscarUsuarioMote(String usuario)
        {
            return this.repo.BuscarUsuarioMote(usuario);
        }

        [HttpGet("{ComprobarUsuario}/{username}/{password}")]
        public ActionResult<Usuario> ComprobarUsuario(String username
               , String password)
        {
            return this.repo.ComprobarUsuario(username,password);
        }
        
        [HttpGet("{GetTodos}/{clave}/{totalregistros}")]
        public ActionResult<List<Ranking>> GetTodos(int clave, ref int totalregistros)
        {
            return this.repo.GetTodos(clave,ref totalregistros);
        }
       
           [HttpGet("{Perfil}/{Usuario}")]
        public ActionResult<List<MostrarPerfil>> GetMostrarPerfils(String Usuario)
        {
            return this.repo.GetMostrarPerfils(Usuario);
        }
        

        [HttpGet("{Ranking}/{clave}/{totalregistros}/{juego}")]
        public ActionResult<List<Ranking>> GetTodosRanking(int clave, ref int totalregistros, String juego)
        {
            return this.repo.GetTodosJuego(clave , ref totalregistros, juego);
        }
    }
}
