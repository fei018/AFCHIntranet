using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Staff
{
    public class IndexDeleteModel : PageModel
    {
        private readonly StaffService _staffService;

        public IndexDeleteModel(StaffService staffService)
        {
            this._staffService = staffService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetAllListJson()
        {
            var query = await _staffService.GetAllList();
            if (query.IsSuccess)
            {
                return new JsonResult(query.GetListJsonData());
            }
            else
            {
                return new JsonResult(query.ErrorJsonData());
            }
        }

        public async Task<IActionResult> OnGetToDelete(int id)
        {
            var query = await _staffService.DeleteStaff(id);
            if (query.IsSuccess)
            {
                return RedirectToPage();
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }
        }
    }
}
