using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AFCHIntranet.Models.Account
{
    public class LoginUser
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "用户名不能为空")]
        [MaxLength(10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [MaxLength(10)]
        public string Password { get; set; }

        [MaxLength(20)]
        public string RoleName { get; set; }

        public int LoginErrorCount { get; set; }

        public bool AccountLocked { get; set; }

        #region NotMapped
        [NotMapped]
        public const int AllowErrorCount = 5;
        #endregion

    }
}
