using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoSearch.Models
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("name=ProductConnectionStrings")
        {

        }

        public DbSet<ProductModel> Products { get; set; }
    }
}