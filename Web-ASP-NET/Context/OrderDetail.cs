using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ASP_NET.Context
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? CreatedAt { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }

    public class OrderDetailDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}