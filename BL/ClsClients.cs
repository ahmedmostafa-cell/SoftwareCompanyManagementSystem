using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BL
{
    public interface ClientService
    {
        List<TbClient> getAll();
        bool Add(TbClient client);
        bool Edit(TbClient client);
        bool Delete(TbClient client);


    }
    public class ClsClients : ClientService
    {
        EibtekSystemDbContext ctx;

        public ClsClients(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbClient> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbClient> lstClients = ctx.TbClients.ToList();

            return lstClients;
        }

        public bool Add(TbClient item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbClients.Add(item);
                ctx.SaveChanges();
               
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbClient item)
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

        public bool Delete(TbClient item)
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
