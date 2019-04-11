using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedSocialMinijuegosCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Repositories
{
    public class RepositoryMinijuegos : IRepositoryMinijuegos
    {
        CloudBlobContainer root;
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;

        public RepositoryMinijuegos()
        {
            
            this.uriapi = "https://apiminijuegosrbc.azurewebsites.net/";
         
            this.headerjson =
new MediaTypeWithQualityHeaderValue("application/json");
            /*String keys =*/

            //this.root = GetCloudBlobContainer();

        }

        //private CloudBlobContainer GetCloudBlobContainer()
        //{
        //    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
        //            CloudConfigurationManager.GetSetting("cuentastorage"));
        //    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        //    CloudBlobContainer container = blobClient.GetContainerReference("sharedtajamar");
        //    return container;
        //}

        public async Task<List<Ranking>> MaxRanking()
        {
            List<Ranking> juegos = await
               this.CallApi<List<Ranking>>("api/mini/MaxRanking", null);
            return juegos;
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

        //public void UploadFile(String nombre, Stream stream)
        //{
        //    //NECESITAMOS UNA REFERENCIA AL FILE
        //    CloudFile file =
        //        this.root.GetFileReference(nombre);
        //    file.UploadFromStreamAsync(stream);
        //}
        public async Task<List<Noticia>> GetNoticias()
        {
           
            List<Noticia> juegos = await
               this.CallApi<List<Noticia>>("api/mini/Noticias", null);
            return juegos;
        }
        public async Task<List<Juego>> GetJuegos()
        {
            List<Juego> juegos = await
               this.CallApi<List<Juego>>("api/mini/GetJuego", null);
            return juegos;
        }

        public async  Task<List<Categoria>> Categorias()
        {
            List<Categoria> categorias = await
               this.CallApi<List<Categoria>>("api/mini/GetCategoria", null);
            return categorias;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
                 List<Usuario> usuario = await
               this.CallApi<List<Usuario>>("api/mini/GetUsuarios", null);
            return usuario;
        }

        public async Task<List<string>> Nombrejuego()
        {
            List<String> nombrejuegos = await
          this.CallApi<List<String>>("api/mini/NombreJuegos", null);
            return nombrejuegos;
        }

        public async Task<Categoria> BuscarCategoria(int id)
        {
            Categoria categoria = await
         this.CallApi<Categoria>("api/mini/BuscarCategoria/"+id, null);
            return categoria;
        }

        public async Task<List<Juego>> BuscarJuegoCategoria(int tipo)
        {
            List<Juego> juegos = await
       this.CallApi<List<Juego>>("api/mini/BuscarJuegoCategoria/" + tipo, null);
            return juegos;
        }

        public async Task<Usuario> ExisteUsuario(string usuario)
        {
            Usuario usu = await
     this.CallApi<Usuario>("api/mini/ExisteUsuario/" + usuario, null);
            return usu;
        }

        public async Task<Usuario> BuscarUsuario(int idusuario)
        {
            Usuario usu = await
             this.CallApi<Usuario>("api/mini/BuscarUsuario/" + idusuario, null);
            return usu;
        }

        public async Task<Juego> BuscarJuego(string nombre, string token)
        {
            Juego usu = await
            this.CallApi<Juego>("api/mini/BuscarJuego/" + nombre, token);
            return usu;
        }

        public async Task<Usuario> BuscarUsuarioEmail(string Email, string token)
        {
            Usuario usu = await
            this.CallApi<Usuario>("api/mini/BuscarUsuarioEmail/" + Email, token);
            return usu;
        }

        public async Task<Usuario> BuscarUsuarioMote(string usuario, string token)
        {
            Usuario usu = await
           this.CallApi<Usuario>("api/mini/BuscarUsuarioMote/" + usuario, token);
            return usu;
        }

        public async Task<Usuario> ComprobarUsuario(string username, string password)
        {
            Usuario usu = await
          this.CallApi<Usuario>("api/mini/ComprobarUsuario/" + username+"/"+password, null);
            return usu;
        }

        public async Task<List<MostrarPerfil>> GetMostrarPerfils(string Usuario, string token)
        {
            List<MostrarPerfil> usu = await
        this.CallApi<List<MostrarPerfil>>("api/mini/GetMostrarPerfils/" + Usuario , token);
            return usu;
        }

        public async Task<List<Ranking>> GetTodos()
        {
            List<Ranking> rankings = await
       this.CallApi<List<Ranking>>("api/mini/GetTodos", null);
            return rankings;
        }

        public async Task<List<Ranking>> GetTodosJuego(string juego)
        {
            List<Ranking> rankings = await
    this.CallApi<List<Ranking>>("api/mini/GetTodosRanking/" + juego, null);
            return rankings;
        }

     

        public void UploadFile(string nombre, Stream stream)
        {
            throw new NotImplementedException();
        }

        public async Task NuevoUsuario(string usuario, string email, string password)
        {
             

            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/NuevoUsuario/" + usuario + "/" + email + "/" + password;
                Usuario cli = new Usuario();

                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(peticion, content);
            }
        }

        public async Task EliminarJuego(string nombre,String token)
        {
            
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/EliminarJuego/" + nombre;
               

                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                HttpResponseMessage message = await client.DeleteAsync(peticion);
            }

        }

        public async Task CrearJuego(Juego juego, String token)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/CrearJuego";
                Juego cli = new Juego();
                cli.Nombre = juego.Nombre;

                cli.Html = juego.Html;
                cli.Css = juego.Css;
                cli.Imagen = juego.Imagen;
                cli.Nveces = 5;
                cli.Scritp = juego.Scritp;
                cli.Valoracion = 5;
                cli.ValoracionTotal = 5;
                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(peticion, content);
            }
        }

        public async Task InsertarPuntuacion(int puntos, string nombre,int id, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                
                String peticion = "api/mini/InsertarPuntuacion/" + puntos + "/" + nombre+"/"+id;
                Juego cli = new Juego();
                
                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(peticion, content);
            }


            
        }

        public async Task Puntuacion(int Puntuacion, string nombre)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/puntuacion/" + Puntuacion + "/" + nombre;
                Juego cli = new Juego();

                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
               

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(peticion, content);
            }
        }

        public async Task BorrarUsuarios(int id, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/BorrarUsuarios/" + id;


                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                HttpResponseMessage message = await client.DeleteAsync(peticion);
            }
        }

        public async Task EliminarCategoria(int id, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/EliminarCategoria/" + id;


                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                HttpResponseMessage message = await client.DeleteAsync(peticion);
            }
        }

        public async Task CrearCategoria(Categoria Categoria, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/CrearCategoria";
                Categoria cli = new Categoria();
                cli.Nombre = Categoria.Nombre;
                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PostAsync(peticion, content);
            }
        }
        public async Task ModificarCategoria(Categoria categoria, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/CrearCategoria";
                Categoria cli = new Categoria();
                cli.Nombre = categoria.Nombre;
                cli.IdCategoria = categoria.IdCategoria;
                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PutAsync(peticion, content);
            }
        }

        public async Task EditarUsuarios(Usuario u, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/EditarUsuarios";
                Usuario cli = new Usuario();
                cli.Roles = u.Roles;
                cli.Nombre = u.Nombre;
                cli.IdUsuario = u.IdUsuario;
                cli.Email = u.Email;
                cli.PassWord = u.PassWord;
                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PutAsync(peticion, content);
            }
        }

        public async Task ModificarJuego(Juego juego, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                String peticion = "api/mini/ModificarJuego";
                Juego cli = new Juego();
                cli.Nombre = juego.Nombre;
                cli.Html = juego.Html;
                cli.Scritp = juego.Scritp;
                cli.Css = juego.Css;
                client.BaseAddress = new Uri(uriapi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(headerjson);
                client.DefaultRequestHeaders.Add("Authorization", "bearer "
                       + token);

                String stringJson = JsonConvert.SerializeObject(cli);
                StringContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                HttpResponseMessage message = await client.PutAsync(peticion, content);
            }
        }
    }
}
