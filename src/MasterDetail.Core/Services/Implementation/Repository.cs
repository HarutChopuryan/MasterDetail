using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MasterDetail.Core.Services.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }
}