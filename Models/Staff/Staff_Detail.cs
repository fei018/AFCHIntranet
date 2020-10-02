
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AFCHIntranet.Models.Staff
{
    public class Staff_Detail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*姓名")]
        [MaxLength(5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*性别")]
        [MaxLength(2)]
        public string Sex { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*身份证")]
        [MaxLength(18)]
        public string Identity { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*婚姻状况")]
        [MaxLength(5)]
        public string Marital { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*手机")]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Display(Name = "民族")]
        [MaxLength(5)]
        public string MinZu { get; set; }

        [Display(Name = "籍贯")]
        [MaxLength(10)]
        public string JiGuan { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*户籍地址")]
        [MaxLength(40)]
        public string IDAddress { get; set; }

        [Display(Name = "居住地址")]
        [MaxLength(40)]
        public string HomeAddress { get; set; }

        [Display(Name = "备注")]
        [MaxLength(100)]
        public string Remark { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*岗位状态")]
        [MaxLength(2)]
        public string PositionState { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*入职日期")]
        [MaxLength(10)]
        public string WorkStartDate { get; set; }

        [Display(Name = "合约开始日")]
        [MaxLength(10)]
        public string ContractStartDate { get; set; }

        [Display(Name = "合约期限(年)")]
        public string ContractTerm { get; set; }

        [Display(Name = "学历")]
        [MaxLength(3)]
        public string Education { get; set; }

        [Display(Name = "专业技能")]
        [MaxLength(10)]
        public string Skill { get; set; }

        [Display(Name = "房间号")]
        [MaxLength(3)]
        public string RomNumber { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*部门")]
        [MaxLength(3)]
        public string Department { get; set; }

        [Display(Name = "离职日期")]
        [MaxLength(10)]
        public string LeftDate { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*紧急联系人")]
        [MaxLength(5)]
        public string FamilyName { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*紧急联系人电话")]
        [MaxLength(11)]
        public string FamilyPhone { get; set; }

        #region 非映射属性
        /// <exception cref="抛出异常"></exception>
        [NotMapped]
        [Display(Name = "出生日期")]
        public string BirthDate
        {
            get
            {
                try
                {
                    var birth = Identity.Substring(6, 8);
                    return $"{birth.Substring(0, 4)}-{birth.Substring(4, 2)}-{birth.Substring(6, 2)}";
                }
                catch (Exception)
                {
                    throw new Exception("错误身份证");
                }
            }
        }

        [NotMapped]
        [Display(Name = "生日")]
        public string BirthDay
        {
            get
            {
                try
                {
                    var birth = BirthDate.Substring(5, 5);
                    return $"{birth.Substring(0, 2)}月{birth.Substring(3, 2)}日";
                }
                catch (Exception)
                {
                    return "错误身份证";
                }
            }
        }

        [NotMapped]
        [Display(Name = "生日月份")]
        public string BirthMonth
        {
            get
            {
                try
                {
                    var birth = BirthDate.Substring(5, 2);
                    if (birth[0].Equals('0'))
                    {
                        birth = birth.Substring(1, 1);
                    }
                    return birth;
                }
                catch (Exception)
                {
                    return "错误身份证";
                }
            }
        }

        [NotMapped]
        [Display(Name = "年龄")]
        public string Age
        {
            get
            {
                try
                {
                    var birthdate = DateTime.Parse(BirthDate);

                    DateTime now = DateTime.Now;
                    int age = now.Year - birthdate.Year;
                    if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
                    {
                        age--;
                    }
                    age = age < 0 ? 0 : age;
                    return age.ToString();
                }
                catch (Exception)
                {
                    return "0";
                }
            }
        }

        [NotMapped]
        [Display(Name = "合约结束日")]
        public string ContractEndDate
        {
            get
            {
                try
                {
                    var end = DateTime.Parse(ContractStartDate).AddYears(int.Parse(ContractTerm));
                    return end.GetDateTimeFormats()[4];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <exception cref="抛出异常"></exception>
        [NotMapped]
        [Display(Name = "工龄")]
        public string WorkingAge
        {
            get
            {
                DateTime now;
                try
                {
                    if (PositionState == StaffPositionStateEnum.离职.ToString())
                    {
                        bool ok = DateTime.TryParse(LeftDate, out now);
                        if (!ok)
                        {
                            return "入职或离职日期错误";
                        }
                    }
                    else
                    {
                        now = DateTime.Now.Date;
                    }

                    var start = DateTime.Parse(WorkStartDate).Date;

                    int ys = now.Year - start.Year;
                    int ms = now.Month - start.Month;

                    //span就是两个日期相差的月数
                    int span = ys * 12 + ms;
                    string s = "";
                    if (span / 12 > 0)
                    {
                        s = span / 12 + "年" + span % 12 + "月";
                    }
                    else
                    {
                        s = span % 12 + "月";
                    }
                    return s;
                }
                catch (Exception)
                {
                    return "入职或离职日期错误";
                }
            }
        }
        #endregion

        #region 判断试用到期
        public bool IsProbation_Expire()
        {
            var now = DateTime.Now.Date;
            try
            {
                // 试用期：入职日期+一个月
                var exp = DateTime.Parse(WorkStartDate).AddMonths(1).Date;

                if (exp.CompareTo(now) <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 判断合约到期
        public bool IsContract_Expire()
        {
            var now = DateTime.Now.Date;
            try
            {
                var exp = DateTime.Parse(ContractEndDate).Date;
                if (exp.CompareTo(now) <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Trim()
        public Staff_Detail Trim()
        {
            var s = new Staff_Detail
            {
                ContractStartDate = ContractStartDate?.Trim(),
                ContractTerm = ContractTerm?.Trim(),
                Department = Department?.Trim(),
                Education = Education?.Trim(),
                FamilyName = FamilyName?.Trim(),
                FamilyPhone = FamilyPhone?.Trim(),
                HomeAddress = HomeAddress?.Trim(),
                Id = Id,
                IDAddress = IDAddress?.Trim(),
                Identity = Identity?.Trim(),
                JiGuan = JiGuan?.Trim(),
                LeftDate = LeftDate?.Trim(),
                Marital = Marital?.Trim(),
                MinZu = MinZu?.Trim(),
                Name = Name?.Trim(),
                Phone = Phone?.Trim(),
                PositionState = PositionState?.Trim(),
                Remark = Remark?.Trim(),
                RomNumber = RomNumber?.Trim(),
                Sex = Sex?.Trim(),
                Skill = Skill?.Trim(),
                WorkStartDate = WorkStartDate?.Trim()
            };
            return s;
        }
        #endregion
    }
}
