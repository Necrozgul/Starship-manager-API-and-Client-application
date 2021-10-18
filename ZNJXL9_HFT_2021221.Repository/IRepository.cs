using ZNJXL9_HFT_2021221.Data;
using System;
using System.Linq;

namespace ZNJXL9_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IQueryable<T> GetAll();

        void Create(T obj);
        void Delete(int id);
        void Update(T obj);
    }


}
