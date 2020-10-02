using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Elder;

namespace AFCHIntranet.Models.Services
{
    public class QueryElderResult : ServiceResult
    {

        private Elder_Detail _elder;
        public Elder_Detail Elder
        {
            get => _elder;
            set { IsSuccess = true; _elder = value; }
        }

        private List<Elder_Detail> _elderList;       
        public List<Elder_Detail> ElderList
        {
            get => _elderList;
            set { IsSuccess = true; _elderList = value; }
        }

        private Elder_Family _family;
        public Elder_Family Family 
        { 
            get => _family;
            set { IsSuccess = true; _family = value; }
        }

        /// <summary>
        /// Elder 查询总数
        /// </summary>
        public int TableTotalCount { get; set; }


        public object GetListJsonData()
        {
            return new { code = 0, msg = "ok", count = this.TableTotalCount, data = this.ElderList };
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
