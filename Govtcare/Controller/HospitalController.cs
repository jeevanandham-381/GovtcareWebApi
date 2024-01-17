using IDAL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Security.Claims;

namespace Govtcare.Controller;
[Route("api/[controller]")]

public class HospitalController : ControllerBase
{
    private readonly IHospitalDAL obj;
    [HttpPost("savehospital")]
    public async Task<IActionResult> SaveHospitalController([FromBody]HospitalBO Detail)
    {
        try
        {
            //var userDataClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData);
          //  string userid = int.Parse(userDataClaim.Value).ToString();
           // string RemoteIpAddress = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            await obj.SaveHospitalAsync(Detail);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
