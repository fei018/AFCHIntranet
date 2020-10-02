using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using AFCHIntranet.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Staff
{
    public class CreateModel : PageModel
    {
        private readonly StaffService _staffService;

        public CreateModel(StaffService staffService)
        {
            this._staffService = staffService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Staff_Detail Staff { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var query = await _staffService.CreateNew(Staff);
            if (query.IsSuccess)
            {
                return RedirectToPage("Details", new { id = query.Staff.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }
        }
    }
}
