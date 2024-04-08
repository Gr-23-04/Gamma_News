using Gamma_News.Data;
using Gamma_News.Models.ViewModels;
using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gamma_News.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _db;

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
            //_articleService.AddCategories();
            var Category = _articleService.GetAllCategories();
            ViewBag.Categories = new SelectList(Category, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article newArticle)
        {
            newArticle.CreatedDate = DateTime.Now;
            newArticle.ImageLink = _articleService.UploadImage(newArticle.Image).Result;
            _articleService.CreateArticle(newArticle);
            return View();

        }
        [HttpGet]
        public IActionResult AddArticle()
        {
            var Category = _articleService.GetAllCategories();
            ViewBag.Categories = new SelectList(Category, "Id", "Name");
            return View();


        }









    }
}

