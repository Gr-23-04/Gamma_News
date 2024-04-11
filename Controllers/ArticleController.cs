using Gamma_News.Data;
using Gamma_News.Models.ViewModels;
using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;


namespace Gamma_News.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService, ApplicationDbContext db)
        {
            _articleService = articleService;
            _db = db;
        }




        public async Task<IActionResult> Index()
        {





            //var articles = await _articleService.GetAllArticles();

            //article = articles.Where(a => a.Id == article.Id).Select(a => a).First();



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

        public async Task<IActionResult> Details(int? id) 
        {
            
            if (id == null) 
            {
                return NotFound();
            }

            var article = await _db.Articles.FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }
        //public IActionResult Details() 
        //{
        //    return View();
        //}








    }
}

