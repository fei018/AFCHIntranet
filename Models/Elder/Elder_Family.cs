using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AFCHIntranet.Models.Elder
{ 
    public class Elder_Family
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
        [Display(Name = "*手机")]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*关系")]
        [MaxLength(5)]
        public string Relationship { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*身份证")]
        [MaxLength(18)]
        public string Identity { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "*常住地址")]
        [MaxLength(40)]
        public string HomeAddress { get; set; }

        //老人身份证Id
        [MaxLength(18)]
        public string ElderIdentity { get; set; }

        #region NotMapped

        [NotMapped]
        [Display(Name = "年龄")]
        public string Age
        {
            get
            {
                try
                {
                    var birth = Identity.Substring(6, 8);
                    var birthdate = DateTime.Parse($"{birth.Substring(0, 4)}-{birth.Substring(4, 2)}-{birth.Substring(6, 2)}");

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
        #endregion

        #region Trim()
        public Elder_Family Trim()
        {
            var f = new Elder_Family
            {
                ElderIdentity = ElderIdentity?.Trim(),
                HomeAddress = HomeAddress?.Trim(),
                Id = Id,
                Identity = Identity?.Trim(),
                Name = Name?.Trim(),
                Phone = Phone?.Trim(),
                Relationship = Relationship?.Trim(),
                Sex = Sex?.Trim()
            };

            return f;
        }
        #endregion
    }
}
