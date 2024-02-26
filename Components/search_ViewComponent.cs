using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Components
{
    [ViewComponent(Name = "search")]
    public class search_ViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var some_function = 1;


            return View();
        }


    }
}
