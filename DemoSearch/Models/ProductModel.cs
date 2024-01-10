using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoSearch.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Price { get; set; }
        public string MfgDate { get; set; }
        public string Category { get; set; }

    }
}