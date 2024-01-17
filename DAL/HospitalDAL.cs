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
using System.Numerics;
using System.Reflection.Emit;

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
    public async Task SaveHospitalAsync(HospitalBO hospital)
    {
        try
        {
            if (hospital.Id == 0)
            {
                var hospitalDet = new Hospital
                {
                    DistrictId = hospital.DistrictId,
                    Email = hospital.Email,
                    Phone = hospital.Phone,
                    State = hospital.State,
                    City = hospital.City,
                    ZipCode = hospital.ZipCode,
                    StatusLid = hospital.StatusLid,
                    Fax = hospital.Fax,
                    CreateDate = hospital.CreateDate,
                };
               await db.AddAsync(hospitalDet);
            }
            else
            {
                var ExistHospital = await db.hospitals.Where(h => h.Id == hospital.Id).FirstOrDefaultAsync();
                if (ExistHospital != null)
                {
                    ExistHospital.DistrictId = hospital.DistrictId;
                    ExistHospital.Email = hospital.Email;
                    ExistHospital.Phone = hospital.Phone;
                    ExistHospital.State = hospital.State;
                    ExistHospital.City = hospital.City;
                    ExistHospital.ZipCode = hospital.ZipCode;
                    ExistHospital.StatusLid = hospital.StatusLid;
                    ExistHospital.Fax = hospital.Fax;
                    ExistHospital.ModifiedDate = hospital.CreateDate;
                }
            }
           
            await db.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            this.logger.LogError(ex.Message);
            throw;
        }

    }
}
