using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiMinijuegos.Repositories;
using Microsoft.Extensions.Configuration;
using ApiMinijuegos.Models;
using ApiMinijuegos.Model;
using System.Security.Claims;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiMinijuegos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IRepositoryMinijuegos repo;
        IConfiguration configuration;

        public AuthController(IRepositoryMinijuegos repo
            , IConfiguration configuration)
        {
            this.configuration = configuration;
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {

            Usuario user =
                this.repo.ComprobarUsuario(model.UserName
                , model.Password);
         
            
            if (user != null)
            {
                //ESTA ES LA INFORMACION QUE VAMOS A INCLUIR EN 
                //NUESTRO TOKEN PARA PODER RECUPERARLA POSTERIORMENTE
                Claim[] claims = new[]
                {
                    new Claim("UserData", JsonConvert.SerializeObject(user))
                };

                //GENERAMOS EL TOKEN CON LA INFORMACION
                JwtSecurityToken token = new JwtSecurityToken
                 (
                     issuer: configuration["ApiAuth:Issuer"],
                     audience: configuration["ApiAuth:Audience"],
                     claims: claims,
                     expires: DateTime.UtcNow.AddMinutes(30),
                     notBefore: DateTime.UtcNow,
                     signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApiAuth:SecretKey"])),
                     SecurityAlgorithms.HmacSha256)
                 );

                // Devolvemos el token en la respuesta
                return Ok(
                    new
                    {
                        response = new JwtSecurityTokenHandler()
                        .WriteToken(token)
                    }
                );
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}