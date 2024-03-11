using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Components
{
    [ViewComponent(Name = "Search")]
    public class search_ViewComponent : ViewComponent
    {
		private readonly IArticleService _articleService;
		public search_ViewComponent(IArticleService articleService) 
        {
            _articleService = articleService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string searchTerm = HttpContext.Request.Query["searchTerm"];

            return View((object)searchTerm);
        }

        


    }
}
