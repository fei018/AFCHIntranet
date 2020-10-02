using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFCHIntranet.Models.Elder
{
    public class ElderInfo
    {
        public ElderInfo(Elder_Detail elder, Elder_Family family)
        {                   
            if (elder != null)
            {
                Elder = elder.Trim();

                if (family != null)
                {
                    Family = family.Trim();
                    Family.ElderIdentity = Elder.Identity;
                }
            }           
        }

        public Elder_Detail Elder { get; set; }

        public Elder_Family Family { get; set; }
  
    }
}
