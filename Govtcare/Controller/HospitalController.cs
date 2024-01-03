using IDAL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Govtcare.Controller;
[Route("api/[controller]")]

public class HospitalController : ControllerBase
{
    private readonly IHospitalDAL obj;
    [HttpPost("savehospital")]
    public async Task<IActionResult> SaveHospitalController(HospitalBO Detail)
    {
        try
        {
            string userid = User.Claims.Select(ca => ca.Value).ToArray()[0];
            string RemoteIpAddress = this.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            await obj.SaveHospitalAsync(Detail, userid, RemoteIpAddress);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
