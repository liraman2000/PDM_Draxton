using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Blazor.Models.Sample;
using PDM_Draxton.Services;
using PDM_Draxton.Data;
using PDM_Draxton.Models;

namespace PDM_Draxton.Pages
{
    public partial class DataStageComponent : ComponentBase
    {
        public int idTasaCero;
        public int idDocumento;

        utilidades.Funciones fn = new utilidades.Funciones();

        [Parameter(CaptureUnmatchedValues = true)]

        
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SampleService Sample { get; set; }

        protected RadzenDataGrid<PDM_Draxton.Models.Documento> grid0;
        protected RadzenDataList<dynamic> datalist0;

        public string xml_doc;

        IEnumerable<Blazor.Models.Sample.Order> _getOrdersResult;
        protected IEnumerable<Blazor.Models.Sample.Order> getOrdersResult
        {
            get
            {
                return _getOrdersResult;
            }
            set
            {
                if (!object.Equals(_getOrdersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOrdersResult", NewValue = value, OldValue = _getOrdersResult };
                    _getOrdersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getOrdersCount;
        protected int getOrdersCount
        {
            get
            {
                return _getOrdersCount;
            }
            set
            {
                if (!object.Equals(_getOrdersCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOrdersCount", NewValue = value, OldValue = _getOrdersCount };
                    _getOrdersCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _isEdit;
        protected bool isEdit
        {
            get
            {
                return _isEdit;
            }
            set
            {
                if (!object.Equals(_isEdit, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "isEdit", NewValue = value, OldValue = _isEdit };
                    _isEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        PDM_Draxton.Models.Documento _documento;
        protected PDM_Draxton.Models.Documento documento // order
        {
            get
            {
                return _documento;// _order;
            }
            set
            {
                if (!object.Equals(_documento, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "documento", NewValue = value, OldValue = _documento };
                    _documento = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args)
        {
            try
            {
                if (documento == null)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Error", Detail = $"Seleccione un archivo" });
                    return;

                }
            }
            catch
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Error", Detail = $"Seleccione el usuario" });
                return;
            }
            try
            {
                if (await DialogService.Confirm("¿Desea eliminar este archivo y las incidencias relacionadas? " + documento.Archivo.ToString(),"Confirmar") == true)
                {
                    //var sampleDeleteOrderResult = await Sample.DeleteOrder(id:data.Id);
                    //if (sampleDeleteOrderResult != null)
                    //{
                    var IdDocumento = documento.Id;
                    var fecha = documento.FechaAlta;

                    var fechalimite = DateTime.Today.AddDays(-30);
                    if (fechalimite > Convert.ToDateTime(fecha))
                        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Error", Detail = $"Solo permite borrar archivos en un período de 30 dias" });                   
                    else
                    {
                        DataAccess da = new DataAccess();

                        //IdUsuario = _identity.IdUsuario;

                        if (da.del_Documento(IdDocumento, out String msgError))
                        {
                            //usuario = lista;
                            NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Exito", Detail = $"Se borraron los datos del DataStage y sus Incidencias" });
                        }
                    }

                    IdDocumento = 0;
                }
                //Load();
                //  Reload();
                // await grid0.Reload();
                //}
                
                OnInitializedAsync();
            }
            catch (System.Exception sampleDeleteOrderException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Error al Eliminar el archivo" });
            }
        }


        protected async System.Threading.Tasks.Task Grid0RowSelect(PDM_Draxton.Models.Documento args)//. Blazor.Models.Sample.Order args)
        {
            isEdit = false;

            //tasaCero = args;

            documento = args;

            DataAccess da = new DataAccess();
            idDocumento = args.Id;
            //string UUID = args.UUID;      

            //if (da.cons_XML(idTasaCero,UUID, out XML xml, out String msgError))
            //{
            //    xml_doc = xml.Xml_doc;
            //    xml_doc = fn.PrettyXml(xml_doc);

            //  //  lObservaciones = incObs;
            //}
        }

        protected async System.Threading.Tasks.Task Datagrid0LoadData(LoadDataArgs args)
        {
            var sampleGetOrdersResult = await Sample.GetOrders(filter:$"{args.Filter}", top:args.Top, skip:args.Skip, orderby:$"{args.OrderBy}", count:args.Top != null && args.Skip != null);
            getOrdersResult = sampleGetOrdersResult.Value.AsODataEnumerable();

            getOrdersCount = sampleGetOrdersResult.Count;
        }
    }
}
