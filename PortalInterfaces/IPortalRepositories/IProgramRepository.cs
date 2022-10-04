using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IProgramRepository
    {
        bool AddProgram(Program model);
        bool RemoveProgram(int programId);
        bool UpdateProgram(Program program);
        Program GetProgram(int programId);
        List<Program> GetPrograms();
        List<Program> GetPrograms(Expression<Func<Program, bool>> filter = null, Func<IQueryable<Program>, IOrderedQueryable<Program>> orderBy = null, params Expression<Func<Program, object>>[] includes);
       // IEnumerable<Program> GetPrograms(Expression<Func<Program, bool>> filter = null, Func<IQueryable<Program>, IOrderedQueryable<Program>> orderBy = null);
    }
}
