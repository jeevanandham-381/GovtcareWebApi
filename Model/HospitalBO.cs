using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;

public class HospitalBO
{
    public int Id { get; set; }
    public int DistrictId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Fax { get; set; }
    public int StatusLid { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }

}
