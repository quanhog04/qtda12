using System;
using System.ComponentModel.DataAnnotations;

namespace Web_ASP_NET.Context
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public bool? ShowOnHomePage { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Deleted { get; set; }
    }
}