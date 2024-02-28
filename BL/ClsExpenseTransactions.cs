using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ExpenseTransactionService
    {
        List<TbExpenseTransaction> getAll();
        bool Add(TbExpenseTransaction client);
        bool Edit(TbExpenseTransaction client);
        bool Delete(TbExpenseTransaction client);


    }
    public class ClsExpenseTransactions : ExpenseTransactionService
    {
        EibtekSystemDbContext ctx;

        public ClsExpenseTransactions(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbExpenseTransaction> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbExpenseTransaction> lstExpenseTransactions = ctx.TbExpenseTransactions.ToList();

            return lstExpenseTransactions;
        }

        public bool Add(TbExpenseTransaction item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbExpenseTransactions.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbExpenseTransaction item)
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

        public bool Delete(TbExpenseTransaction item)
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
