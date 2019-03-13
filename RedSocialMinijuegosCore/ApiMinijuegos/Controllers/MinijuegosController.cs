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

    }
}
