using Data;
using IDAL;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class DistrictsDAL : IDistrictsDAL
{
    private readonly DataBaseContext db;
    private readonly ILogger<DistrictsDAL> logger;
    public DistrictsDAL(DataBaseContext db, ILogger<DistrictsDAL> logger)
    {
        this.db = db;
        this.logger = logger;
    }
    public async Task SaveDistrictsAsync(DistrictsBO Detail)
    {
        try
        {
            District obj;
            obj = new District();
            if (Detail.Id == 0)
            {
                db.districts.Add(obj);
                obj.DistrictName = Detail.DistrictName;
                obj.DistrictCode = Detail.DistrictCode;
            }
            else
            {
                obj.DistrictCode = Detail.DistrictCode;
                obj.DistrictName = Detail.DistrictName;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            throw;
        }
    }
}
