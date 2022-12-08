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
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ClienteAPI.Model.API
{
    public class APIRest
    {

        public static string URLGetUsuarioPorCorreo = "https://web-production-2d2f.up.railway.app/usuario/correo/";

        public static async Task<string> GetUsuarioPorCorreo(string correo)
        {
            try
            {
                WebRequest onRequest = WebRequest.Create(URLGetUsuarioPorCorreo + correo);
                using (HttpWebResponse onResponse = (HttpWebResponse)onRequest.GetResponse())
                {
                    StreamReader reader = new StreamReader(onResponse.GetResponseStream());
                    return await reader.ReadToEndAsync();
                }
            }
            catch (WebException ex)
            {
                return "404";
            }
        }

    }
}
