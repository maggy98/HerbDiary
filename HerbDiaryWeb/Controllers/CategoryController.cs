﻿using HerbDiaryWeb.Data;
using HerbDiaryWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HerbDiaryWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;  
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomerError", "The DisplayOrder cannot be exacly match the Name")
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }
    }
}