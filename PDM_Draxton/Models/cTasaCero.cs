namespace PDM_Draxton.Models
{
    public class cTasaCero
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string? Emisor { get; set; }
        public string? rfcEmisor { get; set; }
        public string? Receptor { get; set; }
        public string? rfcReceptor { get; set; }
        public string? Pedimento { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public int IdEstatusPedimento { get; set; }
        public int? IdEstatusAnterior { get; set; }
        public string totalFactura {get;set;}
        public string EstatusCFDI { get; set; }


    }
}
