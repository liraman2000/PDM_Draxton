namespace PDM_Draxton.Models
{
    public class Incidencia
    {
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public string FechaFacturacion { get; set; }
        public string Pedimento { get; set; }
        public string Estatus { get; set; }
        public string? Proveedor { get; set; }

        public string Total { get; set; }

        public string? EstatusPeriodoNegocio { get; set; }
    }
}
