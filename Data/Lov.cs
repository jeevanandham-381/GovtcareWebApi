using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class Lov
{
    public int Id { get; set; }
    public string StatusName { get; set; }
    public string StatusCode { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ICollection<Hospital> Hospital { get; set; }
    public ICollection <Patient> patients { get; set; } = new HashSet<Patient>();
    public ICollection<District> districts { get; set; } = new HashSet<District>();  

}
