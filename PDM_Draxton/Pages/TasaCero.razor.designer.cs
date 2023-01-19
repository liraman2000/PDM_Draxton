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
using Azure;

namespace PDM_Draxton.Pages
{
    public partial class TasaCeroComponent : ComponentBase
    {
        public int idTasaCero;
        public string filePath = String.Empty;
        public string filename = String.Empty;

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

        protected RadzenDataGrid<PDM_Draxton.Models.cTasaCero> datagrid0;
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

        PDM_Draxton.Models.cTasaCero _tasaCero;
        protected PDM_Draxton.Models.cTasaCero tasaCero // order
        {
            get
            {
                return _tasaCero;// _order;
            }
            set
            {
                if (!object.Equals(_tasaCero, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "tasaCero", NewValue = value, OldValue = _tasaCero };
                    _tasaCero = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public async void ButtonDescargar_click()
        {
            try
            {
                await JSRuntime.InvokeVoidAsync(
                    "downloadFromUrl",
                    new { Url = filePath+"\\"+ filename, FileName = filename });

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
         
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(PDM_Draxton.Models.cTasaCero args)//. Blazor.Models.Sample.Order args)
        {
            isEdit = false;

            //tasaCero = args;

            DataAccess da = new DataAccess();
            idTasaCero = args.Id;
            var folio = args.Folio;
            string UUID = args.UUID;


            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            filePath = config.GetValue<string>("Parameter:urlXML");
            var uploadPath = "wwwroot/" + filePath;

            if (da.cons_XML(idTasaCero,UUID, out XML xml, out String msgError))
            {
                xml_doc = xml.Xml_doc;
                xml_doc = fn.PrettyXml(xml_doc);

                filename = folio.ToString() + "_Timbrado.xml";
                try
                {

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }


                    var fullPath = Path.Combine(uploadPath, filename);

                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }


                    StreamWriter sw = new StreamWriter(fullPath);

                    sw.WriteLine(xml_doc);

                    sw.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        protected async System.Threading.Tasks.Task Datagrid0LoadData(LoadDataArgs args)
        {
            var sampleGetOrdersResult = await Sample.GetOrders(filter:$"{args.Filter}", top:args.Top, skip:args.Skip, orderby:$"{args.OrderBy}", count:args.Top != null && args.Skip != null);
            getOrdersResult = sampleGetOrdersResult.Value.AsODataEnumerable();

            getOrdersCount = sampleGetOrdersResult.Count;
        }
    }
}
