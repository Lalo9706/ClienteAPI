namespace ClienteAPI.Model.POCO
{
    public class Procesador
    {
        public string? idRegistro { get; set; }
        public string? modelo { get; set; }
        public string? marca { get; set; }
        public int numeroNucleos { get; set; }
        public int numeroHilos { get; set; }
        public double velocidadMaxima { get; set; }
        public double velocidadMinima { get; set; }
        public int litografia { get; set; }
    }
}
