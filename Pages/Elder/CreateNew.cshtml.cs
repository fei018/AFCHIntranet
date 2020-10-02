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
    public class CreateNewModel : PageModel
    {
        private readonly ElderService _elderService;

        public CreateNewModel(ElderService elderService)
        {
            _elderService = elderService;
        }


        public void OnGet()
        {
        }


        [BindProperty]
        public Elder_Detail Elder { get; set; }

        [BindProperty]
        public Elder_Family Family { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var info = new ElderInfo(Elder, Family);

            var query = await _elderService.CreateNew(info);

            if (query.IsSuccess)
            {
                return RedirectToPage("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, query.Error);
                return Page();
            }
        }
    }
}
