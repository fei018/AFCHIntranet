using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Staff
{
    public class DownloadModel : PageModel
    {
        private readonly StaffService _staffService;

        public DownloadModel(StaffService staffService)
        {
            this._staffService = staffService;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// 下载 在职 Excel
        /// </summary>
        public async Task<IActionResult> OnGetExcelWorking()
        {
            var query = await _staffService.ExcelStaffWorkingList();
            if (query.IsSuccess)
            {
                return File(query.Value, query.MimeType, query.ValueName);
            }
            else
            {
                ViewData["Error"] = query.Error;
                return Page();
            }
        }

        /// <summary>
        /// 上传excel模板数据
        /// </summary>
        public async Task<IActionResult> OnPostUploadExcel(IFormFile uploadExcel)
        {
            var query = await _staffService.UploadExcelToDB(uploadExcel);
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
