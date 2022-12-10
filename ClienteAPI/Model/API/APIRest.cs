using ClienteAPI.Model.POCO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace ClienteAPI.Model.API
{
    public class APIRest
    {
        private readonly HttpClient client = new();

        #region URL

        private static readonly string URLAPI = "https://web-production-2d2f.up.railway.app";

        //GET
        private static readonly string URLGetUsuarioPorCorreo = "/usuario/correo/";
        private static readonly string URLGetLaptops = "/laptops";
        private static readonly string URLGetLaptopID = "/laptop/";
        private static readonly string URLGetLaptopModelo = "/laptopModelo/";

        //POST
        private static readonly string URLPostLaptop = "/laptop";

        #endregion URL

        #region METHODS API REST

        //GET
        public async Task<string> GETJSONAsync(string url)
        {
            try
            {
                string responseJSON = "";
                using HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    responseJSON = await response.Content.ReadAsStringAsync();
                }
                else
                {   responseJSON = "404"; }
                
                return responseJSON;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return "500";
            }
        }

        //POST
        public async Task<string> POSTJSONAsync(string url, string objectJSON)
        {
            HttpContent content = new StringContent(objectJSON, Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync(url, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
            else
            {
                return "500";
            }
        }

        #endregion METHODS API REST

        #region METHODS

        #region GET
        public async Task<Usuario?> GetUsuarioPorCorreo(string correo)
        {
            Usuario? usuario = null;
            string usuarioJSON = await GETJSONAsync(URLAPI + URLGetUsuarioPorCorreo + correo);
            if (usuarioJSON != "404") { usuario = DeserializarJSONUsuario(usuarioJSON); }

            return usuario;
        }

        public async Task<List<Laptop>?> GetLaptops()
        {
            List<Laptop>? laptops = null;
            string laptopsJSON = await GETJSONAsync(URLAPI + URLGetLaptops);
            if (laptopsJSON != "404") { laptops = DeserializarJSONLaptops(laptopsJSON); }
            
            return laptops;
        }

        public async Task<List<Laptop>?> GetLaptopPorID(string id)
        {
            List<Laptop>? laptop = null;
            string laptopJSON = await GETJSONAsync(URLAPI + URLGetLaptopID + id);
            if (laptopJSON != "404") { laptop = DeserializarJSONLaptops(laptopJSON); }

            return laptop;
        }

        public async Task<List<Laptop>?> GetLaptopPorModelo(string modelo)
        {
            List<Laptop>? laptops = null;
            string laptopsJSON = await GETJSONAsync(URLAPI + URLGetLaptopModelo + modelo);
            if (laptopsJSON != "404") { laptops = DeserializarJSONLaptops(laptopsJSON); }

            return laptops;
        }

        #endregion GET

        #region POST
        public async Task<string> PostLaptop(Laptop laptop)
        {
            string objectJSON = JsonConvert.SerializeObject(laptop); //Serializando Laptop en JSON
            return await POSTJSONAsync(URLAPI + URLPostLaptop, objectJSON);
        }

        #endregion POST

        #region DESERIALIZE
        public Usuario? DeserializarJSONUsuario(string usuarioJSON)
        {
            Usuario? usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJSON);
            return usuario;
        }

        private List<Laptop>? DeserializarJSONLaptops(string laptopsJSON)
        {
            List<Laptop>? laptops = JsonConvert.DeserializeObject<List<Laptop>>(laptopsJSON);
            return laptops;
        }

        #endregion DESERIALIZAR

        #endregion METHODS
    }
}
