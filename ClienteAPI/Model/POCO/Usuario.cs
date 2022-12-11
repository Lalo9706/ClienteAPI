namespace ClienteAPI.Model.POCO
{
    public class Usuario
    {
        public string? NombreUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public int? Administrador { get; set; }
    }
}
