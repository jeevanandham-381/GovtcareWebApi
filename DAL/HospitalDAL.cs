using IDAL;
using Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL;

public class HospitalDAL : IHospitalDAL
{
    private readonly DataBaseContext db;
    private readonly ILogger<HospitalDAL> logger;
    public HospitalDAL(DataBaseContext db, ILogger<HospitalDAL> logger)
    {
        this.db = db;
        this.logger = logger;
    }
    public async Task SaveHospitalAsync(HospitalBO Detail, string userid, string RemoteIpAddress)
    {
        try
        {
            Hospital obj;
            if (Detail.Id == 0)
            {
                obj = new Hospital();
                obj.CreateDate = DateTime.Now;
            }
            else
            {
                obj = await db.hospitals.IgnoreQueryFilters().
                    Where(h => h.Id == Detail.Id).FirstOrDefaultAsync();
                obj.ModifiedDate = DateTime.Now;
            }
            obj.Street = Detail.Street;
            obj.City = Detail.City;
            obj.State = Detail.State;
            obj.ZipCode = Detail.ZipCode;
            obj.StatusLid = Detail.StatusLid;
            obj.DistrictId = Detail.DistrictId;
            obj.Email = Detail.Email;
            obj.Phone = Detail.Phone;
            obj.Fax = Detail.Fax;
            await db.AddAsync(obj);
            await db.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            this.logger.LogError(ex.Message);
            throw;
        }

    }
}
