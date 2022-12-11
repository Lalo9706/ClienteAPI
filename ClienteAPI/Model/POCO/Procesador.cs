namespace ClienteAPI.Model.POCO
{
    public class Procesador
    {
        public string? IdRegistro { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
        public int? NumeroNucleos { get; set; }
        public int? NumeroHilos { get; set; }
        public double? VelocidadMinima { get; set; }
        public double? VelocidadMaxima { get; set; }
        public int? Litografia { get; set; }
    }
}
