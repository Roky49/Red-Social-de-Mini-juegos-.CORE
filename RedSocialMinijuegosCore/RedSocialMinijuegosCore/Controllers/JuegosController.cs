﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedSocialMinijuegosCore.Model;
using RedSocialMinijuegosCore.Repositories;

namespace RedSocialMinijuegosCore.Controllers
{
    public class JuegosController : Controller
    {


        IRepositoryMinijuegos repo;


        public JuegosController(IRepositoryMinijuegos repo)
        {

            this.repo = repo; ;
        }
        // GET: Juegos
        public ActionResult Index(String nombre)
        {
            Juego j = this.repo.BuscarJuego(nombre);
            return View(j);
        }
        [HttpPost]
        public ActionResult Index(int puntos, String nombre)
        {

            this.repo.InsertarPuntuacion(puntos, nombre);
            Juego j = this.repo.BuscarJuego(nombre);
            return View(j);

        }

        public ActionResult Chat()
        {

            return View();
        }


        public ActionResult Perfil(String usuario)
        {
            Usuario usu = this.repo.BuscarUsuarioMote(usuario);
            List<MostrarPerfil> perfil = this.repo.GetMostrarPerfils(usuario);
            ViewBag.usario = usu;
            return View(perfil);
        }

    }
}