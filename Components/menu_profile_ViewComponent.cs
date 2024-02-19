using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Components
{
    public class menu_profile_ViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> async_menu_viewcomp( )
        {
            var some_function = 3;


            return View( );
        }

    }
}
