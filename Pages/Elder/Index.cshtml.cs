using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Elder
{
    public class IndexModel : PageModel
    {
        private readonly ElderService _elderService;

        public IndexModel(ElderService elderService)
        {
            _elderService = elderService;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// 分页返回 所有 入住老人 JsonData
        /// </summary>
        public async Task<IActionResult> OnGetLiveAtListJson(int? pages, int? limit)
        {
            int pageNumber = pages ?? 1;
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            int pageSize = limit ?? 10;
            pageSize = pageSize < 0 ? 10 : pageSize;

            var query = await _elderService.GetLiveAtListPaged(pageNumber, pageSize);

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
        /// 分页返回所有 体验入住 JsonData
        /// </summary>
        public async Task<IActionResult> OnGetExperienceListJson(int? pages, int? limit)
        {
            int pageNumber = pages ?? 1;
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            int pageSize = limit ?? 10;
            pageSize = pageSize < 0 ? 10 : pageSize;

            var query = await _elderService.GetExperienceListPaged(pageNumber, pageSize);

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
        /// 分页返回所有 正式入住 JsonData
        /// </summary>
        public async Task<IActionResult> OnGetContractListJson(int? pages, int? limit)
        {
            int pageNumber = pages ?? 1;
            pageNumber = pageNumber < 0 ? 1 : pageNumber;

            int pageSize = limit ?? 10;
            pageSize = pageSize < 0 ? 10 : pageSize;

            var query = await _elderService.GetContractListPaged(pageNumber, pageSize);

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
        /// 搜索 入住 老人 by Name，返回 JsonData
        /// </summary>
        public async Task<IActionResult> OnGetSearchNameListJson(string elderName)
        {
            if (string.IsNullOrWhiteSpace(elderName))
            {
                return new JsonResult(QueryElderResult.NoJsonData());
            }

            var query = await _elderService.GetLiveAtListByName(elderName);

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
        /// 体验到期
        /// </summary>
        public async Task<IActionResult> OnGetExperienceListJson_Expire()
        {
            var query = await _elderService.GetExperienceList_Expire();

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
        /// 合约到期
        /// </summary>
        public async Task<IActionResult> OnGetContractListJson_Expire()
        {
            var query = await _elderService.GetContractList_Expire();

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
