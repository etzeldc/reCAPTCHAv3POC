using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using reCAPTCHAv3POC.Interfaces;
using reCAPTCHAv3POC.Requests;
using reCAPTCHAv3POC.Responses;

namespace reCAPTCHAv3POC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISignupService signupService;

        public IndexModel(ILogger<IndexModel> logger, ISignupService signupService)
        {
            _logger = logger;
            this.signupService = signupService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSignupAsync(SignupRequest signup)
        {
            if (signup == null)
            {
                return BadRequest(new SignupResponse() { Success = false, Error = "Invalid signup request", ErrorCode = "S01" });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(c => c.ErrorMessage)).ToList();
                if (errors.Any())
                {
                    return BadRequest(new SignupResponse
                    {
                        Error = $"{string.Join(",", errors)}",
                        ErrorCode = "S02"
                    });
                }
            }

            var response = await signupService.Signup(signup);

            if (!response.Success)
            {
                return Redirect("/");
            }

            return Redirect("/");
        }
    }
}