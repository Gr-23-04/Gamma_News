﻿using Gamma_News.Models.ViewModels;
using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Controllers
{
    public class ArticleController : Controller
    {
       
        private readonly IArticleService _articleService;
       public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article newArticle)
        {
            newArticle.CreatedDate = DateTime.Now;
            _articleService.CreateArticle(newArticle);
            return View();
        }

    }
}