using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedSocialMinijuegosCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RedSocialMinijuegosCore.Repositories
{
    public class RepositoryMinijuegos : IRepositoryMinijuegos
    {
        CloudFileDirectory root;
        private String uriapi;
        private MediaTypeWithQualityHeaderValue headerjson;

        public RepositoryMinijuegos()
        {
            this.uriapi = "https://localhost:44394/";
            this.headerjson =
new MediaTypeWithQualityHeaderValue("application/json");
            String keys =
                CloudConfigurationManager.GetSetting("cuentastorage");
            CloudStorageAccount account =
                CloudStorageAccount.Parse(keys);
            CloudFileClient client =
                account.CreateCloudFileClient();
            CloudFileShare shared = 
                client.GetShareReference("sharedtajamar");
            this.root = shared.GetRootDirectoryReference();

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

        public void UploadFile(String nombre, Stream stream)
        {
            //NECESITAMOS UNA REFERENCIA AL FILE
            CloudFile file =
                this.root.GetFileReference(nombre);
            file.UploadFromStreamAsync(stream);
        }

        public async Task<List<Juego>> GetJuegos()
        {
            List<Juego> juegos = await
               this.CallApi<List<Juego>>("api/mini/GetJuego", null);
            return juegos;
        }

        public async Task<List<Categoria>> Categorias()
        {
            List<Categoria> categorias = await
               this.CallApi<List<Categoria>>("api/mini/Categorias", null);
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

        public async Task<List<Ranking>> GetTodos(long clave, int totalregistros)
        {
            List<Ranking> rankings = await
       this.CallApi<List<Ranking>>("api/mini/GetTodos/" + clave+"/"+totalregistros, null);
            return rankings;
        }

        public async Task<List<Ranking>> GetTodosJuego(long clave, int totalregistros, string juego)
        {
            List<Ranking> rankings = await
    this.CallApi<List<Ranking>>("api/mini/GetTodos/" + clave + "/" + totalregistros+"/"+juego, null);
            return rankings;
        }

    }
}
