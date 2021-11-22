using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
using ZNJXL9_HFT_2021221.Models;
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

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByModels()
        {
            return from x in starshipRepository.GetAll()
                   group x by x.Model into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice) ?? 0);
        }
        public Starship GetOne(int id)
        {
            return starshipRepository.GetOne(id);
        }
        IEnumerable<Starship> IStarshipLogic.GetAll()
        {
            return starshipRepository.GetAll().ToList();
        }
        public IList<Starship> GetAll()
        {
            return starshipRepository.GetAll().ToList();
        }
        public void Create(Starship starship)
        {
            if (starship.BasePrice < 0)
            {
                throw new ErrorException("Negative price is not allowed");
            }
            starshipRepository.Create(starship);
        }
        public void Update(Starship obj)
        {
            if (obj != null && obj.Model != "" && obj.BrandId != null && obj.WeaponId != null)
            {
                starshipRepository.Update(obj);
            }
            else
            {
                throw new ErrorException("Some Data is not valid");
            }
            
        }
        public void Delete(int id)
        {
            if (starshipRepository.GetOne(id) != null)
            {
                starshipRepository.Delete(id);
            }
            else
            {
                throw new ErrorException("There is no Starship with thad id");
            }
            
        }
        public IList<AveragesResult> GetModelAverages()
        {
            var q = from s in starshipRepository.GetAll()
                    group s
                    by new { s.Id, s.Model }
                    into grp
                    select new AveragesResult()
                    {
                        ModelName = grp.Key.Model,
                        AveragePrice = grp.Average(x => x.BasePrice) ?? 0
                    };
            return q.ToList();
        }

        public Starship MostExpensiveStarship()
        {
            var elements = GetAll();
            return elements.OrderByDescending(obj => obj.BasePrice).First();
        }
        public Starship CheapestStarship()
        {
            var elements = GetAll();
            return elements.OrderByDescending(obj => obj.BasePrice).Last();
        }
        public Starship StarShipSearcher(int id, string brandname, string weaponname)
        {

            return null;
        }
    }
}
