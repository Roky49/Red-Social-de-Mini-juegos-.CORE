using ApiMinijuegos.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMinijuegos.Data
{
    public class MinijuegosContex:DbContext
    {
        public MinijuegosContex() : base() { }



        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Juego> Juegos { get; set; } 
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // vistas
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<MostrarPerfil> MostrarPerfils { get; set; }




    }
}
