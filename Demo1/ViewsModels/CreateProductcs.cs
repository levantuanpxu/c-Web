using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.ViewsModels
{
    public class CreateProductcs
    {
        public Product product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DbSet<Product> Products { get; internal set; }
    }
}
