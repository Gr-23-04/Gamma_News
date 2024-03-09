using Microsoft.AspNetCore.Mvc;
using Gamma_News.Services;

namespace Gamma_News.Controllers
{
	public class SearchController : Controller
	{
		private readonly IArticleService _articleService;

		public SearchController(IArticleService articleService)
		{
			_articleService = articleService;

		}
		public async Task<IActionResult> Index(string searchTerm)
		{
			var results = await _articleService.SearchArticlesAsync(searchTerm);
			return View(results);
		}




	}
}
