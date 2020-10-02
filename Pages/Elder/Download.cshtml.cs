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
        /// ���� ���� ��ס Excel
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
        /// ���� ���� ���� Excel
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
        /// ���� ���� ��ʽ Excel
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
        /// �ϴ�excelģ������
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
