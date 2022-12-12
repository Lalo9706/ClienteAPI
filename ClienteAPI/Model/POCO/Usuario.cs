namespace ClienteAPI.Model.POCO
{
    public class Usuario
    {
        public string? nombreUsuario { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public string? correoElectronico { get; set; }
        public string? contrasena { get; set; }
        public int? administrador { get; set; }
    }
}
