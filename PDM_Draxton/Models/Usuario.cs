namespace PDM_Draxton.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? UserName { get; set; }
        public int OrgId { get; set; }
        public int Nomina { get; set; }
        public string? Planta { get; set; }
        public string? Departamento { get; set; }
        public string? Puesto { get; set; }
        public int IdRol { get; set; }
        public string? Rol { get; set; }
        //public int IdUsuario { get; set; }

    }
}
