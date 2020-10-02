using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFCHIntranet.Models.Elder;
using AFCHIntranet.Models.Account;
using AFCHIntranet.Models.Staff;

namespace AFCHIntranet.Models.Database
{
    public class AFCHIntranetDB:DbContext
    {
        public AFCHIntranetDB(DbContextOptions<AFCHIntranetDB> options):base(options)
        {

        }

        public DbSet<Elder_Detail> Tbl_Elder { get; set; }

        public DbSet<Elder_Family> Tbl_ElderFamily { get; set; }

        public DbSet<Staff_Detail> Tbl_Staff { get; set; }

        public DbSet<LoginUser> Tbl_LoginUser { get; set; }

    }
}
