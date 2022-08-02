using System;
using System.Collections.Generic;

namespace CarShop.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? CarId { get; set; }
        public string? UserTel { get; set; }
        public string? Status { get; set; }
    }
}
