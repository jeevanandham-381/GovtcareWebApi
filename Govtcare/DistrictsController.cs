using IDAL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Govtcare;

public class DistrictsController : ControllerBase
{
    private readonly IDistrictsDAL obj;
    private readonly ILogger<DistrictsController> logger;
    public DistrictsController(IDistrictsDAL obj, ILogger<DistrictsController> logger)
    {

        this.logger = logger;
        this.obj = obj;
    }
    public async Task<IActionResult> SaveDistrictsAsync(DistrictsBO Detail)
    {
        try
        {
            await obj.SaveDistrictsAsync(Detail);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            throw;
        }

    }

}
