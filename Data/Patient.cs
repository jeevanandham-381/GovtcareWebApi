using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class Patient
{
    public int Id { get; set; }
    public int HospitalId { get; set; }
    public string Name { get; set; }
    public string FatherName { get; set; }
    public string Phone1 { get; set; }
    public string Phone2 { get; set; }
    public string Email {  get; set; }
    public string AdharNumber { get; set; }
    public string Street {  get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public virtual District District { get; set; }
    public virtual Hospital Hospital { get; set; }
    public virtual Lov Lov { get; set; }

}
