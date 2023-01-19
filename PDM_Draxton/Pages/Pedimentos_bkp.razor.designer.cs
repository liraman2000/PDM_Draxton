using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using ComercioExteriorBlazor.Services;

namespace ComercioExteriorBlazor.Pages
{
    public partial class PedimentosComponent : ComponentBase
    {
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

        protected RadzenDataGrid<ComercioExteriorBlazor.Models.Pedimento> grid0;

        IEnumerable<ComercioExteriorBlazor.Models.Pedimento> _getProductsResult;
        protected IEnumerable<ComercioExteriorBlazor.Models.Pedimento> getProductsResult
        {
            get
            {
                return _getProductsResult;
            }
            set
            {
                if (!object.Equals(_getProductsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsResult", NewValue = value, OldValue = _getProductsResult };
                    _getProductsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getProductsCount;
        protected int getProductsCount
        {
            get
            {
                return _getProductsCount;
            }
            set
            {
                if (!object.Equals(_getProductsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProductsCount", NewValue = value, OldValue = _getProductsCount };
                    _getProductsCount = value;
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
                    var args = new PropertyChangedEventArgs(){ Name = "isEdit", NewValue = value, OldValue = _isEdit };
                    _isEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        ComercioExteriorBlazor.Models.Pedimento _pedimento;
        protected ComercioExteriorBlazor.Models.Pedimento pedimento
        {
            get
            {
                return _pedimento;
            }
            set
            {
                if (!object.Equals(_pedimento, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "pedimento", NewValue = value, OldValue = _pedimento };
                    _pedimento = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {

        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
           // try
            //{
            //    var sampleGetProductsResult = await Sample.GetProducts(filter:$"{args.Filter}", top:args.Top, skip:args.Skip, orderby:$"{args.OrderBy}", expand:$"OrderDetails", count:args.Top != null && args.Skip != null);
            //    getProductsResult = sampleGetProductsResult.Value.AsODataEnumerable();

            //    getProductsCount = sampleGetProductsResult.Count;
            //}
            //catch (System.Exception sampleGetProductsException)
            //{
            //    NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Products" });
            //}
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(ComercioExteriorBlazor.Models.Pedimento args)
        {
            isEdit = true;

            pedimento = args;
        }

        protected async System.Threading.Tasks.Task Form0Submit(ComercioExteriorBlazor.Models.Pedimento args)
        {
            //try
            //{
            //    if (isEdit)
            //    {
            //        var sampleUpdateProductResult = await Sample.UpdateProduct(id: pedimento.Id, product: pedimento);
            //        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Success", Detail = $"Product updated!" });


            //    }
            //}
            //catch (System.Exception sampleUpdateProductException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to update Product" });
            //}

            //try
            //{
            //    if (!this.isEdit)
            //    {
            //        var sampleCreateProductResult = await Sample.CreateProduct(product: args);
            //        pedimento = new ComercioExteriorBlazor.Models.Pedimento();

            //        NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = $"Success", Detail = $"Product created!" });
            //    }
            //}
            //catch (System.Exception sampleCreateProductException)
            //{
            //    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Unable to create new Product!" });
            //}
        }
    }
}
