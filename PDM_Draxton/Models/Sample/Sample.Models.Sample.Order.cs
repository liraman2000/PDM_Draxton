using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blazor.Models.Sample
{
    public partial class Order
    {
        [JsonPropertyName("Id")]
        public int @Id
        {
            get;
            set;
        }
        [JsonPropertyName("UserName")]
        public string @UserName
        {
            get;
            set;
        }
        [JsonPropertyName("OrderDate")]
        public DateTime @OrderDate
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
