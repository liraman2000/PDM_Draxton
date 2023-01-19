namespace PDM_Draxton.Models
{
    public class cDataStage
    {
        public int Id { get; set; }
        public int IdPeriodo { get; set; }
        public string? PedimentoCompleto { get; set; }
        public string? Patente { get; set; }
        public string? Pedimento { get; set; }
        public string? SeccionAduanera { get; set; }
        public string? FechaFacturacion { get; set; }
        public string? NumeroFactura { get; set; }
        public string? TerminoFacturacion { get; set; }
        public string? MonedaFacturacion { get; set; }
        public string? ValorDolares { get; set; }
        public string? ValorMonedaExtranjera{ get; set; }
        public string? PaisFacturacion { get; set; }
        public string? EntidadFedFacturacion { get; set; }
        public string? IdentFiscalFacturacion { get; set; }
        public string? ProveedorMercancia { get; set; }
        public string? CalleProveedor { get; set; }
        public string? NumInteriorProveedor { get; set; }
        public string? NumExteriorProveedor { get; set; }
        public string? CPProveedor { get; set; }
        public string? MunicipioProveedor { get; set; }
        public string? FechaPagoReal { get; set; }      
        public int IdUsuarioCaptura { get; set; }
        public string? Estatus { get; set; }

    }
}
