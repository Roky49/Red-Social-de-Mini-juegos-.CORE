using ApiMinijuegos.Data;
using ApiMinijuegos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Repositories
{
     public interface IRepositoryMinijuegos
    {
        
        List<Categoria> Categorias();
        List<Juego> GetJuegos();
        List<Usuario> GetUsuarios();
        List<string> Nombrejuego();
        Categoria BuscarCategoria(int id);




        void BorrarUsuarios(int id);
        void EditarUsuarios(Usuario u);
       

        void EliminarCategoria(int id);
        void CrearCategoria(Categoria Categoria);
        void ModificarCategoria(Categoria categoria);
        

        void ModificarJuego(Juego juego);
        
        
        List<Juego> BuscarJuegoCategoria(int tipo);
        

        Usuario ExisteUsuario(string usuario);

        Usuario BuscarUsuario(int idusuario);

        Usuario BuscarUsuarioEmail(String Email);
        Usuario BuscarUsuarioMote(String usuario);

        Usuario ComprobarUsuario(String username
                , String password);

        void NuevoUsuario(String usuario, String email, String password);
        void EliminarJuego(String nombre);
        void CrearJuego(Juego juego);
        void InsertarPuntuacion(int puntos, String nombre);

        void Puntuacion(int Puntuacion, String nombre);
        Juego BuscarJuego(String nombre);

        List<Ranking> GetTodos(int clave, ref int totalregistros);

        List<MostrarPerfil> GetMostrarPerfils(String Usuario);

        List<Ranking> GetTodosJuego(int clave, ref int totalregistros, String juego);
        

    }
}
