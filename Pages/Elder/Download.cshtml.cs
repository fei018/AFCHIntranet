using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Elder
{
    public class DownloadModel : PageModel
    {
        private readonly ElderService _elderService;

        public DownloadModel(ElderService elderService)
        {
            this._elderService = elderService;
        }

        public void OnGet()
        {           
        }

        /// <summary>
        /// 下载 所有 入住 Excel
        /// </summary>
        public async Task<IActionResult> OnGetExcelLiveAt()
        {
            var query = await _elderService.ExcelLiveAtList();
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
        /// 下载 所有 体验 Excel
        /// </summary>
        public async Task<IActionResult> OnGetExcelExperience()
        {
            var query = await _elderService.ExcelExperienceList();
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
        /// 下载 所有 正式 Excel
        /// </summary>
        public async Task<IActionResult> OnGetExcelContract()
        {
            var query = await _elderService.ExcelContractList();
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
            var query = await _elderService.UploadExcelToDB(uploadExcel);
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
