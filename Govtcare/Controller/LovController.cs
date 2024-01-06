﻿using IDAL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Govtcare.Controller;
[Route("api/[controller]")]
public class LovController : ControllerBase
{
    private readonly ILovDAL obj;
    private readonly ILogger<LovController> logger;
    public LovController(ILovDAL obj, ILogger<LovController> logger)
    {
        this.obj = obj;
        this.logger = logger;
    }
    [HttpPost("saveLov")]
    public async Task<IActionResult> SavelovValue([FromBody] LovBO Detail)
    {
        try
        {
            await obj.SaveLov(Detail);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest(ex.Message);
        }


    }

}
