namespace PDM_Draxton.Models
{
    public class cDashboard
    {
        public int IdPeriodo { get; set; }
        public int IdPeriodoNegocio { get; set; }
        public int IdNegocio { get; set; }
        public int DocumentosTotales { get; set; }
        public int Incidencias { get; set; }
        public int Activas { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaUltimaActualizacion { get; set; }
        public string Negocio { get; set; }
        public string Estatus { get; set; }
        public string Periodo { get; set; }
        public string Clave { get; set; }
    }
}
