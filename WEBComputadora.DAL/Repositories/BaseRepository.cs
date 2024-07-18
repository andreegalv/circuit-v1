using System;
using System.Collections.Generic;
using System.Linq;
using WEBComputadora.DAL.Contexts;
using WEBComputadora.DAL.Interfaces;

namespace WEBComputadora.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected BaseRepository(IDbContext context)
        {
            Context = context;
        }

        protected IDbContext Context { get; private set; }
        public abstract IList<T> GetAll();

        public void Dispose()
        {
            
        }
    }
}