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
    public class IndexModel : PageModel
    {
        private readonly LoginService _loginService;

        public IndexModel(LoginService loginService)
        {
            _loginService = loginService;
            this._loginService = loginService;
        }

        public async Task<IActionResult> OnGet()
        {
            var query = await _loginService.GetLoginUserList();
            if (!query.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }

            UserList = query.Value;
            return Page();
        }

        public List<LoginUser> UserList { get; set; }
    }
}
