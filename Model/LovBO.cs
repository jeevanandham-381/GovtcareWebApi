using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class LovBO
{
    public int Id { get; set; }
    public string StatusName { get; set; }
    public string StatusCode { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }

}
