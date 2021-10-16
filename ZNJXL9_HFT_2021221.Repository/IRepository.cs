using ZNJXL9_HFT_2021221.Data;
using System;
using System.Linq;

namespace ZNJXL9_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);

        IQueryable<T> GetAll();

        // NOTE: not full CRUD, insert remove update TODO
    }

   
}
