using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_ASP_NET.Context
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ShortDes { get; set; }
        public bool? ShowOnHomePage { get; set; }
        public string FullDescription { get; set; }
        public double Price { get; set; }
        public double? PriceDiscount { get; set; }
        public int? TypeId { get; set; }
        public string Slug { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Deleted { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}