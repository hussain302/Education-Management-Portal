using Microsoft.EntityFrameworkCore;
using Portal.DAL;
using PortalInterfaces.IPortalRepositories;
using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalRepositories.PortalRepository
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly PortalContext context;

        public ProgramRepository(PortalContext context)
        {
            this.context = context;
        }

        public bool AddProgram(Program model)
        {
            try
            {
                if (model != null) {
                    context.Add<Program>(model);
                    context.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public Program GetProgram(int programId)
        {
            try
            {
                return context.Programs.Include(x=>x.Department).Where(x=>x.Id == programId).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public List<Program> GetPrograms()
        {
            try
            {
                return context.Programs.Include(x=>x.Department).ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Program> GetPrograms(Expression<Func<Program, bool>> filter = null, Func<IQueryable<Program>, IOrderedQueryable<Program>> orderBy = null, params Expression<Func<Program, object>>[] includes)
        {
            IQueryable<Program> query = context.Programs;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public bool RemoveProgram(int programId)
        {
            try
            {
                var find = GetProgram(programId);
                context.Remove<Program>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateProgram(Program program)
        {
            try
            {
                if (program == null) return false;
                context.Update<Program>(program);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
