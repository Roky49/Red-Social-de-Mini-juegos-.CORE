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
        [Route("[action]")]
        public ActionResult<List<String>> NombreJuegos()
        {
            return this.repo.Nombrejuego();
        }
        [HttpGet("{Categorias}/{id}")]
        [Route("[action]")]
        public ActionResult<Categoria> BuscarCategoria(int id)
        {
            return this.repo.BuscarCategoria(id);
        }

        [HttpGet("{BuscarJuegoCategoria}/{tipo}")]
        [Route("[action]")]
        public ActionResult<List<Juego>> BuscarJuegoCategoria(int tipo)
        {
            return this.repo.BuscarJuegoCategoria(tipo);
        }
        [HttpGet("{BuscarJuegoCategoria}/{tipo}")]
        [Route("[action]")]
        public ActionResult<List<Juego>> BuscarJuegoCateg(int tipo)
        {
            return this.repo.BuscarJuegoCategoria(tipo);
        }
        [HttpGet("{ExisteUsuario}/{usuario}")]
        [Route("[action]")]
        public ActionResult<Usuario> ExisteUsuario(string usuario)
        {
            return this.repo.ExisteUsuario(usuario);
        }

        [HttpGet("{BuscarUsuario}/{idusuario}")]
        [Route("[action]")]
        public ActionResult<Usuario> BuscarUsuario(int idusuario)
        {
            return this.repo.BuscarUsuario(idusuario);
        }



        [HttpGet("{BuscarJuego}/{nombre}")]
        [Route("[action]")]
        public ActionResult<Juego> BuscarJuego(String nombre)
        {
            return this.repo.BuscarJuego(nombre);
        }

        [HttpGet("{BuscarUsuarioEmail}/{Email}")]
        [Route("[action]")]
        public ActionResult<Usuario> BuscarUsuarioEmail(String Email)
        {
            return this.repo.BuscarUsuarioEmail(Email);
        }

        [HttpGet("{BuscarUsuarioMote}/{usuario}")]
        [Route("[action]")]
        public ActionResult<Usuario> BuscarUsuarioMote(String usuario)
        {
            return this.repo.BuscarUsuarioMote(usuario);
        }

        [HttpGet("{ComprobarUsuario}/{username}/{password}")]
        [Route("[action]")]
        public ActionResult<Usuario> ComprobarUsuario(String username
               , String password)
        {
            return this.repo.ComprobarUsuario(username, password);
        }

        [HttpGet("{GetTodos}/{clave}/{totalregistros}")]
        [Route("[action]")]
        public ActionResult<List<Ranking>> GetTodos(int clave, ref int totalregistros)
        {
            return this.repo.GetTodos(clave, ref totalregistros);
        }

        [HttpGet("{Perfil}/{Usuario}")]
        [Route("[action]")]
        public ActionResult<List<MostrarPerfil>> GetMostrarPerfils(String Usuario)
        {
            return this.repo.GetMostrarPerfils(Usuario);
        }


        [HttpGet("{Ranking}/{clave}/{totalregistros}/{juego}")]
        [Route("[action]")]
        public ActionResult<List<Ranking>> GetTodosRanking(int clave, ref int totalregistros, String juego)
        {
            return this.repo.GetTodosJuego(clave, ref totalregistros, juego);
        }

        [HttpPost("{NuevoUsuario}/{usuario}/{email}/{password}")]
        [Route("[action]")]
        public void NuevoUsuario(String usuario, String email, String password)
        {
            this.repo.NuevoUsuario(usuario, email, password);
        }

        [HttpDelete("{Juegos}/{nombre}")]
        [Route("[action]")]
        public void EliminarJuego(String nombre)
        {
            this.repo.EliminarJuego(nombre);
        }

        [HttpPost("{Juegos}/{Juego}")]
        [Route("[action]")]
        public void CrearJuego(Juego juego)
        {
            this.repo.CrearJuego(juego);
        }

        [HttpPost("{NuevaPartida}")]
        [Route("[action]")]
        public void InsertarPuntuacion(int puntos, String nombre)
        {
            this.repo.InsertarPuntuacion(puntos, nombre);
        }

        [HttpDelete("{Usuario}/{id}")]
        [Route("[action]")]
        public void BorrarUsuarios(int id)
        {
            this.repo.BorrarUsuarios(id);
        }


        [HttpDelete("{Categorias}/{id}")]
        [Route("[action]")]
        public void EliminarCategoria(int id)
        {
            this.repo.EliminarCategoria(id);
        }



        [HttpPost("{Categoria}/{NuevaCategoria}")]
        [Route("[action]")]
        public void CrearCategoria(Categoria categoria)
        {
            this.repo.CrearCategoria(categoria);
        }

        [HttpPut("{Categoria}/{ModCategoria}")]
        [Route("[action]")]
        public void ModificarCategoria(Categoria categoria)
        {
            this.repo.ModificarCategoria(categoria);
        }

        [HttpPut("{Usuarios}/{usuario}")]
        [Route("[action]")]
        public void EditarUsuarios(Usuario usuario)
        {
            this.repo.EditarUsuarios(usuario);
        }

        [HttpPut("{Juego}/{ModificarJuego}")]
        [Route("[action]")]
        public void ModificarJuego(Juego juego)
        {
            this.repo.ModificarJuego(juego);
        }
    }
}