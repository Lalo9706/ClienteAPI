using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteAPI.Model.POCO
{
    public class Laptop
    {
        public int ID { get; set; }
        public string Modelo { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
        public string Almacenamiento { get; set; }
    }
}
