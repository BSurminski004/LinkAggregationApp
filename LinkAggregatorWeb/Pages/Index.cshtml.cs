using LinkAggregation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Password { get; } = "LetMeIn";
        public string InputPassword { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            InputPassword = "";
            _logger = logger;
        }

        public async Task<IActionResult> OnPost()
        {
            if (InputPassword != Password)
            {
                ModelState.AddModelError("InputPassword", " Well that was miss, try again!");
            }
            else
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}