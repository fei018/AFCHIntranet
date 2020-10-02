using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Elder
{
    public class IndexLeftModel : PageModel
    {
        private readonly ElderService _elderService;

        public IndexLeftModel(ElderService elderService)
        {
            this._elderService = elderService;
        }

        public void OnGet()
        {
        }


        /// <summary>
        /// 分页返回所有 已退住 JsonData
        /// </summary>
        public async Task<IActionResult> OnGetLeftListJson(int? pages, int? limit)
        {
            int pageNumber = pages ?? 1;
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            int pageSize = limit ?? 10;
            pageSize = pageSize < 0 ? 10 : pageSize;

            var query = await _elderService.GetLeftListPaged(pageNumber, pageSize);

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
        /// 搜索 by name 已退住 JsonData
        /// </summary>
        public async Task<IActionResult> OnGetSearchNameListJson(string elderName)
        {
            if (string.IsNullOrWhiteSpace(elderName))
            {
                return new JsonResult(QueryElderResult.NoJsonData());
            }

            var query = await _elderService.GetLeftListByName(elderName);

            if (query.IsSuccess)
            {
                return new JsonResult(query.GetListJsonData());
            }
            else
            {
                return new JsonResult(query.ErrorJsonData());
            }
        }
    }
}
