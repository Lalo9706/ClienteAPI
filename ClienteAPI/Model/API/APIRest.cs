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
        public static string URLAPI = "https://web-production-2d2f.up.railway.app";
        public static string URLGetUsuarioPorCorreo = "/usuario/correo/";
        public static string URLGetLaptops = "/laptops";
        public static string URLGetLaptopID = "/laptop/";
        public static string URLGetLaptopModelo = "/laptopModelo/";

        public static async Task<string> GetUsuarioPorCorreo(string correo)
        {
            try
            {
                WebRequest onRequest = WebRequest.Create(URLAPI + URLGetUsuarioPorCorreo + correo);
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

        public static async Task<string> GetLaptops()
        {
            try
            {
                WebRequest onRequest = WebRequest.Create(URLAPI + URLGetLaptops);
                using (HttpWebResponse onResponse = (HttpWebResponse)onRequest.GetResponse())
                {
                    StreamReader reader = new StreamReader(onResponse.GetResponseStream());
                    return await reader.ReadToEndAsync();
                }
            }
            catch(WebException ex)
            {
                return "404";
            }
        }

        public static async Task<string> GetLaptopPorID(string id)
        {
            try
            {
                WebRequest onRequest = WebRequest.Create(URLAPI + URLGetLaptopID + id);
                using(WebResponse onResponse = onRequest.GetResponse())
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

        public static async Task<string> GetLaptopPorModelo(string modelo)
        {
            try
            {
                WebRequest onRequest = WebRequest.Create(URLAPI + URLGetLaptopModelo + modelo);
                using (WebResponse onResponse = onRequest.GetResponse())
                {
                    StreamReader reader = new StreamReader(onResponse.GetResponseStream());
                    return await reader.ReadToEndAsync();
                }
            }
            catch (WebException)
            {
                return "404";
            }
        }
    }
}
