using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL;

public interface IHospitalDAL
{
   Task SaveHospitalAsync(HospitalBO hosppitalBO , string userid, string RemoteIpAddress);
}
