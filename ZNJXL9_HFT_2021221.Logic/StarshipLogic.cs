using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Logic
{
    public class StarshipLogic : IStarshipLogic
    {
        IStarshipRepository starshipRepository;

        public StarshipLogic(IStarshipRepository starshipRepository)
        // DI: Dependency Injection
        {
            this.starshipRepository = starshipRepository;
        }

        public double AVGPrice()
        {
            return starshipRepository.GetAll().Average(t => t.BasePrice) ?? 0;
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return from x in starshipRepository.GetAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice) ?? 0);
        }

        public void Update(int id, Starship obj)
        {
            starshipRepository.Update(obj);
        }

        public void Create(Starship starship)
        {
            if (starship.BasePrice < 0)
            {
                throw new ArgumentException("Negative price is not allowed");
            }
            starshipRepository.Create(starship);
        }

        public IList<Starship> GetAll()
        {
            return starshipRepository.GetAll().ToList();
        }

        public IList<AveragesResult> GetBrandAverages()
        {
            var q = from car in starshipRepository.GetAll()
                    group car
                    by new { car.Brand.Id, car.Brand.Name }
                    into grp
                    select new AveragesResult()
                    {
                        BrandName = grp.Key.Name,
                        AveragePrice = grp.Average(x => x.BasePrice) ?? 0
                    };
            return q.ToList();
        }

        public Starship GetOne(int id)
        {
            return starshipRepository.GetOne(id);
        }

        IList<Starship> IStarshipLogic.GetAll()
        {
            return starshipRepository.GetAll().ToList();
        }
    }
}
