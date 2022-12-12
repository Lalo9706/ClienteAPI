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
        #region HTTPCLIENT

        private readonly HttpClient client = new();

        #endregion

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
        private static readonly string URLPutProcesadorA = "/procesador/";
        private static readonly string URLPutProcesadorB = "?procesador_id=$idRegistro";

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

        #region METHODS API CRUD HTTP

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
        public async Task<string> POSTJSONAsync(string url, object objeto)
        {
            string objectJSON = JsonConvert.SerializeObject(objeto);

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
        public async Task<string> PUTJSONAsync(string url, object objeto)
        {
            string objectJSON = JsonConvert.SerializeObject(objeto);

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

        #endregion METHODS API CRUD HTTP

        #region METHODS CRUD

        #region GET

        //USUARIO

        public async Task<Usuario?> GetUsuario(string id)
        {
            Usuario? usuario = null;
            string usuarioJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteUsuario + id);
            if (usuarioJSON != "404") { usuario = DeserializarJSONUsuario(usuarioJSON); }

            return usuario;
        }

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

        public async Task<MemoriaRam?> GetMemoriaRam(string id)
        {
            MemoriaRam? memoriaRam = null;
            string memoriaRamJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteMemoriaRam + id);
            if (memoriaRamJSON != "404") { memoriaRam = DeserializarJSONMemoriaRam(memoriaRamJSON); }

            return memoriaRam;
        }

        public async Task<Almacenamiento?> GetAlmacenamiento(string id)
        {
            Almacenamiento? almacenamiento = null;
            string almacenamientoJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteAlmacenamiento + id);
            if (almacenamientoJSON != "404") { almacenamiento = DeserializarJSONAlmacenamiento(almacenamientoJSON); }

            return almacenamiento;
        }

        public async Task<HDD?> GetHDD(string id)
        {
            HDD? hdd = null;
            string hddJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteHDD + id);
            if (hddJSON != "404") { hdd = DeserializarJSONHDD(hddJSON); }

            return hdd;
        }

        public async Task<SSD?> GetSSD(string id)
        {
            SSD? ssd = null;
            string ssdJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteSSD + id);
            if (ssdJSON != "404") { ssd = DeserializarJSONSSD(ssdJSON); }

            return ssd;
        }

        public async Task<TarjetaVideo?> GetTarjetaVideo(string id)
        {
            TarjetaVideo? tarjetaVideo = null;
            string tarjetaVideoJSON = await GETJSONAsync(URLAPI + URLGetPutDeleteTarjetaVideo + id);
            if (tarjetaVideoJSON != "404") { tarjetaVideo = DeserializarJSONTarjetaVideo(tarjetaVideoJSON); }

            return tarjetaVideo;
        }

        public async Task<Pantalla?> GetPantalla(string id)
        {
            Pantalla? pantalla = null;
            string pantallaJSON = await GETJSONAsync(URLAPI + URLGetPutDeletePantalla + id);
            if (pantallaJSON != "404") { pantalla = DeserializarJSONPantalla(pantallaJSON); }

            return pantalla;
        }

        #endregion GET

        #region POST
        public async Task<string> PostLaptop(Laptop laptop)
        {
            string response = await POSTJSONAsync(URLAPI + URLPostLaptop, laptop);
            if(response != "500")
            {
                Laptop? laptopRegistrada = DeserializarJSONLaptop(response);
                string? idRegistro = laptopRegistrada.idRegistro;
                return idRegistro;
            }
            else
            {
                return response;
            }
            
        }

        public async Task<string> PostUsuario(Usuario usuario)
        {
            return await POSTJSONAsync(URLAPI + URLPostUsuario, usuario);
        }

        public async Task<string> PostProcesador(Procesador procesador)
        {
            return await POSTJSONAsync(URLAPI + URLPostProcesador, procesador);
        }

        public async Task<string> PostMemoriaRam(MemoriaRam memoriaRam)
        {
            return await POSTJSONAsync(URLAPI + URLPostMemoriaRam, memoriaRam);
        }

        public async Task<string> PostAlmacenamiento(Almacenamiento almacenamiento)
        {
            return await POSTJSONAsync(URLAPI + URLPostAlmacenamiento, almacenamiento);
        }

        public async Task<string> PostHDD(HDD hdd)
        {
            return await POSTJSONAsync(URLAPI + URLPostHDD, hdd);
        }

        public async Task<string> PostSSD(SSD ssd)
        {
            return await POSTJSONAsync(URLAPI + URLPostSSD, ssd);
        }

        public async Task<string> PostTarjetaVideo(TarjetaVideo tarjetaVideo)
        {
            return await POSTJSONAsync(URLAPI + URLPostTarjetaVideo, tarjetaVideo);
        }

        public async Task<string> PostPantalla(Pantalla pantalla)
        {
            return await POSTJSONAsync(URLAPI + URLPostPantalla, pantalla);
        }

        #endregion POST

        #region PUT

        public async Task<string> PutProcesador(Procesador procesador)
        {
            return await PUTJSONAsync(URLAPI + URLPutProcesadorA + procesador.idRegistro + URLPutProcesadorB, procesador);
        }

        #endregion PUT

        #region DELETE

        #endregion DELETE

        #endregion METHODS

        #region DESERIALIZE
        private static Usuario? DeserializarJSONUsuario(string usuarioJSON)
        {
            Usuario? usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJSON);
            return usuario;
        }

        private static List<Laptop>? DeserializarJSONLaptops(string laptopsJSON)
        {
            List<Laptop>? laptops = JsonConvert.DeserializeObject<List<Laptop>>(laptopsJSON);
            return laptops;
        }

        private static Laptop? DeserializarJSONLaptop(string laptopJSON)
        {
            Laptop? laptop = JsonConvert.DeserializeObject<Laptop>(laptopJSON);
            return laptop;
        }

        private static Procesador? DeserializarJSONProcesador(string procesadorJSON)
        {
            return JsonConvert.DeserializeObject<Procesador>(procesadorJSON);
        }

        private static MemoriaRam? DeserializarJSONMemoriaRam(string memoriaRamJSON)
        {
            return JsonConvert.DeserializeObject<MemoriaRam>(memoriaRamJSON);
        }

        private static Almacenamiento? DeserializarJSONAlmacenamiento(string almacenamientoJSON)
        {
            return JsonConvert.DeserializeObject<Almacenamiento>(almacenamientoJSON);
        }

        private static HDD? DeserializarJSONHDD(string hddJSON)
        {
            return JsonConvert.DeserializeObject<HDD>(hddJSON);
        }

        private static SSD? DeserializarJSONSSD(string ssdJSON)
        {
            return JsonConvert.DeserializeObject<SSD>(ssdJSON);
        }

        private static TarjetaVideo? DeserializarJSONTarjetaVideo(string tarjetaVideoJSON)
        {
            return JsonConvert.DeserializeObject<TarjetaVideo>(tarjetaVideoJSON);
        }

        private static Pantalla? DeserializarJSONPantalla(string pantallaJSON)
        {
            return JsonConvert.DeserializeObject<Pantalla>(pantallaJSON);
        }

        #endregion DESERIALIZAR
    }
}
