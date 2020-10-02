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
        /// ���� ��ְ list
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
        /// ���� ���� list
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
        /// ���� ���� list
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
        /// ���� ���� list
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
        /// ���� ��ְ list
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
        /// ���� ���õ��� list
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
        /// ���� ��Լ���� list
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
        /// ���� ������ list
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
        /// ���� ������ַ list
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
