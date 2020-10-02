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
    public class DetailsModel : PageModel
    {
        private readonly StaffService _staffService;

        public DetailsModel(StaffService staffService)
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

        public Staff_Detail Staff { get; set; }
    }
}
