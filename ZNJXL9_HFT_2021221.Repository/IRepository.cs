using ZNJXL9_HFT_2021221.Data;
using System;
using System.Linq;

namespace ZNJXL9_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T Read(int id);

        IQueryable<T> ReadAll();
    }

   
}
