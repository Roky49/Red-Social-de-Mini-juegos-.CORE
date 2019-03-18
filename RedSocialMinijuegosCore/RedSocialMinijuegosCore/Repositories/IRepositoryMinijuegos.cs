﻿
using RedSocialMinijuegosCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Repositories
{
    public interface IRepositoryMinijuegos
    {
        Task<String> GetToken(String usuario, String password);
        List<Juego> GetJuegos();
        List<Categoria> Categorias();
        List<Usuario> GetUsuarios();
        List<string> Nombrejuego();
        Categoria BuscarCategoria(int id);
        List<Juego> BuscarJuegoCategoria(int tipo);
        Usuario ExisteUsuario(string usuario);
        Usuario BuscarUsuario(int idusuario);
        Juego BuscarJuego(String nombre);
        Usuario BuscarUsuarioEmail(String Email);
        Usuario BuscarUsuarioMote(String usuario);
        Usuario ComprobarUsuario(String username
              , String password);


        List<MostrarPerfil> GetMostrarPerfils(String Usuario);
        List<Ranking> GetTodos(Int64 clave, int totalregistros);

        List<Ranking> GetTodosJuego(Int64 clave, int totalregistros, String juego);
        void NuevoUsuario(String usuario, String email, String password);
        void EliminarJuego(String nombre);
        void CrearJuego(Juego juego);
        void InsertarPuntuacion(int puntos, String nombre);
        void Puntuacion(int Puntuacion, String nombre);
        void BorrarUsuarios(int id);
        void EliminarCategoria(int id);
        void CrearCategoria(Categoria Categoria);
        void ModificarCategoria(Categoria categoria);
        void EditarUsuarios(Usuario u);
        void ModificarJuego(Juego juego);
    }
}