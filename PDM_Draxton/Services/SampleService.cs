
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Blazor.Models.Sample;

namespace PDM_Draxton.Services
{
    public partial class SampleService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        public SampleService(IConfiguration configuration)
        {
            this.httpClient = new HttpClient();

            //this.baseUri = new Uri(configuration["SampleBaseUri"]);
        }
        partial void OnGetOrders(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Order>> GetOrders(string filter = default(string), int? top = default(int?), int? skip = default(int?), string orderby = default(string), string expand = default(string), string select = default(string), bool? count = default(bool?))
        {
            var uri = new Uri(baseUri, $"Orders");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOrders(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Order>>(response);
        }
        partial void OnCreateOrder(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Order> CreateOrder(dynamic order)
        {
            var uri = new Uri(baseUri, $"Orders");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            OnCreateOrder(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Order>(response);
        }
        partial void OnGetOrderById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Order> GetOrderById(int id)
        {
            var uri = new Uri(baseUri, $"Orders({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOrderById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Order>(response);
        }
        partial void OnDeleteOrder(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteOrder(int id)
        {
            var uri = new Uri(baseUri, $"Orders({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteOrder(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnUpdateOrder(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Order> UpdateOrder(int id, dynamic order)
        {
            var uri = new Uri(baseUri, $"Orders({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(order), Encoding.UTF8, "application/json");

            OnUpdateOrder(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Order>(response);
        }
        partial void OnGetOrderDetails(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<OrderDetail>> GetOrderDetails(string filter = default(string), int? top = default(int?), int? skip = default(int?), string orderby = default(string), string expand = default(string), string select = default(string), bool? count = default(bool?))
        {
            var uri = new Uri(baseUri, $"OrderDetails");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOrderDetails(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<OrderDetail>>(response);
        }
        partial void OnCreateOrderDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<OrderDetail> CreateOrderDetail(dynamic orderDetail)
        {
            var uri = new Uri(baseUri, $"OrderDetails");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(orderDetail), Encoding.UTF8, "application/json");

            OnCreateOrderDetail(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<OrderDetail>(response);
        }
        partial void OnGetOrderDetailById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<OrderDetail> GetOrderDetailById(int id)
        {
            var uri = new Uri(baseUri, $"OrderDetails({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetOrderDetailById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<OrderDetail>(response);
        }
        partial void OnDeleteOrderDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteOrderDetail(int id)
        {
            var uri = new Uri(baseUri, $"OrderDetails({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteOrderDetail(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnUpdateOrderDetail(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<OrderDetail> UpdateOrderDetail(int id, dynamic orderDetail)
        {
            var uri = new Uri(baseUri, $"OrderDetails({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(orderDetail), Encoding.UTF8, "application/json");

            OnUpdateOrderDetail(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<OrderDetail>(response);
        }
        partial void OnGetProducts(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<Product>> GetProducts(string filter = default(string), int? top = default(int?), int? skip = default(int?), string orderby = default(string), string expand = default(string), string select = default(string), bool? count = default(bool?))
        {
            var uri = new Uri(baseUri, $"Products");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProducts(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Product>>(response);
        }
        partial void OnCreateProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Product> CreateProduct(dynamic product)
        {
            var uri = new Uri(baseUri, $"Products");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            OnCreateProduct(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Product>(response);
        }
        partial void OnGetProductById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Product> GetProductById(int id)
        {
            var uri = new Uri(baseUri, $"Products({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetProductById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Product>(response);
        }
        partial void OnDeleteProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteProduct(int id)
        {
            var uri = new Uri(baseUri, $"Products({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteProduct(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnUpdateProduct(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Product> UpdateProduct(int id, dynamic product)
        {
            var uri = new Uri(baseUri, $"Products({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            OnUpdateProduct(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Product>(response);
        }
    }
}
