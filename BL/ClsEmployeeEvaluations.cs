using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface EmployeeEvaluationService
    {
        List<TbEmployeeEvaluation> getAll();
        bool Add(TbEmployeeEvaluation client);
        bool Edit(TbEmployeeEvaluation client);
        bool Delete(TbEmployeeEvaluation client);


    }
    public class ClsEmployeeEvaluations : EmployeeEvaluationService
    {
        EibtekSystemDbContext ctx;

        public ClsEmployeeEvaluations(EibtekSystemDbContext context)
        {
            ctx = context;
        }
        public List<TbEmployeeEvaluation> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbEmployeeEvaluation> lstEmployeeEvaluations = ctx.TbEmployeeEvaluations.ToList();

            return lstEmployeeEvaluations;
        }

        public bool Add(TbEmployeeEvaluation item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.TbEmployeeEvaluations.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbEmployeeEvaluation item)
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

        public bool Delete(TbEmployeeEvaluation item)
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
