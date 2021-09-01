using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using API.Data.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression);

        public List<T> GetAll() =>
            _context.Set<T>().ToList();
    }
}