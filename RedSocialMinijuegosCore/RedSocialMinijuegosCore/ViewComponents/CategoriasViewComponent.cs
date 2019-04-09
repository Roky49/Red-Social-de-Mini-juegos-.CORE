using Microsoft.AspNetCore.Mvc;
using RedSocialMinijuegosCore.Models;
using RedSocialMinijuegosCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.ViewComponents
{
    public class CategoriasViewComponent: ViewComponent
    {
        IRepositoryMinijuegos repo;
        public CategoriasViewComponent(IRepositoryMinijuegos repo)
        {
            this.repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Categoria> categorias = await  this.repo.Categorias();
            return View(categorias);
        }
    }
}
