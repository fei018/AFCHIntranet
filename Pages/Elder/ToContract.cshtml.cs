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
    public class ToContractModel : PageModel
    {
        private readonly ElderService _elderService;

        public ToContractModel(ElderService elderService)
        {
            this._elderService = elderService;
            
        }

        [BindProperty]
        public Elder_Detail Elder { get; set; }

        public async Task<IActionResult> OnGet(int id, string returnPage)
        {
            ViewData["ReturnPage"] = returnPage;

            var query = await _elderService.GetElderAndFamilyById(id);
            if (query.IsSuccess)
            {
                Elder = query.Elder;
                return Page();
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var query = await _elderService.ElderToContract(Elder);
            if (query.IsSuccess)
            {
                return RedirectToPage("Details", new { id = Elder.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }
        }
    }
}
