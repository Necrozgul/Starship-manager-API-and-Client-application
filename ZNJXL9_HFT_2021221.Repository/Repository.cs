﻿using ZNJXL9_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNJXL9_HFT_2021221.Repository
{
    public abstract class Repository<T> :
        IRepository<T> where T : class
    {

        protected DbContext ctx;

        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        public abstract T Get(int id);

        public abstract void Create(T obj);

        public abstract void Delete(int id);

        public abstract void Update(T obj);
    }


}
