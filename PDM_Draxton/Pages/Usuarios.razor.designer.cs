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
    public partial class UsuariosComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public IEnumerable<Usuario> usuario;

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

       // [Inject]
        //protected ConnectionStringService ConnectionString { get; set; }
        protected RadzenDataGrid<PDM_Draxton.Models.Usuario> grid0;
        //protected RadzenDataGrid<Blazor.Models.Sample.OrderDetail> grid1;

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

        PDM_Draxton.Models.Usuario _master;
        protected PDM_Draxton.Models.Usuario master
        {
            get
            {
                return _master;
            }
            set
            {
                if (!object.Equals(_master, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "master", NewValue = value, OldValue = _master };
                    _master = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        string _lastFilter;
        protected string lastFilter
        {
            get
            {
                return _lastFilter;
            }
            set
            {
                if (!object.Equals(_lastFilter, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "lastFilter", NewValue = value, OldValue = _lastFilter };
                    _lastFilter = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Blazor.Models.Sample.OrderDetail> _OrderDetails;
        protected IEnumerable<Blazor.Models.Sample.OrderDetail> OrderDetails
        {
            get
            {
                return _OrderDetails;
            }
            set
            {
                //if (!object.Equals(_OrderDetails, value))
                //{
                //    var args = new PropertyChangedEventArgs(){ Name = "OrderDetails", NewValue = value, OldValue = _OrderDetails };
                //    _OrderDetails = value;
                //    OnPropertyChanged(args);
                //    Reload();
                //}
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {

            DataAccess da = new DataAccess();

            //IdUsuario = _identity.IdUsuario;

            if (da.cons_Usuario(out List<Usuario> lista, out String msgError))
            {
                usuario = lista;
            }
        }



        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddUser>("Agregar Usuario", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
            Load();
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var sampleGetOrdersResult = await Sample.GetOrders(filter:$"{args.Filter}", top:args.Top, skip:args.Skip, orderby:$"{args.OrderBy}", count:args.Top != null && args.Skip != null);
                getOrdersResult = sampleGetOrdersResult.Value.AsODataEnumerable();

                getOrdersCount = sampleGetOrdersResult.Count;
            }
            catch (System.Exception sampleGetOrdersException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Orders" });
            }
        }

        protected async void Grid0Render(DataGridRenderEventArgs<PDM_Draxton.Models.Usuario> args)
        {
            if (grid0.Query.Filter != lastFilter) {
                master = grid0.View.FirstOrDefault();
            }

            if (grid0.Query.Filter != lastFilter)
            {
                await grid0.SelectRow(master);
            }

            lastFilter = grid0.Query.Filter;
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<PDM_Draxton.Models.Usuario> args)
        {
            await DialogService.OpenAsync<EditUser>("Editar Usuario", new Dictionary<string, object>() { {"Id", args.Data.Id} });
            Load();
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(PDM_Draxton.Models.Usuario args)
        {
            master = args;

            //if (args == null) {
            //    OrderDetails = null;
            //}

            //if (args != null)
            //{
            //    //var sampleGetOrderDetailsResult = await Sample.GetOrderDetails();
            //    //OrderDetails = sampleGetOrderDetailsResult.Value;
            //}
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args)
        {
            try
            {
                if (master == null)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Error", Detail = $"Seleccione el usuario" });
                    return;

                }
            }
            catch {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Warning, Summary = $"Error", Detail = $"Seleccione el usuario" });
                return;
            }
            try
            {
                if (await DialogService.Confirm("¿Desea eliminar este usuario? " + master.UserName.ToString(), "Confirmar") == true)
                {
                    //var sampleDeleteOrderResult = await Sample.DeleteOrder(id:data.Id);
                    //if (sampleDeleteOrderResult != null)
                    //{
                    var IdUsuer = master.Id;

                    DataAccess da = new DataAccess();

                    //IdUsuario = _identity.IdUsuario;

                    if (da.del_Usuario(IdUsuer, out String msgError))
                    {
                        //usuario = lista;
                        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Exito", Detail = $"Se dio de baja al Usuario" });
                    }
                }
                Load();
                //await grid0.Reload();
                    //}
                
            }
            catch (System.Exception sampleDeleteOrderException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Error al Eliminar el usuario" });
            }
        }

        protected async System.Threading.Tasks.Task SampleModelsSampleOrderDetailAddButtonClick(MouseEventArgs args)
        {
            //var dialogResult = await DialogService.OpenAsync<AddOrderDetail>("Add Order Detail", new Dictionary<string, object>() { {"undefined", master.Id} });
            //await grid1.Reload();
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(Blazor.Models.Sample.OrderDetail args)
        {
            //var dialogResult = await DialogService.OpenAsync<EditOrderDetail>("Edit Order Detail", new Dictionary<string, object>() { {"Id", args.Id} });
            //await grid1.Reload();
        }

        protected async System.Threading.Tasks.Task SampleModelsSampleOrderDetailDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            //try
            //{
            //    if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
            //    {
            //        var sampleDeleteOrderDetailResult = await Sample.DeleteOrderDetail(id:data.Id);
            //        if (sampleDeleteOrderDetailResult != null)
            //        {
            //            await grid1.Reload();
            //        }
            //    }
            //}
            //catch (System.Exception sampleDeleteOrderDetailException)
            //{
            //    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Order" });
            //}
        }
    }
}
