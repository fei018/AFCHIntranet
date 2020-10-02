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
    public class EditModel : PageModel
    {
        private readonly LoginService _loginService;

        public EditModel(LoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var query = await _loginService.GetLoginUserById(id);

            if (!query.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }

            EditUser = query.Value;
            return Page();
        }

        [BindProperty]
        public LoginUser EditUser { get; set; }

        public async Task<IActionResult> OnPostEditUserRole()
        {
            var query = await _loginService.EditLoginUserRoleName(EditUser.Id, EditUser.RoleName);
            if (!query.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }

            return RedirectToPage("/Account/Index");
        }

        public async Task<IActionResult> OnPostEditUserPassword()
        {
            var query = await _loginService.EditLoginUserPassword(EditUser.Id, EditUser.Password);
            if (!query.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }

            return RedirectToPage("/Account/Index");
        }

        public async Task<IActionResult> OnPostDeleteUser()
        {
            var query = await _loginService.DeleteLoginUserById(EditUser.Id);
            if (!query.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }

            return RedirectToPage("/Account/Index");
        }
    }
}
