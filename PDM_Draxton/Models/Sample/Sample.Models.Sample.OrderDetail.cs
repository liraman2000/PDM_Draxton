using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blazor.Models.Sample
{
    public partial class OrderDetail
    {
        [JsonPropertyName("Id")]
        public int @Id
        {
            get;
            set;
        }
        [JsonPropertyName("Quantity")]
        public int @Quantity
        {
            get;
            set;
        }
        [JsonPropertyName("OrderId")]
        public int? @OrderId
        {
            get;
            set;
        }
        [JsonPropertyName("ProductId")]
        public int? @ProductId
        {
            get;
            set;
        }
        [JsonPropertyName("Order")]
        public Order @Order
        {
            get;
            set;
        }
        [JsonPropertyName("Product")]
        public Product @Product
        {
            get;
            set;
        }
    }
}
