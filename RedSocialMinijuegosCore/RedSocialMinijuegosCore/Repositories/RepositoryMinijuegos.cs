using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedSocialMinijuegosCore.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Repositories
{
    public class RepositoryMinijuegos : IRepositoryMinijuegos
    {

        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;

        public RepositoryMinijuegos()
        {
            this.uriapi = "https://localhost:44394/";
            this.headerjson =
new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<String> GetToken(String usuario
            , String password)
        {
            using (HttpClient client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(this.uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);

                LoginModel login = new LoginModel();
                login.UserName = usuario;
                login.Password = password;
                String json = JsonConvert.SerializeObject(login);

                StringContent content =
                    new StringContent(json
                    , System.Text.Encoding.UTF8, "application/json");
                String peticion = "Auth/Login";
                HttpResponseMessage response =
                    await client.PostAsync(peticion, content);
                if (response.IsSuccessStatusCode)
                {
                    String contenido =
                        await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(contenido);
                    return jObject.GetValue("response").ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        private async Task<T> CallApi<T>(String peticion
            , String token)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(this.uriapi);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(headerjson);
                if (token != null)
                {
                    cliente.DefaultRequestHeaders.Add("Authorization", "bearer "
                        + token);
                }
                HttpResponseMessage response =
                    await cliente.GetAsync(peticion);
                if (response.IsSuccessStatusCode)
                {
                    T datos =
                        await response.Content.ReadAsAsync<T>();
                    return (T)Convert.ChangeType(datos, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
        }

        public void BorrarUsuarios(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria BuscarCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Juego BuscarJuego(string nombre)
        {
            throw new NotImplementedException();
        }

        public List<Juego> BuscarJuegoCategoria(int tipo)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarUsuario(int idusuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarUsuarioEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarUsuarioMote(string usuario)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> Categorias()
        {
            throw new NotImplementedException();
        }

        public Usuario ComprobarUsuario(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void CrearCategoria(Categoria Categoria)
        {
            throw new NotImplementedException();
        }

        public void CrearJuego(Juego juego)
        {
            throw new NotImplementedException();
        }

        public void EditarUsuarios(Usuario u)
        {
            throw new NotImplementedException();
        }

        public void EliminarCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public void EliminarJuego(string nombre)
        {
            throw new NotImplementedException();
        }

        public Usuario ExisteUsuario(string usuario)
        {
            throw new NotImplementedException();
        }

        public List<Juego> GetJuegos()
        {
            throw new NotImplementedException();
        }

        public List<MostrarPerfil> GetMostrarPerfils(string Usuario)
        {
            throw new NotImplementedException();
        }

        public List<Ranking> GetTodos(long clave, int totalregistros)
        {
            throw new NotImplementedException();
        }

        public List<Ranking> GetTodosJuego(long clave, int totalregistros, string juego)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public void InsertarPuntuacion(int puntos, string nombre)
        {
            throw new NotImplementedException();
        }

        public void ModificarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void ModificarJuego(Juego juego)
        {
            throw new NotImplementedException();
        }

        public List<string> Nombrejuego()
        {
            throw new NotImplementedException();
        }

        public void NuevoUsuario(string usuario, string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Puntuacion(int Puntuacion, string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
