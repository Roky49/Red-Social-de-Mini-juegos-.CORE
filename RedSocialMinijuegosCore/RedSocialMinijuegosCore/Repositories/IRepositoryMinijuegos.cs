
using RedSocialMinijuegosCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Repositories
{
    public interface IRepositoryMinijuegos
    {
        Task<List<Ranking>> MaxRanking();
        Task<List<Noticia>> GetNoticias();
        Task<String> GetToken(String usuario, String password);
        Task<List<Juego>> GetJuegos();
        Task<List<Categoria>> Categorias();
        Task<List<Usuario>> GetUsuarios();
        Task<List<string>> Nombrejuego();
        Task<Categoria> BuscarCategoria(int id);
        Task<List<Juego>> BuscarJuegoCategoria(int tipo);
        Task<Usuario> ExisteUsuario(string usuario);
        Task<Usuario> BuscarUsuario(int idusuario);
        Task<Juego> BuscarJuego(String nombre, String token);
        Task<Usuario> BuscarUsuarioEmail(String Email,String token);
        Task<Usuario> BuscarUsuarioMote(String usuario, String token);
        Task<Usuario> ComprobarUsuario(String username
              , String password);

        void UploadFile(String nombre, Stream stream);
        Task<List<MostrarPerfil>> GetMostrarPerfils(String Usuario,String token);
        Task<List<Ranking>> GetTodos();

        Task<List<Ranking>> GetTodosJuego( String juego);
        Task NuevoUsuario(String usuario, String email, String password);
        Task EliminarJuego(String nombre, String token);
        Task CrearJuego(Juego juego, String token);
        Task InsertarPuntuacion(int puntos, String nombre,int id,String token);
        Task Puntuacion(int Puntuacion, String nombre);
        Task BorrarUsuarios(int id, String token);
        Task EliminarCategoria(int id, String token);
        Task CrearCategoria(Categoria Categoria, String token);
        Task ModificarCategoria(Categoria categoria, String token);
        Task EditarUsuarios(Usuario u, String token);
        Task ModificarJuego(Juego juego, String token);
    }
}
