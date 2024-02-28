using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface PaidSalesEmplyeeInstallmentService
    {
        List<TbPaidSalesEmplyeeInstallment> getAll();
        bool Add(TbPaidSalesEmplyeeInstallment client);
        bool Edit(TbPaidSalesEmplyeeInstallment client);
        bool Delete(TbPaidSalesEmplyeeInstallment client);


    }
    public class ClsPaidSalesEmplyeeInstallments : PaidSalesEmplyeeInstallmentService
    {
        EibtekSystemDbContext ctx;

        public ClsPaidSalesEmplyeeInstallments(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbPaidSalesEmplyeeInstallment> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbPaidSalesEmplyeeInstallment> lstPaidProjectInstallments = ctx.TbPaidSalesEmplyeeInstallments.ToList();

            return lstPaidProjectInstallments;
        }

        public bool Add(TbPaidSalesEmplyeeInstallment item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbPaidSalesEmplyeeInstallments.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbPaidSalesEmplyeeInstallment item)
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

        public bool Delete(TbPaidSalesEmplyeeInstallment item)
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
