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

        //Usuario
        private static readonly string URLGetPutDeleteUsuario = "/usuario/"; //GET PUT DELETE
        private static readonly string URLGetUsuarioPorCorreo = "/usuario/correo/"; //GET Correo
        private static readonly string URLPostUsuario = "/usuario"; //Post

        //Laptop
        private static readonly string URLGetPutDeleteLaptop = "/laptop/"; //GET PUT DELETE
        private static readonly string URLGetLaptops = "/laptops"; //GET Varias Laptops
        private static readonly string URLGetLaptopModelo = "/laptopModelo/"; //GET Modelo
        private static readonly string URLPostLaptop = "/laptop"; //Post

        //Procesador
        private static readonly string URLGetPutDeleteProcesador = "/procesador/";
        private static readonly string URLPostProcesador = "/procesador";

        //Memoria Ram
        private static readonly string URLGetPutDeleteMemoriaRam = "/memoria/";
        private static readonly string URLPostMemoriaRam = "/memoria";

        //Almacenamiento
        private static readonly string URLGetPutDeleteAlmacenamiento = "/almacenamiento/";
        private static readonly string URLPostAlmacenamiento = "/almacenamiento";

        //HDD
        private static readonly string URLGetPutDeleteHDD = "/hdd/";
        private static readonly string URLPostHDD = "/hdd";

        //SSD
        private static readonly string URLGetPutDeleteSSD = "/ssd/";
        private static readonly string URLPostSSD = "/ssd";

        //Tarjeta Video
        private static readonly string URLGetPutDeleteTarjetaVideo = "/tarjetaDeVideo/";
        private static readonly string URLPostTarjetaVideo = "/tarjetaDeVideo/";

        //Pantalla
        private static readonly string URLGetPutDeletePantalla = "/pantalla/";
        private static readonly string URLPostPantalla = "/pantalla";

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

        //PUT
        public async Task<string> PUTJSONAsync(string url, string objectJSON)
        {
            HttpContent content = new StringContent(objectJSON, Encoding.UTF8, "application/json");
            var httpResponse = await client.PutAsync(url, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }
            else
            {
                return "500";
            }
        }
        
        //DELETE
        public async Task<string> DELETEJSONAsync(string url)
        {
            try
            {
                string responseJSON = "";
                using HttpResponseMessage response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    responseJSON = await response.Content.ReadAsStringAsync();
                }
                else { responseJSON = "404"; }

                return responseJSON;
            }
            catch(WebException ex)
            {
                Console.WriteLine(ex.Message);
                return "500";
            }
        }

        #endregion METHODS API REST

        #region METHODS

        #region GET

        //USUARIO
        public async Task<Usuario?> GetUsuarioPorCorreo(string correo)
        {
            Usuario? usuario = null;
            string usuarioJSON = await GETJSONAsync(URLAPI + URLGetUsuarioPorCorreo + correo);
            if (usuarioJSON != "404") { usuario = DeserializarJSONUsuario(usuarioJSON); }

            return usuario;
        }

        //LAPTOP
        public async Task<List<Laptop>?> GetLaptops()
        {
            List<Laptop>? laptops = null;
            string laptopsJSON = await GETJSONAsync(URLAPI + URLGetLaptops);
            if (laptopsJSON != "404") { laptops = DeserializarJSONLaptops(laptopsJSON); }
            
            return laptops;
        }

        public async Task<Laptop?> GetLaptopPorID(string id)
        {
            Laptop? laptop = null;
            string laptopJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteLaptop + id);
            if (laptopJSON != "404") { laptop = DeserializarJSONLaptop(laptopJSON); }

            return laptop;
        }

        public async Task<List<Laptop>?> GetLaptopPorModelo(string modelo)
        {
            List<Laptop>? laptops = null;
            string laptopsJSON = await GETJSONAsync(URLAPI + URLGetLaptopModelo + modelo);
            if (laptopsJSON != "404") { laptops = DeserializarJSONLaptops(laptopsJSON); }

            return laptops;
        }

        //COMPONENTES
        public async Task<Procesador?> GetProcesador(string id)
        {
            Procesador? procesador = null;
            string procesadorJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteProcesador+id);
            if(procesadorJSON != "404") { procesador = DeserializarJSONProcesador(procesadorJSON); }

            return procesador;
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
        private Usuario? DeserializarJSONUsuario(string usuarioJSON)
        {
            Usuario? usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJSON);
            return usuario;
        }

        private List<Laptop>? DeserializarJSONLaptops(string laptopsJSON)
        {
            List<Laptop>? laptops = JsonConvert.DeserializeObject<List<Laptop>>(laptopsJSON);
            return laptops;
        }

        private Laptop? DeserializarJSONLaptop(string laptopsJSON)
        {
            Laptop? laptop = JsonConvert.DeserializeObject<Laptop>(laptopsJSON);
            return laptop;
        }

        private Procesador? DeserializarJSONProcesador(string procesadorJSON)
        {
            return JsonConvert.DeserializeObject<Procesador>(procesadorJSON);
        }

        private MemoriaRam? DeserializarJSONMemoriaRam(string memoriaRamJSON)
        {
            return JsonConvert.DeserializeObject<MemoriaRam>(memoriaRamJSON);
        }

        #endregion DESERIALIZAR

        #endregion METHODS
    }
}
