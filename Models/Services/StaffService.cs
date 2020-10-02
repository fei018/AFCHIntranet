using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Database;
using AFCHIntranet.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Spire.Xls;

namespace AFCHIntranet.Models.Services
{
    public class StaffService
    {
        private readonly AFCHIntranetDB _dB;

        public StaffService(AFCHIntranetDB dB)
        {
            _dB = dB;
        }

        #region 新建
        /// <summary>
        /// 新建员工
        /// </summary>
        public async Task<QueryStaffResult> CreateNew(Staff_Detail staff)
        {
            var service = new QueryStaffResult();

            if (staff == null)
            {
                service.Error = "员工 为 Null";
                return service;
            }
            var sta = staff.Trim();

            //检查数据库是否有相同员工身份证存在
            var checkIdentity = await _dB.Tbl_Staff.AnyAsync(e => e.Identity == sta.Identity);
            if (checkIdentity)
            {
                service.Error = "身份证号码已存在数据库";
                return service;
            }

            try
            {
                var s = await _dB.Tbl_Staff.AddAsync(sta);
                await _dB.SaveChangesAsync();

                service.Staff = s.Entity;
                return service;
            }
            catch (DbUpdateException ex)
            {
                service.Error = ex.InnerException.Message;
                return service;
            }

        }
        #endregion

        #region 获取所有staff
        /// <summary>
        /// 获取所有staff
        /// </summary>
        public async Task<QueryStaffResult> GetAllList()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await _dB.Tbl_Staff.OrderByDescending(e => e.Id).ToListAsync();

                service.StaffList = query;
                service.TableTotalCount = query.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取所有 在职 staff
        /// <summary>
        /// 获取所有 在职staff
        /// </summary>
        public async Task<QueryStaffResult> GetWorkingList()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await _dB.Tbl_Staff.Where(s => s.PositionState != StaffPositionStateEnum.离职.ToString())
                                               .OrderByDescending(e => e.Id)
                                               .ToListAsync();

                service.StaffList = query;
                service.TableTotalCount = query.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取所有 试用 staff
        /// <summary>
        /// 获取 试用期 staff
        /// </summary>
        public async Task<QueryStaffResult> GetProbationList()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await _dB.Tbl_Staff.Where(s => s.PositionState == StaffPositionStateEnum.试用.ToString())
                                               .OrderByDescending(e => e.Id)
                                               .ToListAsync();

                service.StaffList = query;
                service.TableTotalCount = query.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取所有 短期 staff
        /// <summary>
        /// 获取 短期 staff
        /// </summary>
        public async Task<QueryStaffResult> GetShortTermList()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await _dB.Tbl_Staff.Where(s => s.PositionState == StaffPositionStateEnum.短期.ToString())
                                               .OrderByDescending(e => e.Id)
                                               .ToListAsync();

                service.StaffList = query;
                service.TableTotalCount = query.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取所有 长期 staff
        /// <summary>
        /// 获取 长期 staff
        /// </summary>
        public async Task<QueryStaffResult> GetContractList()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await _dB.Tbl_Staff.Where(s => s.PositionState == StaffPositionStateEnum.长期.ToString())
                                               .OrderByDescending(e => e.Id)
                                               .ToListAsync();

                service.StaffList = query;
                service.TableTotalCount = query.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取所有 离职 staff
        /// <summary>
        /// 获取所有 离职 staff
        /// </summary>
        public async Task<QueryStaffResult> GetLeftList()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await _dB.Tbl_Staff.Where(s => s.PositionState == StaffPositionStateEnum.离职.ToString())
                                               .OrderByDescending(e => e.Id)
                                               .ToListAsync();

                service.StaffList = query;
                service.TableTotalCount = query.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取  试用到期 staff
        /// <summary>
        /// 获取 试用期 staff
        /// </summary>
        public async Task<QueryStaffResult> GetProbationList_Expire()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await GetProbationList();
                var list = query.StaffList.Where(s => s.IsProbation_Expire()).ToList();

                service.StaffList = list;
                service.TableTotalCount = list.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取  合约到期 staff
        /// <summary>
        /// 获取 合约到期 staff
        /// </summary>
        public async Task<QueryStaffResult> GetContractList_Expire()
        {
            var service = new QueryStaffResult();

            try
            {

                var query = await GetContractList();
                var list = query.StaffList.Where(s => s.IsContract_Expire()).ToList();

                service.StaffList = list;
                service.TableTotalCount = list.Count;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取 staff by Id
        /// <summary>
        /// 获取所有staff
        /// </summary>
        public async Task<QueryStaffResult> GetStaffById(int id)
        {
            var service = new QueryStaffResult();

            var query = await _dB.Tbl_Staff.FindAsync(id);
            if (query == null)
            {
                service.Error = "id=" + id + "为空";
                return service;
            }

            service.Staff = query;

            return service;

        }
        #endregion

        #region 搜索 出生月份
        /// <summary>
        /// 搜索 出生月份
        /// </summary>
        public async Task<QueryStaffResult> GetWorkingByBirthMonth(string month)
        {
            var service = new QueryStaffResult();

            try
            {
                var exp = await _dB.Tbl_Staff.Where(e => e.PositionState != StaffPositionStateEnum.离职.ToString()).ToListAsync();
                var query = exp.Where(e => e.BirthMonth == month.Trim()).ToList();

                service.TableTotalCount = query.Count;
                service.StaffList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 户籍地区
        /// <summary>
        /// 搜索 户籍地区
        /// </summary>
        public async Task<QueryStaffResult> GetWorkingByIDAddress(string idAddress)
        {
            var service = new QueryStaffResult();

            try
            {
                var query = await _dB.Tbl_Staff.Where(e => e.PositionState != StaffPositionStateEnum.离职.ToString()
                                                    && e.IDAddress.Contains(idAddress.Trim()))
                                             .ToListAsync();

                service.TableTotalCount = query.Count;
                service.StaffList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 更新 staff 
        /// <summary>
        /// 获取所有staff
        /// </summary>
        public async Task<QueryStaffResult> UpdateStaff(Staff_Detail staff)
        {
            var service = new QueryStaffResult();

            //检查Id，应该存在数据库
            var checkId = await _dB.Tbl_Staff.AnyAsync(e => e.Id == staff.Id);
            if (!checkId)
            {
                service.Error = $"id={staff.Id}, {staff.Name} 数据库不存在, 或已经删除.";
                return service;
            }

            _dB.Tbl_Staff.Update(staff);

            try
            {
                await _dB.SaveChangesAsync();
                service.Staff = staff;
                return service;
            }
            catch (DbUpdateException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 删除员工 by Id
        /// <summary>
        /// 删除员工
        /// </summary>
        public async Task<ServiceResult> DeleteStaff(int id)
        {
            var service = new ServiceResult();

            var staff = await _dB.Tbl_Staff.FindAsync(id);
            if (staff == null)
            {
                service.Error = $"id={id} 数据库不存在.";
                return service;
            }

            _dB.Tbl_Staff.Remove(staff);

            try
            {
                await _dB.SaveChangesAsync();
                service.IsSuccess = true;
                return service;
            }
            catch (DbUpdateException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region List To DataTable
        private DataTable ListToDataTable(List<Staff_Detail> list)
        {
            var dt = new DataTable();
            #region add columns
            dt.Columns.Add("员工姓名");
            dt.Columns.Add("身份证");
            dt.Columns.Add("年龄");
            dt.Columns.Add("性别");
            dt.Columns.Add("出生日期");
            dt.Columns.Add("入职日期");
            dt.Columns.Add("电话");
            dt.Columns.Add("籍贯");
            dt.Columns.Add("户籍地址");
            dt.Columns.Add("紧急联系人");
            dt.Columns.Add("联系人电话");
            dt.Columns.Add("岗位状态");
            dt.Columns.Add("部门");
            dt.Columns.Add("工龄");
            dt.Columns.Add("合约开始日");
            dt.Columns.Add("合约结束日");
            dt.Columns.Add("合约期限");
            dt.Columns.Add("婚姻状况");
            dt.Columns.Add("民族");
            dt.Columns.Add("居住地址");
            dt.Columns.Add("学历");
            dt.Columns.Add("专业技能");
            dt.Columns.Add("房间号");
            dt.Columns.Add("离职日期");
            #endregion
            #region add rows
            foreach (var s in list)
            {
                dt.Rows.Add(s.Name, s.Identity, s.Age, s.Sex, s.BirthDate, s.WorkStartDate, s.Phone, s.JiGuan, s.IDAddress,
                            s.FamilyName, s.FamilyPhone, s.PositionState, s.Department, s.WorkingAge, s.ContractStartDate,
                            s.ContractEndDate, s.ContractTerm, s.Marital, s.MinZu, s.HomeAddress, s.Education, s.Skill,
                            s.RomNumber, s.LeftDate);
            }
            #endregion
            return dt;
        }
        #endregion

        #region 下载 在职员工资料 Excel
        /// <summary>
        /// 下载 在职员工资料 Excel
        /// </summary>
        public async Task<ServiceResult<MemoryStream>> ExcelStaffWorkingList()
        {
            var service = new ServiceResult<MemoryStream>();

            using var wb = new Workbook() { Version = ExcelVersion.Version2013 };
            var sheet = wb.Worksheets[0];

            try
            {
                var query = await _dB.Tbl_Staff.Where(s => s.PositionState != StaffPositionStateEnum.离职.ToString()).ToListAsync();
                if (query.Count <= 0)
                {
                    service.Error = "无数据";
                    return service;
                }

                var dt = ListToDataTable(query);
                sheet.InsertDataTable(dt, true, 1, 1, true);

                var mem = new MemoryStream();
                wb.SaveToStream(mem);

                //释放 datatable
                dt.Dispose();

                //memorystream 指针归位
                mem.Seek(0, SeekOrigin.Begin);

                service.SetValue(mem, "在职员工资料.xlsx", FileMimeType.GetMimeType(".xlsx"));
                return service;

            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 上传 员工资料 Excel
        public async Task<ServiceResult> UploadExcelToDB(IFormFile excel)
        {
            var service = new ServiceResult();
            if (excel.Length <= 0)
            {
                service.Error = "文件长度为0";
                return service;
            }

            using var read = new MemoryStream();
            await excel.CopyToAsync(read);
            read.Seek(0, SeekOrigin.Begin);

            using var wb = new Workbook();
            wb.LoadFromStream(read);
            var sheet = wb.Worksheets[0];

            if (sheet.Rows.Length <= 0)
            {
                service.Error = "Excel 数据为空";
                return service;
            }

            using var dt = sheet.ExportDataTable();
            var list = DataTableToList(dt);

            foreach (var s in list)
            {
                await _dB.Tbl_Staff.AddAsync(s);
            }

            try
            {
                await _dB.SaveChangesAsync();
                service.IsSuccess = true;
                return service;
            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region DataTable To List<Staff_Detail>
        private List<Staff_Detail> DataTableToList(DataTable dt)
        {
            var list = new List<Staff_Detail>();
            var rows = dt.Rows;

            //移除第一行(列)
            rows.RemoveAt(0);

            foreach (DataRow r in rows)
            {
                var staff = new Staff_Detail
                {
                    Name = r.Field<string>("姓名"),
                    Sex = r.Field<string>("性别"),
                    MinZu = r.Field<string>("民族"),
                    Marital = r.Field<string>("婚姻"),
                    Identity = r.Field<string>("身份证"),
                    PositionState = r.Field<string>("岗位状态"),
                    Department = r.Field<string>("部门"),
                    Phone = r.Field<string>("手机"),
                    Education = r.Field<string>("学历"),
                    Skill = r.Field<string>("技能"),
                    WorkStartDate = r.Field<string>("入职日期"),
                    LeftDate = r.Field<string>("离职日期"),
                    RomNumber = r.Field<string>("房间号"),
                    IDAddress = r.Field<string>("户籍地址"),
                    FamilyName = r.Field<string>("紧急联系人"),
                    FamilyPhone = r.Field<string>("联系人电话"),
                };
                if (!string.IsNullOrWhiteSpace(r.Field<string>("合约开始日")))
                {
                    staff.ContractStartDate = r.Field<string>("合约开始日");
                    staff.ContractTerm = "1";
                }

                list.Add(staff);
            }
            return list;
        }
        #endregion
    }
}
