namespace PDM_Draxton.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string Archivo { get; set; }
        public int IdNegocio { get; set; }
        public string Negocio { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string FechaAlta { get; set; }
    }
}
