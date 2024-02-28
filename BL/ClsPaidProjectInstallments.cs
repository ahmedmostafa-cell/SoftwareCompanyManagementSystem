using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface PaidProjectInstallmentService
    {
        List<TbPaidProjectInstallment> getAll();
        bool Add(TbPaidProjectInstallment client);
        bool Edit(TbPaidProjectInstallment client);
        bool Delete(TbPaidProjectInstallment client);


    }
    public class ClsPaidProjectInstallments : PaidProjectInstallmentService
    {
        EibtekSystemDbContext ctx;

        public ClsPaidProjectInstallments(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbPaidProjectInstallment> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbPaidProjectInstallment> lstPaidProjectInstallments = ctx.TbPaidProjectInstallments.ToList();

            return lstPaidProjectInstallments;
        }

        public bool Add(TbPaidProjectInstallment item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbPaidProjectInstallments.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbPaidProjectInstallment item)
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

        public bool Delete(TbPaidProjectInstallment item)
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
