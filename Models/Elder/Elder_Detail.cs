using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AFCHIntranet.Models.Elder
{ 
    public class Elder_Detail
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

        [Display(Name = "手机")]
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

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*原居住地址")]
        [MaxLength(40)]
        public string HomeAddress { get; set; }

        [Display(Name = "信仰")]
        [MaxLength(5)]
        public string Faith { get; set; }

        [Display(Name = "备注")]
        [MaxLength(100)]
        public string Remark { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*护理等级")]
        [MaxLength(4)]
        public string NursingGrade { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*房间号")]
        [MaxLength(3)]
        public string RomNumber { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*住院状态")]
        [MaxLength(4)]
        public string LiveState { get; set; }

        [MaxLength(10)]
        [Display(Name = "备用金(中文)")]
        public string PettyCash { get; set; }

        [Display(Name = "体验开始日")]
        [MaxLength(10)]
        public string ExperienceStartDate { get; set; }

        [MaxLength(10)]
        [Display(Name = "合约开始日")]
        public string ContractStartDate { get; set; }

        [Display(Name = "合约期限(年)")]
        public string ContractTerm { get; set; }

        [MaxLength(10)]
        [Display(Name = "退住日期")]
        public string LeftDate { get; set; }

        #region 不映射属性
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
                    return "错误身份证";
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
        [Display(Name = "体验结束日")]
        public string ExperienceEndDate
        {
            get
            {
                try
                {
                    var end = DateTime.Parse(ExperienceStartDate).AddMonths(1);
                    return end.GetDateTimeFormats()[4];
                }
                catch (Exception)
                {
                    return null;
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

        #endregion

        #region SetLiveState
        /// <summary>
        /// elder 住院状态 设置为 体验入住 
        /// </summary>
        public void SetLiveStateToExperience()
        {
            LiveState = ElderLiveStateEnum.体验入住.ToString();

        }

        /// <summary>
        /// elder 住院状态 设置为 正式入住 
        /// </summary>
        public void SetLiveStateToContract(Elder_Detail elder)
        {
            LiveState = ElderLiveStateEnum.正式入住.ToString();
            ContractStartDate = elder.ContractStartDate;
            ContractTerm = elder.ContractTerm;
            PettyCash = elder.PettyCash;

            LeftDate = string.Empty;
        }

        /// <summary>
        /// elder 住院状态 设置为 已退住 
        /// </summary>
        public void SetLiveStateToLeft(Elder_Detail elder)
        {
            LiveState = ElderLiveStateEnum.已退住.ToString();
            LeftDate = elder.LeftDate;
        }
        #endregion

        #region 判断体验过期
        public bool IsExperience_Expire()
        {
            var now = DateTime.Now.Date;
            try
            {
                var exp = DateTime.Parse(ExperienceEndDate).Date;
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

        #region 判断合约过期
        public bool IsContract_Expire()
        {
            var now = DateTime.Now.Date;
            try
            {
                var con = DateTime.Parse(ContractEndDate).Date;
                if (con.CompareTo(now) <= 0)
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
        public Elder_Detail Trim()
        {
            var e = new Elder_Detail
            {
                ContractStartDate = ContractStartDate?.Trim(),
                ContractTerm = ContractTerm?.Trim(),
                ExperienceStartDate = ExperienceStartDate?.Trim(),
                Faith = Faith?.Trim(),
                HomeAddress = HomeAddress?.Trim(),
                Id = Id,
                IDAddress = IDAddress?.Trim(),
                Identity = Identity?.Trim(),
                JiGuan = JiGuan?.Trim(),
                LeftDate = LeftDate?.Trim(),
                LiveState = LiveState?.Trim(),
                Marital = Marital?.Trim(),
                MinZu = MinZu?.Trim(),
                Name = Name?.Trim(),
                NursingGrade = NursingGrade?.Trim(),
                PettyCash = PettyCash?.Trim(),
                Phone = Phone?.Trim(),
                Remark = Remark?.Trim(),
                RomNumber = RomNumber?.Trim(),
                Sex = Sex?.Trim()
            };

            return e;
        }
        #endregion
    }

}
