using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Components
{
    [ViewComponent(Name = "menu")]
    public class menu_ViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var some_function = 2;


            return View();
        }

    }
}
