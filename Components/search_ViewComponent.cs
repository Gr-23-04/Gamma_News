using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Components
{
    public class search_ViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> async_search_viewcomp( )
        {
            var some_function = 1;


            return View( );
        }


    }
}
