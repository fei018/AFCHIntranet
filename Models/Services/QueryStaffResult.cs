using AFCHIntranet.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFCHIntranet.Models.Services
{
    public class QueryStaffResult : ServiceResult
    {
        private Staff_Detail _staff;
        public Staff_Detail Staff
        {
            get => _staff;
            set { IsSuccess = true; _staff = value; }
        }

        private List<Staff_Detail> _staffList;
        public List<Staff_Detail> StaffList
        {
            get => _staffList;
            set { IsSuccess = true; _staffList = value; }
        }

        /// <summary>
        /// Elder 查询总数
        /// </summary>
        public int TableTotalCount { get; set; }


        public object GetListJsonData()
        {
            return new { code = 0, msg = "ok", count = this.TableTotalCount, data = this.StaffList };
        }

        public object ErrorJsonData()
        {
            return new { code = 400, msg = this.Error, count = string.Empty, data = string.Empty };
        }

        /// <summary>
        /// layui-table JsonData 无数据
        /// </summary>
        public static object NoJsonData()
        {
            return new { code = 400, msg = "无数据", count = string.Empty, data = string.Empty };
        }
    }
}
