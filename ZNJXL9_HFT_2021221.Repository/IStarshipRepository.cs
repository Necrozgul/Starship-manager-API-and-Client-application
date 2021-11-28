using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Models;

namespace ZNJXL9_HFT_2021221.Repository
{
    public interface IStarshipRepository
    {
        void Create(Starship starship);
        void Delete(int id);
        Starship Read(int id);
        IQueryable<Starship> ReadAll();
        void Update(Starship starship);

    }

}
