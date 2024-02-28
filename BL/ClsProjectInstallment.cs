using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ProjectInstallmentService
    {
        List<TbProjectInstallment> getAll();
        bool Add(TbProjectInstallment client);
        bool Edit(TbProjectInstallment client);
        bool Delete(TbProjectInstallment client);


    }
    public class ClsProjectInstallment : ProjectInstallmentService
    {
        EibtekSystemDbContext ctx;

        public ClsProjectInstallment(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbProjectInstallment> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbProjectInstallment> lstProjectInstallments = ctx.TbProjectInstallments.ToList();

            return lstProjectInstallments;
        }

        public bool Add(TbProjectInstallment item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbProjectInstallments.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbProjectInstallment item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                if(item.CreatedBy == item.ProjectInstallmentValue ||int.Parse(item.CreatedBy) > int.Parse(item.ProjectInstallmentValue))
                {
                    item.CurrentState = 0;
                }
                else
                {
                    item.CurrentState = 1;
                }
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbProjectInstallment item)
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
