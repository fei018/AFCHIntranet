using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Elder
{
    public class IndexDeleteModel : PageModel
    {
        private readonly ElderService _elderService;

        public IndexDeleteModel(ElderService elderService)
        {
            this._elderService = elderService;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// 获取 所有老人
        /// </summary>
        public async Task<IActionResult> OnGetAllListJson(int? pages, int? limit)
        {
            int pageNumber = pages ?? 1;
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            int pageSize = limit ?? 10;
            pageSize = pageSize < 0 ? 10 : pageSize;

            var query = await _elderService.GetAllListPaged(pageNumber, pageSize);

            if (query.IsSuccess)
            {
                return new JsonResult(query.GetListJsonData());
            }
            else
            {
                return new JsonResult(query.ErrorJsonData());
            }
        }

        /// <summary>
        /// 搜索 所有 老人 by Name，返回 JsonData
        /// </summary>
        public async Task<IActionResult> OnGetSearchNameListJson(string elderName)
        {
            if (string.IsNullOrWhiteSpace(elderName))
            {
                return new JsonResult(QueryElderResult.NoJsonData());
            }

            var query = await _elderService.GetAllListByName(elderName);

            if (query.IsSuccess)
            {
                return new JsonResult(query.GetListJsonData());
            }
            else
            {
                return new JsonResult(query.ErrorJsonData());
            }
        }

        /// <summary>
        /// 删除老人
        /// </summary>
        public async Task<IActionResult> OnGetToDelete(int id)
        {
            var query = await _elderService.DeleteElderAndFamily(id);
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
