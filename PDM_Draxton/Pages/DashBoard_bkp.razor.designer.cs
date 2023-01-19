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
    public partial class DashBoardComponent : ComponentBase
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
        protected RadzenDataGrid<Blazor.Models.Sample.OrderDetail> datagrid0;

        IEnumerable<Blazor.Models.Sample.OrderDetail> _getOrderDetailsResult;
        protected IEnumerable<Blazor.Models.Sample.OrderDetail> getOrderDetailsResult
        {
            get
            {
                return _getOrderDetailsResult;
            }
            set
            {
                if (!object.Equals(_getOrderDetailsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOrderDetailsResult", NewValue = value, OldValue = _getOrderDetailsResult };
                    _getOrderDetailsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getOrderDetailsCount;
        protected int getOrderDetailsCount
        {
            get
            {
                return _getOrderDetailsCount;
            }
            set
            {
                if (!object.Equals(_getOrderDetailsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOrderDetailsCount", NewValue = value, OldValue = _getOrderDetailsCount };
                    _getOrderDetailsCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected async System.Threading.Tasks.Task Datagrid0LoadData(LoadDataArgs args)
        {
            var sampleGetOrderDetailsResult = await Sample.GetOrderDetails(filter:$"{args.Filter}", top:args.Top, skip:args.Skip, orderby:$"{args.OrderBy}", count:args.Top != null && args.Skip != null);
            getOrderDetailsResult = sampleGetOrderDetailsResult.Value.AsODataEnumerable();

            getOrderDetailsCount = sampleGetOrderDetailsResult.Count;
        }
    }
}
