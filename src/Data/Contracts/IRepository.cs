using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}