using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AFCHIntranet.Pages.Staff
{
    public class IndexModel : PageModel
    {
        private readonly StaffService _staffService;

        public IndexModel(StaffService staffService)
        {
            this._staffService = staffService;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// 返回 在职 list
        /// </summary>
        public async Task<IActionResult> OnGetWorkingListJson()
        {
            var query = await _staffService.GetWorkingList();
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
        /// 返回 试用 list
        /// </summary>
        public async Task<IActionResult> OnGetProbationListJson()
        {
            var query = await _staffService.GetProbationList();
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
        /// 返回 短期 list
        /// </summary>
        public async Task<IActionResult> OnGetShortTermListJson()
        {
            var query = await _staffService.GetShortTermList();
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
        /// 返回 长期 list
        /// </summary>
        public async Task<IActionResult> OnGetContractListJson()
        {
            var query = await _staffService.GetContractList();
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
        /// 返回 离职 list
        /// </summary>
        public async Task<IActionResult> OnGetLeftListJson()
        {
            var query = await _staffService.GetLeftList();
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
        /// 返回 试用到期 list
        /// </summary>
        public async Task<IActionResult> OnGetProbationListJson_Expire()
        {
            var query = await _staffService.GetProbationList_Expire();
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
        /// 返回 合约到期 list
        /// </summary>
        public async Task<IActionResult> OnGetContractListJson_Expire()
        {
            var query = await _staffService.GetContractList_Expire();
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
        /// 搜索 出生月 list
        /// </summary>
        public async Task<IActionResult> OnGetSearchBirthMonthListJson(string BirthMonth)
        {
            if (string.IsNullOrWhiteSpace(BirthMonth))
            {
                return new JsonResult(QueryStaffResult.NoJsonData());
            }

            var query = await _staffService.GetWorkingByBirthMonth(BirthMonth);
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
        /// 搜索 户籍地址 list
        /// </summary>
        public async Task<IActionResult> OnGetSearchIDAddressListJson(string IDAddress)
        {
            if (string.IsNullOrWhiteSpace(IDAddress))
            {
                return new JsonResult(QueryStaffResult.NoJsonData());
            }

            var query = await _staffService.GetWorkingByIDAddress(IDAddress);
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
