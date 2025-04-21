using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ASP_NET.Context
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}