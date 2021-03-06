﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities;
using ShopAppUI.Models;

namespace ShopAppUI.Controllers
{
    public class ShopController : Controller
    {
        //INJECT METHOD
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails(Convert.ToInt32(id));
            if(product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i=>i.Category).ToList()
            });
        }

        public IActionResult List(string category,int page = 1)
        {
            const int productCount = 3;
            return View(new ProductListModel()
            {
                Products = _productService.GetProductsByCategory(category,page, productCount)
            });
        }
    }
}
