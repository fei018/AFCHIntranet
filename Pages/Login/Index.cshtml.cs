using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Account;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly LoginService _loginService;

        public IndexModel(LoginService loginService)
        {
            this._loginService = loginService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public LoginUser LoginUser { get; set; }

        #region µ«»Î
        public async Task<IActionResult> OnPostLogin()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var ok = await _loginService.Login(LoginUser.Name, LoginUser.Password);
            if (ok)
            {
                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "’À∫≈ªÚ√‹¬Î¥ÌŒÛ");
                return Page();
            }
        }
        #endregion

        #region µ«≥ˆ
        public async Task<IActionResult> OnGetLogout()
        {
            await _loginService.Logout();
            return RedirectToPage();
        }
        #endregion
    }
}
