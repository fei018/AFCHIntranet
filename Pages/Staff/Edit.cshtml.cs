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
    public class EditModel : PageModel
    {
        private readonly StaffService _staffService;

        public EditModel(StaffService staffService)
        {
            this._staffService = staffService;
        }

        public async Task OnGet(int id)
        {
            var query = await _staffService.GetStaffById(id);
            if (query.IsSuccess)
            {
                Staff = query.Staff;
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
            }
        }

        [BindProperty]
        public Staff_Detail Staff { get; set; }

        public async Task<IActionResult> OnPostUpdateStaff()
        {
            var query = await _staffService.UpdateStaff(Staff);
            if (query.IsSuccess)
            {
                return RedirectToPage("Details", new { id = query.Staff.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
                Staff = query.Staff;
                return Page();
            }
        }
    }
}
