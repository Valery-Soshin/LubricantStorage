using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LubricantStorage.UI.Web.Pages.Auth
{
    public class SignoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Response.Cookies.Delete("JwtToken");
            return RedirectToPage("/Lubricants/Index");
        }
    }
}