using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Elder;
using AFCHIntranet.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Spire.Xls;
using System.IO;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace AFCHIntranet.Models.Services
{
    public class ElderService
    {
        private readonly AFCHIntranetDB _dB;

        public ElderService(AFCHIntranetDB dB)
        {
            _dB = dB;
        }


        #region 新建老人
        public async Task<QueryElderResult> CreateNew(ElderInfo info)
        {
            var service = new QueryElderResult();
            var elder = info.Elder;
            var family = info.Family;

            if (elder == null || family == null)
            {
                service.Error = "老人 或 托养人 为 Null";
                return service;
            }

            //检查数据库是否有相同老人身份证存在
            var checkIdentity = await _dB.Tbl_Elder.AnyAsync(e => e.Identity == elder.Identity);
            if (checkIdentity)
            {
                service.Error = "老人身份证号码已存在数据库";
                return service;
            }

            try
            {
                //填写 住院状态
                elder.SetLiveStateToExperience();

                var e = await _dB.Tbl_Elder.AddAsync(elder);
                var f = await _dB.Tbl_ElderFamily.AddAsync(family);
                await _dB.SaveChangesAsync();

                service.Elder = e.Entity;
                return service;
            }
            catch (DbUpdateException ex)
            {
                service.Error = ex.InnerException.Message;
                return service;
            }

        }
        #endregion

        #region 分页获取所有 老人
        /// <summary>
        /// 分页获取所有 老人
        /// </summary>
        public async Task<QueryElderResult> GetAllListPaged(int pageIndex, int pageSize)
        {
            var service = new QueryElderResult();

            try
            {
                //获取分页人数
                var query = await _dB.Tbl_Elder.OrderByDescending(e => e.Id)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

                service.ElderList = query;
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

        #region 分页获取所有 入住老人
        /// <summary>
        /// 分页获取所有 入住老人
        /// </summary>
        public async Task<QueryElderResult> GetLiveAtListPaged(int pageIndex, int pageSize)
        {
            var service = new QueryElderResult();

            try
            {
                //查询 体验 和 合约 老人总数
                var elder = _dB.Tbl_Elder.Where(e => e.LiveState != ElderLiveStateEnum.已退住.ToString());
                service.TableTotalCount = await elder.CountAsync();

                //获取分页人数
                var query = await elder.OrderByDescending(e => e.Id)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

                service.ElderList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 分页获取所有 体验
        /// <summary>
        /// 分页获取所有 体验老人
        /// </summary>
        public async Task<QueryElderResult> GetExperienceListPaged(int pageIndex, int pageSize)
        {
            var service = new QueryElderResult();

            try
            {
                //获得体验总人数
                var exp = _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.体验入住.ToString());
                service.TableTotalCount = await exp.CountAsync();

                //获取分页人数
                var query = await exp.OrderByDescending(e => e.Id)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

                service.ElderList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 分页获取所有 正式
        /// <summary>
        /// 分页获取所有 正式入住老人
        /// </summary>
        public async Task<QueryElderResult> GetContractListPaged(int pageIndex, int pageSize)
        {
            var service = new QueryElderResult();

            try
            {
                //获得体验总人数
                var exp = _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.正式入住.ToString());
                service.TableTotalCount = await exp.CountAsync();

                //获取分页人数
                var query = await exp.OrderByDescending(e => e.Id)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

                service.ElderList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 分页获取所有 退住
        /// <summary>
        /// 分页获取所有 退住老人
        /// </summary>
        public async Task<QueryElderResult> GetLeftListPaged(int pageIndex, int pageSize)
        {
            var service = new QueryElderResult();

            try
            {
                //获得体验总人数
                var left = _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.已退住.ToString());
                service.TableTotalCount = await left.CountAsync();

                //获取分页人数
                var query = await left.OrderByDescending(e => e.Id)
                               .Skip((pageIndex - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

                service.ElderList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取 体验 过期
        public async Task<QueryElderResult> GetExperienceList_Expire()
        {
            var service = new QueryElderResult();
            try
            {
                var query = await _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.体验入住.ToString()).ToListAsync();
                query = query.Where(e => e.IsExperience_Expire()).ToList();

                service.TableTotalCount = query.Count;
                service.ElderList = query;
                return service;
            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 获取 合约 过期
        public async Task<QueryElderResult> GetContractList_Expire()
        {
            var service = new QueryElderResult();
            try
            {
                var query = await _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.正式入住.ToString()).ToListAsync();
                query = query.Where(e => e.IsContract_Expire()).ToList();

                service.TableTotalCount = query.Count;
                service.ElderList = query;
                return service;
            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 老人和托养人 by Id
        /// <summary>
        /// 搜索 老人和托养人 by Id
        /// </summary>
        public async Task<QueryElderResult> GetElderAndFamilyById(int elder_Id)
        {
            var service = new QueryElderResult();

            try
            {
                //var elder = await _dB.Tbl_Elder.FindAsync(elder_Id);
                //var family = await _dB.Tbl_ElderFamily.FirstOrDefaultAsync(f => f.ElderIdentity == elder.Identity);

                var query = await _dB.Tbl_Elder.Where(e => e.Id == elder_Id)
                                             .Join(_dB.Tbl_ElderFamily, e => e.Identity, f => f.ElderIdentity, (e, f) => new QueryElderResult { Elder = e, Family = f })
                                             .FirstOrDefaultAsync();

                return query;
            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 所有 老人 list by Name
        /// <summary>
        /// 搜索 入住老人 list by Name
        /// </summary>
        public async Task<QueryElderResult> GetAllListByName(string name)
        {
            var service = new QueryElderResult();

            try
            {
                var exp = await _dB.Tbl_Elder.Where(e => e.Name.Contains(name.Trim())).ToListAsync();
                service.TableTotalCount = exp.Count;
                service.ElderList = exp;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 入住 老人 list by Name
        /// <summary>
        /// 搜索 入住老人 list by Name
        /// </summary>
        public async Task<QueryElderResult> GetLiveAtListByName(string name)
        {
            var service = new QueryElderResult();

            try
            {
                var exp = await _dB.Tbl_Elder.Where(e => e.LiveState != ElderLiveStateEnum.已退住.ToString() && e.Name.Contains(name.Trim())).ToListAsync();
                service.TableTotalCount = exp.Count;
                service.ElderList = exp;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 入住 老人 list by Age
        /// <summary>
        /// 搜索 已退住老人 list by Age
        /// </summary>
        public async Task<QueryElderResult> GetLiveAtListByAge(string age)
        {
            var service = new QueryElderResult();

            try
            {
                var exp = await _dB.Tbl_Elder.Where(e => e.LiveState != ElderLiveStateEnum.已退住.ToString()).ToListAsync();
                var query = exp.Where(e => e.Age == age.Trim()).ToList();

                service.TableTotalCount = query.Count;
                service.ElderList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 入住 老人 list by IDAddress
        /// <summary>
        /// 搜索 已退住老人 list by IDAddress
        /// </summary>
        public async Task<QueryElderResult> GetLiveAtListByIDAddress(string address)
        {
            var service = new QueryElderResult();

            try
            {
                var exp = await _dB.Tbl_Elder.Where(e => e.LiveState != ElderLiveStateEnum.已退住.ToString() && e.IDAddress.Contains(address.Trim())).ToListAsync();
                service.TableTotalCount = exp.Count;
                service.ElderList = exp;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 入住 老人 list by BirthMonth
        /// <summary>
        /// 搜索 已退住老人 list by BirthMonth
        /// </summary>
        public async Task<QueryElderResult> GetLiveAtListByBirthMonth(string month)
        {
            var service = new QueryElderResult();

            try
            {
                var exp = await _dB.Tbl_Elder.Where(e => e.LiveState != ElderLiveStateEnum.已退住.ToString()).ToListAsync();
                var query = exp.Where(e => e.BirthMonth == month.Trim()).ToList();

                service.TableTotalCount = query.Count;
                service.ElderList = query;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 搜索 已退住 老人 list by Name
        /// <summary>
        /// 搜索 已退住老人 list by Name
        /// </summary>
        public async Task<QueryElderResult> GetLeftListByName(string name)
        {
            var service = new QueryElderResult();

            try
            {
                var exp = await _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.已退住.ToString() && e.Name.Contains(name.Trim())).ToListAsync();
                service.TableTotalCount = exp.Count;
                service.ElderList = exp;

                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 老人转入合约
        /// <summary>
        /// 老人转入合约
        /// </summary>
        public async Task<ServiceResult> ElderToContract(Elder_Detail elder)
        {
            var service = new ServiceResult();

            try
            {
                var query = await _dB.Tbl_Elder.FindAsync(elder.Id);

                //入住状态 更改 合约
                query.SetLiveStateToContract(elder);

                //更新数据库
                _dB.Tbl_Elder.Update(query);
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

        #region 老人转入退住
        /// <summary>
        /// 老人转入退住
        /// </summary>
        public async Task<ServiceResult> ElderToLeft(Elder_Detail elder)
        {
            var service = new ServiceResult();

            try
            {
                var query = await _dB.Tbl_Elder.FindAsync(elder.Id);

                //入住状态 更改 退住
                query.SetLiveStateToLeft(elder);

                //更新数据库
                _dB.Tbl_Elder.Update(query);
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

        #region 更新 老人和托养人
        /// <summary>
        /// 更新 老人和托养人
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<QueryElderResult> UpdateElderAndFamily(ElderInfo info)
        {
            var service = new QueryElderResult();

            var elder = info.Elder;
            var family = info.Family;
            if (elder == null || family == null)
            {
                service.Error = "老人 或 托养人为 Null";
                return service;
            }

            var checkId = await _dB.Tbl_Elder.AnyAsync(e => e.Id == elder.Id);
            if (!checkId)
            {
                service.Error = $"id={elder.Id}, {elder.Name} 数据库不存在, 或已经删除.";
                return service;
            }

            try
            {
                _dB.Tbl_Elder.Update(elder);
                _dB.Tbl_ElderFamily.Update(family);

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

        #region 删除 老人和托养人资料
        public async Task<ServiceResult> DeleteElderAndFamily(int elder_Id)
        {
            var service = new ServiceResult();

            try
            {
                var query = await _dB.Tbl_Elder.Where(e => e.Id == elder_Id)
                                             .Join(_dB.Tbl_ElderFamily, e => e.Identity, f => f.ElderIdentity, (e, f) => new { ElderDetail = e, Family = f })
                                             .FirstOrDefaultAsync();

                _dB.Tbl_Elder.Remove(query.ElderDetail);
                _dB.Tbl_ElderFamily.Remove(query.Family);
                await _dB.SaveChangesAsync();

                service.IsSuccess = true;
                return service;
            }
            catch (ArgumentNullException ex)
            {
                service.Error = ex.Message;
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
        private DataTable ListToDataTable(List<QueryElderResult> list)
        {
            DataTable dt = new DataTable();
            #region Add Columns
            dt.Columns.Add("老人姓名");
            dt.Columns.Add("老人身份证");
            dt.Columns.Add("老人年龄");
            dt.Columns.Add("老人性别");
            dt.Columns.Add("老人出生日期");
            dt.Columns.Add("老人体验开始日");
            dt.Columns.Add("老人体验结束日");
            dt.Columns.Add("老人合约开始日");
            dt.Columns.Add("老人合约结束日");
            dt.Columns.Add("老人合约期限(年)");
            dt.Columns.Add("老人电话");
            dt.Columns.Add("老人籍贯");
            dt.Columns.Add("老人户籍地址");
            dt.Columns.Add("老人原居住地址");
            dt.Columns.Add("老人生日月份");
            dt.Columns.Add("老人婚姻状况");
            dt.Columns.Add("老人民族");
            dt.Columns.Add("老人信仰");
            dt.Columns.Add("老人护理等级");
            dt.Columns.Add("老人房间号");
            dt.Columns.Add("老人住院状态");
            dt.Columns.Add("老人备用金");          
            dt.Columns.Add("老人备注");
            //托养人
            dt.Columns.Add("托养人姓名");
            dt.Columns.Add("托养人电话");
            dt.Columns.Add("托养人性别");
            dt.Columns.Add("托养人年龄");
            dt.Columns.Add("托养人关系");
            dt.Columns.Add("托养人身份证");
            dt.Columns.Add("托养人常住地址");
            #endregion

            #region Add Row
            foreach (var i in list)
            {
                dt.Rows.Add(i.Elder.Name, i.Elder.Identity, i.Elder.Age, i.Elder.Sex, i.Elder.BirthDate, i.Elder.ExperienceStartDate, i.Elder.ExperienceEndDate,
                            i.Elder.ContractStartDate, i.Elder.ContractEndDate, i.Elder.ContractTerm, i.Elder.Phone, i.Elder.JiGuan, i.Elder.IDAddress, i.Elder.HomeAddress,
                            i.Elder.BirthMonth, i.Elder.Marital, i.Elder.MinZu, i.Elder.Faith, i.Elder.NursingGrade, i.Elder.RomNumber, i.Elder.LiveState, i.Elder.PettyCash,i.Elder.Remark,
                            i.Family.Name,i.Family.Phone,i.Family.Sex,i.Family.Age,i.Family.Relationship,i.Family.Identity,i.Family.HomeAddress);
            }
            #endregion
            return dt;
        }
        #endregion

        #region 下载 所有 入住 Excel
        /// <summary>
        /// 下载 所有 入住 Excel
        /// </summary>
        public async Task<ServiceResult<MemoryStream>> ExcelLiveAtList()
        {
            var service = new ServiceResult<MemoryStream>();

            using var wb = new Workbook() { Version = ExcelVersion.Version2013 };
            var sheet = wb.Worksheets[0];

            try
            {
                //数据库 获取 所有 入住老人
                var query = await _dB.Tbl_Elder.Where(e => e.LiveState != ElderLiveStateEnum.已退住.ToString())
                                     .Join(_dB.Tbl_ElderFamily, e => e.Identity, f => f.ElderIdentity, (e, f) => new QueryElderResult { Elder = e, Family = f })
                                     .ToListAsync();
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

                service.SetValue(mem, "所有入住老人资料.xlsx", FileMimeType.GetMimeType(".xlsx"));
                return service;
            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 下载 体验 入住 Excel
        /// <summary>
        /// 下载 体验 入住 Excel
        /// </summary>
        public async Task<ServiceResult<MemoryStream>> ExcelExperienceList()
        {
            var service = new ServiceResult<MemoryStream>();

            using var wb = new Workbook() { Version = ExcelVersion.Version2013 };
            var sheet = wb.Worksheets[0];

            try
            {
                //数据库 获取 所有 入住老人
                var query = await _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.体验入住.ToString())
                                     .Join(_dB.Tbl_ElderFamily, e => e.Identity, f => f.ElderIdentity, (e, f) => new QueryElderResult { Elder = e, Family = f }).ToListAsync();
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

                service.SetValue(mem, "体验入住老人资料.xlsx", FileMimeType.GetMimeType(".xlsx"));
                return service;
            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 下载 正式 入住 Excel
        /// <summary>
        /// 下载 正式 入住 Excel
        /// </summary>
        public async Task<ServiceResult<MemoryStream>> ExcelContractList()
        {
            var service = new ServiceResult<MemoryStream>();

            using var wb = new Workbook() { Version = ExcelVersion.Version2013 };
            var sheet = wb.Worksheets[0];

            try
            {
                //数据库 获取 正式 入住老人
                var query = await _dB.Tbl_Elder.Where(e => e.LiveState == ElderLiveStateEnum.正式入住.ToString())
                                     .Join(_dB.Tbl_ElderFamily, e => e.Identity, f => f.ElderIdentity, (e, f) => new QueryElderResult { Elder = e, Family = f }).ToListAsync();
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

                service.SetValue(mem, "正式入住老人资料.xlsx", FileMimeType.GetMimeType(".xlsx"));
                return service;
            }
            catch (Exception ex)
            {
                service.Error = ex.Message;
                return service;
            }
        }
        #endregion

        #region 上传Excel
        public async Task<ServiceResult> UploadExcelToDB(IFormFile excel)
        {
            var service = new ServiceResult();
            if (excel.Length <=0)
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

            if (sheet.Rows.Length<=0)
            {
                service.Error = "Excel 数据为空";
                return service;
            }

            using var dt = sheet.ExportDataTable();
            var list = DataTableToList(dt);

            foreach (var q in list)
            {
                _dB.Tbl_Elder.Add(q.Elder);
                _dB.Tbl_ElderFamily.Add(q.Family);
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

        #region DataTable To List<ElderInfo>
        private List<ElderInfo> DataTableToList(DataTable dt)
        {
            var list = new List<ElderInfo>();
            var rows = dt.Rows;
            rows.RemoveAt(0);
            foreach (DataRow r in rows)
            {
                var elder = new Elder_Detail
                {
                    Name = r.Field<string>("姓名"),
                    Sex = r.Field<string>("性别"),
                    Identity = r.Field<string>("身份证"),
                    Phone = r.Field<string>("手机"),
                    ExperienceStartDate = r.Field<string>("体验开始"),
                    PettyCash = r.Field<string>("备用金"),
                    IDAddress = r.Field<string>("居住地址"),
                    HomeAddress = r.Field<string>("居住地址"),
                    NursingGrade = "自理",
                    Marital = "已婚",
                    RomNumber = "未知"
                };
                if (r.Field<string>("合约开始") == null)
                {
                    elder.LiveState = ElderLiveStateEnum.体验入住.ToString();
                }
                else
                {
                    elder.LiveState = ElderLiveStateEnum.正式入住.ToString();
                    elder.ContractStartDate = r.Field<string>("合约开始");
                    elder.ContractTerm = "1";
                }

                var family = new Elder_Family
                {
                    Name = r.Field<string>("托养人"),
                    Phone = r.Field<string>("托养人电话"),
                    HomeAddress = r.Field<string>("居住地址"),
                    Identity = "111111111111111111",
                    Relationship = "未知",
                    Sex = "男",
                    ElderIdentity = elder.Identity
                };

                var q = new ElderInfo(elder, family);
                list.Add(q);
            }
            return list;
        }
        #endregion
    }
}
