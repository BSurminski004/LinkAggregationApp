using LinkAggregation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinkAggregatorWeb.Pages
{
    public class IndexModel : PageModel
    {
        private const string CorrectPassword = "pass123"; 
        private const int MaxAttempts = 3;

        [BindProperty]
        public string Password { get; set; }
        [TempData]
        public int AttemptsRemaining { get; set; }
        public bool IsLoggedIn { get; private set; }

        public void OnGet()
        {
            
            AttemptsRemaining = MaxAttempts;
            IsLoggedIn = false;
        }
        public async Task<IActionResult> OnPost()
        {
            if (Password == CorrectPassword)
            {
                IsLoggedIn = true;
                return Page();
            }
            else
            {
                AttemptsRemaining--;

                if (AttemptsRemaining == 0)
                {
                    ModelState.AddModelError(string.Empty, "Too many incorrect attempts. Please try again later.");
                    return Page();
                }

                ModelState.AddModelError("Password", $"Incorrect password. {AttemptsRemaining} attempts remaining.");
                return Page();
            }
        }
    }
}