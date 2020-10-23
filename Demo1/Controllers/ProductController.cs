using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo1.Models;
using Demo1.ViewsModels;

namespace Demo1.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Product()
        {
            ViewBag.Message = "Mì tôm Hảo Hảo";

            /*var product = new List<Product> 
            {
                new Product {Id = 1, Name = "Mỳ tôm Hảo Hảo", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Price=15.5M, Stock=500, ImageUrl="https://acecookvietnam.cdn.vccloud.vn/wp-content/uploads/2017/07/590-HH-TCC.png"},
                new Product {Id = 2, Name = "Gạo Bồ Câu", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Price=15.5M, Stock=500, ImageUrl="https://acecookvietnam.cdn.vccloud.vn/wp-content/uploads/2017/07/590-HH-TCC.png"},
                new Product {Id = 3, Name = "Mè Xửng Thiên Hương", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Price=15.5M, Stock=500, ImageUrl="https://acecookvietnam.cdn.vccloud.vn/wp-content/uploads/2017/07/590-HH-TCC.png"},
                new Product {Id = 4, Name = "Bánh Lọc", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Price=15.5M, Stock=500, ImageUrl="https://acecookvietnam.cdn.vccloud.vn/wp-content/uploads/2017/07/590-HH-TCC.png"},
                new Product {Id = 5, Name = "Bánh Tráng Trộn", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s", Price=15.5M, Stock=500, ImageUrl="https://acecookvietnam.cdn.vccloud.vn/wp-content/uploads/2017/07/590-HH-TCC.png"}
            };*/

            var products = _appDbContext.Products.Include(p => p.Category).ToList();
            

            return View(products);
        }
        public IActionResult Index()
        {
            
            var products = _appDbContext.Products;

            return View(products);
        }
     
        public IActionResult Create()
        {
            HomeIndexVM homeIndexVM = new HomeIndexVM()
            {
                Products = _appDbContext.Products.Include(p => p.Category).ToList(),
                Categories = _appDbContext.Categories
            };


            return View(homeIndexVM);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Products.Add(product);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(product);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _appDbContext.Products.Find(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Products.Update(product);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(product);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _appDbContext.Products.Find(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var product = _appDbContext.Products.Find(id);
            if (product == null) return NotFound();

            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}