using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface MonthRecordService
    {
        List<TbMonthRecord> getAll();
        bool Add(TbMonthRecord client);
        bool Edit(TbMonthRecord client);
        bool Delete(TbMonthRecord client);


    }
    public class ClsMonthRecord : MonthRecordService
    {
        EibtekSystemDbContext ctx;

        public ClsMonthRecord(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbMonthRecord> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbMonthRecord> lstMonthRecords = ctx.TbMonthRecords.ToList();

            return lstMonthRecords;
        }

        public bool Add(TbMonthRecord item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbMonthRecords.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbMonthRecord item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbMonthRecord item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
