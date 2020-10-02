using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Elder
{
    public class QueryModel : PageModel
    {
        private readonly ElderService _elderService;

        public QueryModel(ElderService elderService)
        {
            this._elderService = elderService;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// 搜索 姓名
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
        /// 搜索 年龄
        /// </summary>
        public async Task<IActionResult> OnGetSearchAgeListJson(string Age)
        {
            if (string.IsNullOrWhiteSpace(Age))
            {
                return new JsonResult(QueryElderResult.NoJsonData());
            }

            var query = await _elderService.GetLiveAtListByAge(Age);

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
        /// 搜索 出生月份
        /// </summary>
        public async Task<IActionResult> OnGetSearchBirthMonthListJson(string BirthMonth)
        {
            if (string.IsNullOrWhiteSpace(BirthMonth))
            {
                return new JsonResult(QueryElderResult.NoJsonData());
            }

            var query = await _elderService.GetLiveAtListByBirthMonth(BirthMonth);

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
        /// 搜索 户籍地址
        /// </summary>
        public async Task<IActionResult> OnGetSearchIDAddressListJson(string IDAddress)
        {
            if (string.IsNullOrWhiteSpace(IDAddress))
            {
                return new JsonResult(QueryElderResult.NoJsonData());
            }

            var query = await _elderService.GetLiveAtListByIDAddress(IDAddress);

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
