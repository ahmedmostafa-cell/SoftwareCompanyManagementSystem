using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ExpenseCategoryService
    {
        List<TbExpenseCategory> getAll();
        bool Add(TbExpenseCategory client);
        bool Edit(TbExpenseCategory client);
        bool Delete(TbExpenseCategory client);


    }
    public class ClsExpenseCategories : ExpenseCategoryService
    {
        EibtekSystemDbContext ctx;

        public ClsExpenseCategories(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbExpenseCategory> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbExpenseCategory> lstExpenseCategories = ctx.TbExpenseCategories.ToList();

            return lstExpenseCategories;
        }

        public bool Add(TbExpenseCategory item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbExpenseCategories.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbExpenseCategory item)
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

        public bool Delete(TbExpenseCategory item)
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
