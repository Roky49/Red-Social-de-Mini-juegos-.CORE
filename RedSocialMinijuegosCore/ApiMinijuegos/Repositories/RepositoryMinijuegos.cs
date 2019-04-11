using ApiMinijuegos.Data;
using ApiMinijuegos.Model;
using ApiMinijuegos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiMinijuegos.Repositories
{
    public class RepositoryMinijuegos:IRepositoryMinijuegos
    {
        MinijuegosContex contex;
        public RepositoryMinijuegos(MinijuegosContex contex)
        {
            this.contex = contex;
        }


        public List<Noticia> GetNoticias()
        {
            var consulta = from datos in contex.Noticias
                           orderby datos.IdTitular descending
                           select datos;
            return consulta.ToList();
        }
        public void ModificarJuego(Juego juego)
        {
            var consulta = from datos in contex.Juegos where datos.Nombre == juego.Nombre select datos;
            Juego j1 = consulta.FirstOrDefault();
            j1.Nombre = juego.Nombre;
            j1.Html = juego.Html;
            j1.Imagen = juego.Imagen;
            j1.Nveces = 0;
            j1.Tipo = juego.Tipo;
            j1.Valoracion = 0;
            j1.Css = juego.Css;
            j1.Scritp = juego.Scritp;


            this.contex.SaveChanges();
        }
        public void CrearJuego(Juego juego)
        {
            Juego j1 = new Juego();
            j1.Nombre = juego.Nombre;
            j1.Html = juego.Html;
            j1.Imagen = juego.Imagen;
            j1.Nveces = 0;
            j1.Tipo = juego.Tipo;
            j1.Valoracion = 0;
            j1.Css = juego.Css;
            j1.Scritp = juego.Scritp;

            this.contex.Juegos.Add(j1);
            this.contex.SaveChanges();
        }

        public void EliminarJuego(String nombre)
        {
            Juego j = BuscarJuego(nombre);

            this.contex.Juegos.Remove(j);
            this.contex.SaveChanges();
        }
        public List<Usuario> GetUsuarios()
        {
            var consulta = from datos in contex.Usuarios select datos;
            return consulta.ToList();
        }

        public List<Juego> GetJuegos()
        {
            var consulta = from datos in contex.Juegos select datos;
            return consulta.ToList();
        }

        public Juego BuscarJuego(String nombre)
        {
            var consulta = from datos in contex.Juegos where datos.Nombre == nombre select datos;
            return consulta.FirstOrDefault();
        }
        public List<Juego> BuscarJuegoCategoria(int id)
        {
            var consulta = from datos in contex.Juegos where datos.Tipo == id select datos;
            return consulta.ToList();
        }

        public void Puntuacion(int estrellas, String nombre)
        {
            Juego j1 = BuscarJuego(nombre);
            estrellas *= 2; 
            if (j1.Nveces == null && j1.Valoracion == null)
            {
                j1.Nveces = 1;
                j1.Valoracion = estrellas;
                j1.ValoracionTotal = j1.Valoracion / j1.Nveces;
            }
            else
            {

                j1.Nveces += 1;
                j1.Valoracion += estrellas;
                j1.ValoracionTotal = j1.Valoracion / j1.Nveces;
            }
           
            this.contex.SaveChanges();


        }

        public Usuario ExisteUsuario(string usuario)
        {
            var consulta = from datos in contex.Usuarios
                           where datos.Email == usuario

                           select datos;


            return consulta.FirstOrDefault();

        }

        public void NuevoUsuario(String usuario, String email, String password)
        {
            Usuario usu = new Usuario();
            var ultimonumero = contex.Usuarios.OrderByDescending(i => i.IdUsuario).FirstOrDefault();
            if (ultimonumero == null)
            {
                usu.IdUsuario = 1;
            }
            else
            {
                usu.IdUsuario = ultimonumero.IdUsuario + 1;
            }
            usu.Gemas = 100;
            usu.UltimaConexion = DateTime.Now.Date;
            usu.Puntuacion = 1;
            String salt = ModeloToolkit.GenerarSalt();
            byte[] passcifrada =
                ModeloToolkit.Encriptar(password, salt);
            usu.Email = email;
            usu.Nombre = usuario;
            usu.Salt = salt;
            usu.Roles = "User";
            usu.PassWord = passcifrada;
            this.contex.Usuarios.Add(usu);
            this.contex.SaveChanges();
        }

        public Usuario ComprobarUsuario(String username
               , String password)
        {
            //BUSCAMOS EL USUARIO POR SU USERNAME
            var consulta = from datos in contex.Usuarios
                           where datos.Email == username
                           select datos;
            Usuario usuario = consulta.FirstOrDefault();
            if (usuario != null)
            {
                String salt = usuario.Salt;
                byte[] datospassword = usuario.PassWord;
                byte[] datoscifrados =
                    ModeloToolkit.Encriptar(password, salt);
                //COMPARAMOS LOS DOS ARRAYS
                bool iguales = true;
                if (datospassword.Length
                    != datoscifrados.Length)
                {
                    return null;
                }


                for (int i = 0; i <= datoscifrados.Length - 1; i++)
                {
                    if (datoscifrados[i].Equals(datospassword[i]) == false)
                    {
                        iguales = false;
                        break;
                    }
                }

                if (iguales == false)
                {
                    return null;
                }
                else
                {   
                    return usuario;
                }
            }
            return null;
        }


        public Usuario BuscarUsuario(int idusuario)
        {
            var consulta = from datos in contex.Usuarios where datos.IdUsuario == idusuario select datos;

            return consulta.FirstOrDefault();
        }



        public Usuario BuscarUsuarioEmail(string email)
        {
            var consulta = from datos in contex.Usuarios where datos.Email == email select datos;

            return consulta.FirstOrDefault();
        }

        public Usuario BuscarUsuarioMote(string usuario)
        {
            var consulta = from datos in contex.Usuarios where datos.Nombre == usuario select datos;

            return consulta.FirstOrDefault();
        }


        public void InsertarPuntuacion(int puntos, string nombre, int id)
        {
            Partida nepartida = new Partida();
            nepartida.NombreJuego = nombre;
            nepartida.Puntuacion = puntos;
           
            nepartida.IdUsuario = id; 
          
            nepartida.Fecha = DateTime.Now;

            var ultimonumero = contex.Partidas.OrderByDescending(i => i.IdPartida).FirstOrDefault();
            if (ultimonumero == null)
            {
                nepartida.IdPartida = 1;
            }
            else
            {
                nepartida.IdPartida = ultimonumero.IdPartida + 1;
            }

            this.contex.Partidas.Add(nepartida);
            this.contex.SaveChanges();

        }

       

        public List<Categoria> Categorias()
        {
            return this.contex.Categorias.ToList();
        }

        public void EliminarCategoria(int id)
        {
            Categoria j = this.BuscarCategoria(id);

            this.contex.Categorias.Remove(j);
            this.contex.SaveChanges();
        }

        public void CrearCategoria(Categoria Categoria)
        {
            Categoria j = new Categoria();
            var ultimonumero = contex.Categorias.OrderByDescending(i => i.IdCategoria).FirstOrDefault();

            if (ultimonumero == null)
            {
                j.IdCategoria = 1;
            }
            else
            {
                j.IdCategoria = 1 + ultimonumero.IdCategoria;
            }

            j.Nombre = Categoria.Nombre;

            this.contex.Categorias.Add(j);
            this.contex.SaveChanges();
        }



        public void ModificarCategoria(Categoria categoria)
        {
            Categoria j = this.BuscarCategoria(categoria.IdCategoria);
            j.Nombre = categoria.Nombre;

            this.contex.SaveChanges();
        }
        public Categoria BuscarCategoria(int id)
        {
            var consulta = from datos in contex.Categorias where datos.IdCategoria == id select datos;
            return consulta.FirstOrDefault();
        }

        public void BorrarUsuarios(int id)
        {
            Usuario j = this.BuscarUsuario(id);

            this.contex.Usuarios.Remove(j);
            this.contex.SaveChanges();
        }

        public void EditarUsuarios(Usuario u)
        {
            Usuario j = this.BuscarUsuario(u.IdUsuario);
            j.Roles = u.Roles;

            this.contex.SaveChanges();
        }



        public List<Ranking> GetTodos()
        {
            var consulta = from datos in contex.Rankings 
                           orderby datos.Clave descending
                           select datos;

            return consulta.ToList();


        }

        public List<Ranking> GetTodosJuego( string juego)
        {
            var consulta = from datos in contex.Rankings
                           where datos.NombreJuego == juego
                           orderby datos.Puntuacion descending
                           select datos;


            return consulta.ToList();
        }

        public List<string> Nombrejuego()
        {
            var consulta = from datos in contex.Juegos

                           select datos.Nombre;

            return consulta.ToList();
        }

        public List<MostrarPerfil> GetMostrarPerfils(String Usuario)
        {
            var consulta = from datos in contex.MostrarPerfils
                           where datos.Nombre == Usuario
                           select datos;

            return consulta.ToList();
        }

        public List<Ranking> MaxRanking()
        {
            var max = contex.Rankings.GroupBy(x => x.NombreJuego);
            return max.SelectMany(z => z.Where(y => y.Puntuacion == z.Max(v => v.Puntuacion))).ToList();
        }


    }
}
