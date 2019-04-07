
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
        Task<String> GetToken(String usuario, String password);
        Task<List<Juego>> GetJuegos();
        Task<List<Categoria>> Categorias();
        Task<List<Usuario>> GetUsuarios();
        Task<List<string>> Nombrejuego();
        Task<Categoria> BuscarCategoria(int id);
        List<Juego> BuscarJuegoCategoria(int tipo);
        Task<Usuario> ExisteUsuario(string usuario);
        Task<Usuario> BuscarUsuario(int idusuario);
        Task<Juego> BuscarJuego(String nombre, String token);
        Task<Usuario> BuscarUsuarioEmail(String Email,String token);
        Task<Usuario> BuscarUsuarioMote(String usuario, String token);
        Task<Usuario> ComprobarUsuario(String username
              , String password);

        void UploadFile(String nombre, Stream stream);
        Task<List<MostrarPerfil>> GetMostrarPerfils(String Usuario,String token);
        Task<List<Ranking>> GetTodos(Int64 clave, int totalregistros);

        Task<List<Ranking>> GetTodosJuego(Int64 clave, int totalregistros, String juego);
        void NuevoUsuario(String usuario, String email, String password);
        void EliminarJuego(String nombre);
        void CrearJuego(Juego juego);
        void InsertarPuntuacion(int puntos, String nombre,String token);
        void Puntuacion(int Puntuacion, String nombre);
        void BorrarUsuarios(int id);
        void EliminarCategoria(int id);
        void CrearCategoria(Categoria Categoria);
        void ModificarCategoria(Categoria categoria);
        void EditarUsuarios(Usuario u);
        void ModificarJuego(Juego juego);
    }
}
