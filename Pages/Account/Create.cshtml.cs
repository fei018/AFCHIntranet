using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Account;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly LoginService _loginService;

        public CreateModel(LoginService loginService)
        {
            _loginService = loginService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public LoginUser NewUser { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var query = await _loginService.CreateLoginUser(NewUser);
            if (!query.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }

            return RedirectToPage("/Account/Index");
        }
    }
}
