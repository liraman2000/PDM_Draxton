using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blazor.Models.Sample
{
    public partial class Product
    {
        [JsonPropertyName("Id")]
        public int @Id
        {
            get;
            set;
        }
        [JsonPropertyName("ProductName")]
        public string @ProductName
        {
            get;
            set;
        }
        [JsonPropertyName("ProductPrice")]
        public double @ProductPrice
        {
            get;
            set;
        }
        [JsonPropertyName("ProductPicture")]
        public string @ProductPicture
        {
            get;
            set;
        }
        [JsonPropertyName("OrderDetails")]
        public IEnumerable<OrderDetail> @OrderDetails
        {
            get;
            set;
        }
    }
}
