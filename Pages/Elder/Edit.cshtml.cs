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
    public class EditModel : PageModel
    {
        private readonly ElderService _elderService;

        public EditModel(ElderService elderService)
        {
            this._elderService = elderService;
        }

        [BindProperty]
        public Elder_Detail Elder { get; set; }

        [BindProperty]
        public Elder_Family Family { get; set; }

        public async Task OnGet(int id)
        {
            var query = await _elderService.GetElderAndFamilyById(id);
            if (query.IsSuccess)
            {
                Elder = query.Elder;
                Family = query.Family;
            }
        }

        /// <summary>
        /// 更新 老人和托养人数据
        /// </summary>
        public async Task<IActionResult> OnPostUpdateElder()
        {
            var info = new ElderInfo(Elder, Family);

            var query = await _elderService.UpdateElderAndFamily(info);
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
