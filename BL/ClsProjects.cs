using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ProjectService
    {
        List<TbProject> getAll();
        bool Add(TbProject client);
        bool Edit(TbProject client);
        bool Delete(TbProject client);


    }
    public class ClsProjects : ProjectService
    {
        EibtekSystemDbContext ctx;

        public ClsProjects(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbProject> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbProject> lstProjects = ctx.TbProjects.ToList();

            return lstProjects;
        }

        public bool Add(TbProject item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbProjects.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbProject item)
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

        public bool Delete(TbProject item)
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
