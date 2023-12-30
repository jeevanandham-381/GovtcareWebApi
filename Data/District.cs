using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class District
{
    public int Id { get; set; }
    public string DistrictName { get; set; }
    public string DistrictCode { get; set;}
    public ICollection<Hospital> Hospital { get; set; } = new HashSet<Hospital>();
}
