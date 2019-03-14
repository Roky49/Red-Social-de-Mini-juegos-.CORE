using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMinijuegos.Model;
using ApiMinijuegos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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




        [HttpGet("/Juegos")]
        [Route("[action]")]
        public ActionResult<List<Juego>> GetJuego()
        {
            return this.repo.GetJuegos();
        }

        [HttpGet("/Categoria")]
        [Route("[action]")]
        public ActionResult<List<Categoria>> GetCategoria()
        {
            return this.repo.Categorias();
        }

        [HttpGet("/Usuarios")]
         [Route("[action]")]
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
            return this.repo.ComprobarUsuario(username, password);
        }

        [HttpGet("{GetTodos}/{clave}/{totalregistros}")]
        public ActionResult<List<Ranking>> GetTodos(int clave, ref int totalregistros)
        {
            return this.repo.GetTodos(clave, ref totalregistros);
        }

        [HttpGet("{Perfil}/{Usuario}")]
        public ActionResult<List<MostrarPerfil>> GetMostrarPerfils(String Usuario)
        {
            return this.repo.GetMostrarPerfils(Usuario);
        }


        [HttpGet("{Ranking}/{clave}/{totalregistros}/{juego}")]
        public ActionResult<List<Ranking>> GetTodosRanking(int clave, ref int totalregistros, String juego)
        {
            return this.repo.GetTodosJuego(clave, ref totalregistros, juego);
        }

        [HttpPost("{NuevoUsuario}/{usuario}/{email}/{password}")]
        public void NuevoUsuario(String usuario, String email, String password)
        {
            this.repo.NuevoUsuario(usuario, email, password);
        }

        [HttpDelete("{Juegos}/{nombre}")]
        public void EliminarJuego(String nombre)
        {
            this.repo.EliminarJuego(nombre);
        }

        [HttpPost("{Juegos}/{Juego}")]
        public void CrearJuego(Juego juego)
        {
            this.repo.CrearJuego(juego);
        }

        [HttpPost("{NuevaPartida}")]
        public void InsertarPuntuacion(int puntos, String nombre)
        {
            this.repo.InsertarPuntuacion(puntos, nombre);
        }

        [HttpDelete("{Usuario}/{id}")]
        public void BorrarUsuarios(int id)
        {
            this.repo.BorrarUsuarios(id);
        }


        [HttpDelete("{Categorias}/{id}")]
        public void EliminarCategoria(int id)
        {
            this.repo.EliminarCategoria(id);
        }



        [HttpPost("{Categoria}/{NuevaCategoria}")]
        public void CrearCategoria(Categoria categoria)
        {
            this.repo.CrearCategoria(categoria);
        }

        [HttpPut("{Categoria}/{ModCategoria}")]
        public void ModificarCategoria(Categoria categoria)
        {
            this.repo.ModificarCategoria(categoria);
        }

        [HttpPut("{Usuarios}/{usuario}")]
        public void EditarUsuarios(Usuario usuario)
        {
            this.repo.EditarUsuarios(usuario);
        }

        [HttpPut("{Juego}/{ModificarJuego}")]
        public void ModificarJuego(Juego juego)
        {
            this.repo.ModificarJuego(juego);
        }
    }
}