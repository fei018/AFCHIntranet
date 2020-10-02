using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Elder;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Elder
{
    public class DetailsModel : PageModel
    {
        private readonly ElderService _elderService;

        public DetailsModel(ElderService elderService)
        {
            this._elderService = elderService;
        }

        [BindProperty]
        public Elder_Detail Elder { get; set; }

        [BindProperty]
        public Elder_Family Family { get; set; }

        public async Task<IActionResult> OnGet(int id, string returnPage)
        {
            ViewData["ReturnPage"] = returnPage;

            var query = await _elderService.GetElderAndFamilyById(id);
            if (query.IsSuccess)
            {
                Elder = query.Elder;
                Family = query.Family;
                return Page();
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }
        }
     
    }
}
