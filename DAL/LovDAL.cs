using Data;
using IDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class LovDAL : ILovDAL
{
    private readonly DataBaseContext db;
    private readonly ILogger<LovDAL> logger;
    public LovDAL(DataBaseContext db, ILogger<LovDAL> logger)
    {
        this.db = db;
        this.logger = logger;
    }
    public async Task SaveLov(LovBO Detail)
    {
        try
        {
            Lov obj;
            if(Detail.Id == 0)
            {
                obj = new Lov();
                db.lov.Add(obj);
                obj.CreateDate = DateTime.Now;
            }
            else
            {
                obj = await db.lov.Where(l => l.Id == Detail.Id).FirstOrDefaultAsync();
                obj.ModifiedDate = DateTime.Now; 
            }
            obj.StatusName = Detail.StatusName;
            obj.StatusCode = Detail.StatusCode;
            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex.Message);
            throw;
        }
    }
}
