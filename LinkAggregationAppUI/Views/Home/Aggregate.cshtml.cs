using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregationAppUI.Views.Home
{
    public class AggregateModel : PageModel
    {
        public string? urlToRedirect;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Redirect(urlToRedirect);
        }

        public void onClickRedirect(string url)
        {
            Response.Redirect(url);
        }
    }
}
